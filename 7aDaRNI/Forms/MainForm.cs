// ============================================================
// MainForm.cs  –  7aDaRNI Main Navigation Form
//
// SRS NFR-2: Role-based access control enforced:
//   ADMIN   → full access to all forms and reports
//   TEACHER → Connected Mode + Reports only
//   STUDENT → Connected Mode only (read-only tabs B and D)
//
// Phase 2 D – Main form with menus for all forms and reports
// ============================================================
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace _7aDaRNI
{
    public partial class MainForm : Form
    {
        private const string CONN_STR =
            "User Id=scott;Password=tiger;Data Source=localhost:1521/orcl;";

        public MainForm()
        {
            InitializeComponent();
            ApplyRoleBasedAccess();
            DisplayUserInfo();
        }

        // ============================================================
        // NFR-2: Role-Based Access Control
        // ============================================================
        private void ApplyRoleBasedAccess()
        {
            switch (SessionManager.Role)
            {
                case "ADMIN":
                    mnuConn_i.Enabled = true;
                    mnuDisc_i.Enabled = true;
                    mnuRpt1_i.Enabled = true;
                    mnuRpt2_i.Enabled = true;
                    break;

                case "TEACHER":
                    mnuConn_i.Enabled = true;
                    mnuDisc_i.Enabled = false;
                    mnuDisc_i.Text += "  [Admin only]";
                    mnuRpt1_i.Enabled = true;
                    mnuRpt2_i.Enabled = true;
                    break;

                case "STUDENT":
                    mnuConn_i.Enabled = true;
                    mnuDisc_i.Enabled = false;
                    mnuDisc_i.Text += "  [Admin only]";
                    mnuRpt1_i.Enabled = false;
                    mnuRpt1_i.Text += "  [Teacher/Admin only]";
                    mnuRpt2_i.Enabled = false;
                    mnuRpt2_i.Text += "  [Teacher/Admin only]";
                    break;
            }
        }

        private void DisplayUserInfo()
        {
            lblUserInfo.Text =
                $"Signed in as:  {SessionManager.FullName}  " +
                $"({SessionManager.Role})  |  ID: {SessionManager.UserId}";
        }

        // ── Simple InputBox replacement (no VisualBasic reference needed) ──
        private static string ShowInputBox(string prompt, string title, string defaultValue = "")
        {
            var frm = new Form
            {
                Text = title,
                Width = 380,
                Height = 160,
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };
            var lbl = new Label { Text = prompt, Left = 14, Top = 14, Width = 340, AutoSize = true };
            var txt = new TextBox { Left = 14, Top = 40, Width = 340, Text = defaultValue };
            var btnOk = new Button
            {
                Text = "OK",
                Left = 180,
                Top = 75,
                Width = 80,
                DialogResult = DialogResult.OK,
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            var btnCancel = new Button
            {
                Text = "Cancel",
                Left = 270,
                Top = 75,
                Width = 80,
                DialogResult = DialogResult.Cancel
            };
            frm.Controls.AddRange(new Control[] { lbl, txt, btnOk, btnCancel });
            frm.AcceptButton = btnOk;
            frm.CancelButton = btnCancel;
            return frm.ShowDialog() == DialogResult.OK ? txt.Text.Trim() : string.Empty;
        }

        // ── Forms ─────────────────────────────────────────────────────
        private void mnuConnected_Click(object sender, EventArgs e)
            => new ConnectedModeForm().Show();

        private void mnuDisconnected_Click(object sender, EventArgs e)
        {
            if (!SessionManager.IsAdmin)
            {
                MessageBox.Show("Access denied. Only Admins can manage students.",
                    "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            new DisconnectedModeForm().Show();
        }

        // ── Crystal Report 1: Attendance by Course ────────────────────
        private void mnuReport1_Click(object sender, EventArgs e)
        {
            if (SessionManager.IsStudent)
            {
                MessageBox.Show("Access denied. Students cannot view course reports.",
                    "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string courseCode = ShowInputBox(
                "Enter Course Code (e.g. CS301):", "Report 1 – Parameter", "CS301");
            if (string.IsNullOrWhiteSpace(courseCode)) return;

            try
            {
                var dt = new DataTable("VW_ATTENDANCE_REPORT");
                using (var conn = new OracleConnection(CONN_STR))
                {
                    conn.Open();
                    var adp = new OracleDataAdapter(
                        @"SELECT COURSE_CODE, COURSE_NAME, TEACHER_NAME,
                                 STUDENT_NAME, SESSION_DATE, STATUS,
                                 IS_PRESENT, IS_ABSENT
                          FROM   VW_ATTENDANCE_REPORT
                          WHERE  COURSE_CODE = :p
                          ORDER  BY STUDENT_NAME, SESSION_DATE", conn);
                    adp.SelectCommand.Parameters.Add(":p",
                        OracleDbType.Varchar2).Value = courseCode.ToUpper();
                    adp.Fill(dt);
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show($"No data found for course '{courseCode}'.",
                        "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ── Uncomment after adding CrystalReport1.rpt ──
                // var rpt = new CrystalReport1();
                // rpt.SetDataSource(dt);
                // var viewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer
                //     { Dock = DockStyle.Fill, ReportSource = rpt };
                // var frm = new Form { Text = "Report 1 – " + courseCode,
                //     Width = 960, Height = 680,
                //     StartPosition = FormStartPosition.CenterScreen };
                // frm.Controls.Add(viewer);
                // frm.Show();
                // ────────────────────────────────────────────────

                MessageBox.Show(
                    $"Report 1 data loaded: {dt.Rows.Count} rows for '{courseCode}'.\n\n" +
                    "Uncomment the Crystal Reports section in\n" +
                    "MainForm.cs → mnuReport1_Click() to display the report.",
                    "Report 1 – Ready", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (OracleException ox)
            {
                MessageBox.Show($"Database Error [{ox.Number}]: {ox.Message}",
                    "Oracle Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Crystal Report 2: Student Attendance Summary ──────────────
        private void mnuReport2_Click(object sender, EventArgs e)
        {
            if (SessionManager.IsStudent)
            {
                MessageBox.Show("Access denied. Students cannot view summary reports.",
                    "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string input = ShowInputBox(
                "Show students BELOW attendance % (e.g. 75):", "Report 2 – Parameter", "75");
            if (string.IsNullOrWhiteSpace(input)) return;
            if (!double.TryParse(input, out double minPct))
            {
                MessageBox.Show("Please enter a valid number.", "Invalid Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var dt = new DataTable("VW_STUDENT_SUMMARY");
                using (var conn = new OracleConnection(CONN_STR))
                {
                    conn.Open();
                    var adp = new OracleDataAdapter(
                        @"SELECT COURSE_CODE, COURSE_NAME, TEACHER_NAME,
                                 STUDENT_NAME, STUDENT_ID, TOTAL_SESSIONS,
                                 PRESENT_COUNT, ABSENT_COUNT, ATTENDANCE_PCT
                          FROM   VW_STUDENT_SUMMARY
                          ORDER  BY COURSE_CODE, ATTENDANCE_PCT", conn);
                    adp.Fill(dt);
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No summary data found.", "No Data",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ── Uncomment after adding StudentSummary.rpt ──
                // var rpt = new StudentSummary();
                // rpt.SetDataSource(dt);
                // var viewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer
                //     { Dock = DockStyle.Fill, ReportSource = rpt };
                // var frm = new Form { Text = $"Report 2 – Students below {minPct}%",
                //     Width = 960, Height = 680,
                //     StartPosition = FormStartPosition.CenterScreen };
                // frm.Controls.Add(viewer);
                // frm.Show();
                // ────────────────────────────────────────────────

                MessageBox.Show(
                    $"Report 2 data loaded: {dt.Rows.Count} rows.\n" +
                    $"Parameter: below {minPct}%\n\n" +
                    "Uncomment the Crystal Reports section in\n" +
                    "MainForm.cs → mnuReport2_Click() to display the report.",
                    "Report 2 – Ready", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (OracleException ox)
            {
                MessageBox.Show($"Database Error [{ox.Number}]: {ox.Message}",
                    "Oracle Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Sign Out ──────────────────────────────────────────────────
        private void mnuLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to sign out?",
                "Sign Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.No) return;

            SessionManager.Logout();
            this.Hide();

            using var login = new LoginForm();
            if (login.ShowDialog() == DialogResult.OK)
            {
                // Reset menu text and re-apply for new user
                mnuDisc_i.Text = "&Disconnected Mode  (Enroll / Manage Students)";
                mnuRpt1_i.Text = "Report 1 – &Attendance by Course  (grouped + formula)";
                mnuRpt2_i.Text = "Report 2 – &Student Attendance Summary  (summarized + parameter)";
                ApplyRoleBasedAccess();
                DisplayUserInfo();
                this.Show();
            }
            else
            {
                Application.Exit();
            }
        }

        private void mnuExit_Click(object sender, EventArgs e) => Application.Exit();
    }
}