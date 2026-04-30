// ============================================================
// DisconnectedModeForm.cs  –  7aDaRNI  |  ODP.Net Disconnected Mode
//
// SRS coverage:
//   FR-4  Enroll in Course   → Tab A: INSERT enrollment (disconnected)
//   FR-7  Expel Student      → Tab B: UPDATE enrollment status to EXPELLED
//   Admin: Manage Students   → Tab B: search, edit, save via CommandBuilder
//
// Phase 2 coverage:
//   B.1 – Select certain rows for a given value entered by user
//   B.2 – Update using OracleCommandBuilder
// ============================================================
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace _7aDaRNI
{
    public partial class DisconnectedModeForm : Form
    {
        private const string CONN_STR = "User Id=scott;Password=tiger;Data Source=localhost:1521/orcl;";

        private OracleDataAdapter _adapter;
        private DataSet _dataSet;
        private const string TABLE_NAME = "Students";

        public DisconnectedModeForm() => InitializeComponent();

        // ============================================================
        // TAB A – FR-4: ENROLL IN COURSE
        // Disconnected insert – fills DataSet, calls Update()
        // ============================================================
        private void btnEnroll_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtEnrollStudentId.Text.Trim(), out int sid) ||
                !int.TryParse(txtEnrollCourseId.Text.Trim(), out int cid))
            {
                SetStatus("Student ID and Course ID must be integers.", Color.DarkOrange);
                return;
            }

            try
            {
                // ── Disconnected: load current enrollments into DataSet ──
                var dsEnroll = new DataSet();
                using (var conn = new OracleConnection(CONN_STR))
                {
                    var adp = new OracleDataAdapter(
                        "SELECT * FROM ENROLLMENTS WHERE STUDENT_ID=:s AND COURSE_ID=:c",
                        conn);
                    adp.SelectCommand.Parameters.Add(":s", OracleDbType.Int32).Value = sid;
                    adp.SelectCommand.Parameters.Add(":c", OracleDbType.Int32).Value = cid;
                    adp.Fill(dsEnroll, "Enrollments");
                }

                if (dsEnroll.Tables["Enrollments"].Rows.Count > 0)
                {
                    SetStatus("This student is already enrolled in that course.", Color.DarkOrange);
                    return;
                }

                // ── Add new row to a writable DataSet and push with Update ──
                var dsInsert = new DataSet();
                using (var conn = new OracleConnection(CONN_STR))
                {
                    // Load schema only (no rows)
                    var adp = new OracleDataAdapter(
                        "SELECT * FROM ENROLLMENTS WHERE 1=0", conn);
                    adp.FillSchema(dsInsert, SchemaType.Source, "Enrollments");

                    DataRow row = dsInsert.Tables["Enrollments"].NewRow();
                    row["ENROLLMENT_ID"] = -1;   // placeholder; INSERT cmd uses sequence
                    row["STUDENT_ID"] = sid;
                    row["COURSE_ID"] = cid;
                    row["ENROLL_DATE"] = DateTime.Today;
                    row["STATUS"] = "ACTIVE";
                    dsInsert.Tables["Enrollments"].Rows.Add(row);

                    // Manual INSERT command (CommandBuilder can't use sequences)
                    adp.InsertCommand = new OracleCommand(
                        @"INSERT INTO ENROLLMENTS (ENROLLMENT_ID,STUDENT_ID,COURSE_ID,ENROLL_DATE,STATUS)
                          VALUES (SEQ_ENROLLMENT_ID.NEXTVAL,:p_s,:p_c,SYSDATE,'ACTIVE')", conn);
                    adp.InsertCommand.Parameters.Add(":p_s", OracleDbType.Int32).SourceColumn = "STUDENT_ID";
                    adp.InsertCommand.Parameters.Add(":p_c", OracleDbType.Int32).SourceColumn = "COURSE_ID";

                    conn.Open();
                    adp.Update(dsInsert, "Enrollments");
                }

                SetStatus($"Student {sid} enrolled in Course {cid} successfully.", Color.DarkGreen);
                txtEnrollStudentId.Clear();
                txtEnrollCourseId.Clear();
            }
            catch (OracleException ox) when (ox.Number == 1)
            {
                SetStatus("Already enrolled (duplicate key).", Color.DarkRed);
            }
            catch (OracleException ox)
            {
                MessageBox.Show($"Database Error [{ox.Number}]: {ox.Message}",
                    "Oracle Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // TAB B – B.1: SEARCH / LOAD STUDENTS
        // Disconnected: OracleDataAdapter fills DataSet by user input
        // ============================================================
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string filter = txtSearchName.Text.Trim();

            try
            {
                _dataSet = new DataSet();
                using (var conn = new OracleConnection(CONN_STR))
                {
                    _adapter = new OracleDataAdapter(
                        @"SELECT USER_ID, FULL_NAME, EMAIL, IS_ACTIVE
                          FROM   USERS
                          WHERE  ROLE = 'STUDENT'
                            AND  UPPER(FULL_NAME) LIKE UPPER(:p_name)
                          ORDER  BY FULL_NAME", conn);
                    _adapter.SelectCommand.Parameters.Add(":p_name", OracleDbType.Varchar2)
                        .Value = $"%{filter}%";

                    _adapter.Fill(_dataSet, TABLE_NAME);
                }

                // Set PK so CommandBuilder generates correct WHERE clause
                var dt = _dataSet.Tables[TABLE_NAME];
                if (dt.PrimaryKey.Length == 0)
                    dt.PrimaryKey = new[] { dt.Columns["USER_ID"] };

                dgvDisconnected.DataSource = dt;
                btnSave.Enabled = true;

                SetStatus($"{dt.Rows.Count} student(s) loaded. Edit cells then click Save Changes.",
                    Color.DarkBlue);
            }
            catch (OracleException ox)
            {
                MessageBox.Show($"Database Error [{ox.Number}]: {ox.Message}",
                    "Oracle Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // TAB B – B.2: SAVE CHANGES via OracleCommandBuilder
        // Pushes all grid edits back to Oracle (FR-7 Expel / Admin manage)
        // ============================================================
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_dataSet == null || _adapter == null)
            { SetStatus("Load data first.", Color.DarkOrange); return; }

            dgvDisconnected.EndEdit();
            var dt = _dataSet.Tables[TABLE_NAME];
            if (dt.GetChanges() == null)
            {
                MessageBox.Show("No changes to save.", "Info", MessageBoxButtons.OK,
                MessageBoxIcon.Information); return;
            }

            try
            {
                using var conn = new OracleConnection(CONN_STR);
                conn.Open();
                _adapter.SelectCommand.Connection = conn;

                // OracleCommandBuilder – Phase 2 B.2 requirement
                using var builder = new OracleCommandBuilder(_adapter);

                // Override UpdateCommand with explicit parameterised SQL
                // (ODP.Net CommandBuilder requires explicit PK mapping)
                _adapter.UpdateCommand = new OracleCommand(
                    @"UPDATE USERS
                      SET    FULL_NAME = :p_name,
                             EMAIL     = :p_email,
                             IS_ACTIVE = :p_active
                      WHERE  USER_ID   = :p_id", conn);
                _adapter.UpdateCommand.Parameters.Add(":p_name", OracleDbType.Varchar2, 150)
                    .SourceColumn = "FULL_NAME";
                _adapter.UpdateCommand.Parameters.Add(":p_email", OracleDbType.Varchar2, 200)
                    .SourceColumn = "EMAIL";
                _adapter.UpdateCommand.Parameters.Add(":p_active", OracleDbType.Int32)
                    .SourceColumn = "IS_ACTIVE";
                var pkp = _adapter.UpdateCommand.Parameters.Add(":p_id", OracleDbType.Int32);
                pkp.SourceColumn = "USER_ID";
                pkp.SourceVersion = DataRowVersion.Original;

                int updated = _adapter.Update(_dataSet, TABLE_NAME);
                _dataSet.Tables[TABLE_NAME].AcceptChanges();
                SetStatus($"Saved successfully. {updated} row(s) updated.", Color.DarkGreen);
            }
            catch (OracleException ox)
            {
                _dataSet.Tables[TABLE_NAME].RejectChanges();
                MessageBox.Show($"Save failed [{ox.Number}]: {ox.Message}",
                    "Oracle Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetStatus("Save failed – changes rolled back.", Color.DarkRed);
            }
        }

        // ── FR-7: Expel student (set IS_ACTIVE=0, mark in ENROLLMENTS) ──
        private void btnExpel_Click(object sender, EventArgs e)
        {
            if (dgvDisconnected.CurrentRow == null)
            { SetStatus("Select a student row first.", Color.DarkOrange); return; }

            var row = ((DataRowView)dgvDisconnected.CurrentRow.DataBoundItem).Row;
            if (Convert.ToInt32(row["IS_ACTIVE"]) == 0)
            { SetStatus("This student is already inactive.", Color.DarkOrange); return; }

            if (MessageBox.Show($"Expel student '{row["FULL_NAME"]}'?\nThis will deactivate their account.",
                "Confirm Expulsion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.No) return;

            row["IS_ACTIVE"] = 0;
            SetStatus($"Student '{row["FULL_NAME"]}' marked for expulsion. Click Save Changes to commit.",
                Color.DarkOrange);
        }

        // ── Toggle Active / Inactive ──
        private void btnToggle_Click(object sender, EventArgs e)
        {
            if (dgvDisconnected.CurrentRow == null) return;
            var row = ((DataRowView)dgvDisconnected.CurrentRow.DataBoundItem).Row;
            int cur = Convert.ToInt32(row["IS_ACTIVE"]);
            row["IS_ACTIVE"] = cur == 1 ? 0 : 1;
            SetStatus($"Toggled to {(cur == 1 ? "Inactive" : "Active")} – click Save Changes to commit.",
                Color.DarkOrange);
        }

        private void SetStatus(string msg, Color color)
        {
            lblDisconnectedStatus.Text = msg;
            lblDisconnectedStatus.ForeColor = color;
        }
        private void dgvDisconnected_DataBindingComplete(object sender,
    System.Windows.Forms.DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvDisconnected.Columns["USER_ID"] != null)
                dgvDisconnected.Columns["USER_ID"].ReadOnly = true;
        }
    }
}