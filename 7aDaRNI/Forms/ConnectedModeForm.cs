// ============================================================
// ConnectedModeForm.cs  –  7aDaRNI  |  ODP.Net Connected Mode
//
// SRS coverage:
//   FR-1  Mark Attendance   → Tab A (Insert without procedure)
//   FR-2  View Attendance   → Tab B (Select with bind variables)
//   FR-5  View Assigned Courses → Tab C (SP multi-row)
//   FR-2  Absence summary   → Tab D (SP single value OUT NUMBER)
//
// Phase 2 coverage:
//   A.1 – Select using bind variables & command parameters  → Tab B
//   A.2 – Insert without stored procedure                  → Tab A
//   A.3 – SP, OUT NUMBER, no SysRefCursor                  → Tab D
//   A.4 – SP returning multiple rows                       → Tab C
//
// CHANGED (Teacher Scoping):
//   All 4 tabs now enforce that a logged-in Teacher may only
//   operate on courses they are assigned to in COURSES.TEACHER_ID.
//   Admins bypass all course-ownership checks.
//   Students keep their existing restrictions (Tab B + D only,
//   own absence report only).
// ============================================================
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace _7aDaRNI
{
    public partial class ConnectedModeForm : Form
    {
        private const string CONN_STR =
            "User Id=scott;Password=tiger;Data Source=localhost:1521/orcl;";

        public ConnectedModeForm()
        {
            InitializeComponent();
            ApplyRoleRestrictions();
        }

        // ── Hide tabs the current role cannot use ────────────────────
        private void ApplyRoleRestrictions()
        {
            if (SessionManager.IsStudent)
            {
                tabControl1.TabPages.Remove(tabA);
                tabControl1.TabPages.Remove(tabC);
                this.Text = "7aDaRNI – View Attendance (Student)";

                txtSpStudentId.Text = SessionManager.UserId.ToString();
                txtSpStudentId.ReadOnly = true;
                txtSpStudentId.BackColor = System.Drawing.SystemColors.Control;
                txtSpStudentId.ForeColor = System.Drawing.Color.DarkSlateGray;

                lblConnectedStatus.Text =
                    $"Signed in as: {SessionManager.FullName} (ID: {SessionManager.UserId})" +
                    " – you can only view your own absence report.";
                lblConnectedStatus.ForeColor = System.Drawing.Color.FromArgb(0, 80, 160);
            }
            else if (SessionManager.IsTeacher)
            {
                this.Text = "7aDaRNI – Connected Mode (Teacher)";

                // Pre-fill and lock the Teacher ID fields on Tab A and Tab C
                // so a teacher cannot impersonate another teacher.
                txtInsTeacherId.Text = SessionManager.UserId.ToString();
                txtInsTeacherId.ReadOnly = true;
                txtInsTeacherId.BackColor = System.Drawing.SystemColors.Control;
                txtInsTeacherId.ForeColor = System.Drawing.Color.DarkSlateGray;

                txtSpTeacherId.Text = SessionManager.UserId.ToString();
                txtSpTeacherId.ReadOnly = true;
                txtSpTeacherId.BackColor = System.Drawing.SystemColors.Control;
                txtSpTeacherId.ForeColor = System.Drawing.Color.DarkSlateGray;
            }
            else if (SessionManager.IsAdmin)
            {
                this.Text = "7aDaRNI – Connected Mode (Admin)";
            }
        }

        // ============================================================
        // HELPER – Course ownership check
        //
        // Returns true if the current teacher is assigned to the given
        // course, OR if the current user is an Admin (always allowed).
        // Also returns true for Students (they have their own guards).
        //
        // Outputs a user-friendly error via SetStatus() and returns
        // false when the check fails, so callers just do:
        //   if (!TeacherOwnsCourse(courseId)) return;
        // ============================================================
        private bool TeacherOwnsCourse(int courseId)
        {
            // Admins and Students skip this check
            if (!SessionManager.IsTeacher) return true;

            try
            {
                using var conn = new OracleConnection(CONN_STR);
                conn.Open();

                const string sql =
                    @"SELECT COUNT(*)
                      FROM   COURSES
                      WHERE  COURSE_ID  = :p_course_id
                        AND  TEACHER_ID = :p_teacher_id
                        AND  IS_ACTIVE  = 1";

                using var cmd = new OracleCommand(sql, conn);
                cmd.Parameters.Add(":p_course_id", OracleDbType.Int32).Value = courseId;
                cmd.Parameters.Add(":p_teacher_id", OracleDbType.Int32).Value = SessionManager.UserId;

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 0)
                {
                    SetStatus(
                        $"Access denied: Course {courseId} is not assigned to you.",
                        Color.DarkRed);
                    return false;
                }
                return true;
            }
            catch (OracleException ox)
            {
                MessageBox.Show($"Database Error [{ox.Number}]: {ox.Message}",
                    "Oracle Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ============================================================
        // HELPER – Student enrolled in course check (Tab A + Tab D)
        //
        // For teachers: verifies the student is actually enrolled in
        // the course before marking or reporting their attendance.
        // Prevents a teacher from inserting/querying records for
        // students who don't belong to their course.
        // ============================================================
        private bool StudentEnrolledInCourse(int studentId, int courseId)
        {
            // Only enforce for Teachers
            if (!SessionManager.IsTeacher) return true;

            try
            {
                using var conn = new OracleConnection(CONN_STR);
                conn.Open();

                const string sql =
                    @"SELECT COUNT(*)
                      FROM   ENROLLMENTS
                      WHERE  STUDENT_ID = :p_student_id
                        AND  COURSE_ID  = :p_course_id
                        AND  STATUS     = 'ACTIVE'";

                using var cmd = new OracleCommand(sql, conn);
                cmd.Parameters.Add(":p_student_id", OracleDbType.Int32).Value = studentId;
                cmd.Parameters.Add(":p_course_id", OracleDbType.Int32).Value = courseId;

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 0)
                {
                    SetStatus(
                        $"Access denied: Student {studentId} is not enrolled in Course {courseId}.",
                        Color.DarkRed);
                    return false;
                }
                return true;
            }
            catch (OracleException ox)
            {
                MessageBox.Show($"Database Error [{ox.Number}]: {ox.Message}",
                    "Oracle Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ============================================================
        // TAB A – FR-1: MARK ATTENDANCE
        // Phase 2 A.2 – INSERT without stored procedure, bind variables
        //
        // Teacher guard:
        //   1. The course must be assigned to this teacher.
        //   2. The student must be actively enrolled in that course.
        // ============================================================
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!ValidateInsert()) return;

            int studentId = int.Parse(txtInsStudentId.Text.Trim());
            int courseId = int.Parse(txtInsCourseId.Text.Trim());

            // ── Teacher scope checks ──────────────────────────────────
            if (!TeacherOwnsCourse(courseId)) return;
            if (!StudentEnrolledInCourse(studentId, courseId)) return;

            try
            {
                using var conn = new OracleConnection(CONN_STR);
                conn.Open();

                const string sql =
                    @"INSERT INTO ATTENDANCE
                        (ATTENDANCE_ID, STUDENT_ID, COURSE_ID,
                         SESSION_DATE,  STATUS,     MARKED_BY, MARKED_AT)
                      VALUES
                        (SEQ_ATTENDANCE_ID.NEXTVAL,
                         :p_student_id, :p_course_id,
                         :p_date, :p_status, :p_teacher_id, SYSTIMESTAMP)";

                using var cmd = new OracleCommand(sql, conn);
                cmd.Parameters.Add(":p_student_id", OracleDbType.Int32).Value = studentId;
                cmd.Parameters.Add(":p_course_id", OracleDbType.Int32).Value = courseId;
                cmd.Parameters.Add(":p_date", OracleDbType.Date).Value = dtpInsDate.Value.Date;
                cmd.Parameters.Add(":p_status", OracleDbType.Varchar2).Value = cmbInsStatus.SelectedItem.ToString();
                cmd.Parameters.Add(":p_teacher_id", OracleDbType.Int32).Value = int.Parse(txtInsTeacherId.Text.Trim());

                cmd.ExecuteNonQuery();
                SetStatus("Attendance marked successfully.", Color.DarkGreen);
                ClearInsertFields();
            }
            catch (OracleException ox) when (ox.Number == 1)
            {
                SetStatus("Error: Attendance already marked for this student on that date.", Color.DarkRed);
            }
            catch (OracleException ox) when (ox.Number == 2291)
            {
                SetStatus($"Error: Student ID, Course ID or Teacher ID does not exist. [{ox.Number}]", Color.DarkRed);
            }
            catch (OracleException ox)
            {
                MessageBox.Show($"Database Error [{ox.Number}]: {ox.Message}", "Oracle Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // TAB B – FR-2: VIEW ATTENDANCE
        // Phase 2 A.1 – SELECT using bind variables & command parameters
        //
        // Teacher guard:
        //   The course being queried must be assigned to this teacher.
        // ============================================================
        private void btnSelectRows_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSelCourseId.Text))
            { SetStatus("Please enter a Course ID.", Color.DarkOrange); return; }

            if (!int.TryParse(txtSelCourseId.Text.Trim(), out int courseId))
            { SetStatus("Course ID must be a number.", Color.DarkOrange); return; }

            // ── Teacher scope check ───────────────────────────────────
            if (!TeacherOwnsCourse(courseId)) return;

            try
            {
                using var conn = new OracleConnection(CONN_STR);
                conn.Open();

                const string sql =
                    @"SELECT A.ATTENDANCE_ID,
                             U.FULL_NAME   AS STUDENT_NAME,
                             A.STUDENT_ID,
                             C.COURSE_NAME,
                             A.SESSION_DATE,
                             A.STATUS,
                             T.FULL_NAME   AS MARKED_BY
                      FROM   ATTENDANCE A
                      JOIN   USERS    U ON A.STUDENT_ID = U.USER_ID
                      JOIN   COURSES  C ON A.COURSE_ID  = C.COURSE_ID
                      JOIN   USERS    T ON A.MARKED_BY  = T.USER_ID
                      WHERE  A.COURSE_ID    = :p_course_id
                        AND  A.SESSION_DATE = TRUNC(:p_date)
                      ORDER  BY U.FULL_NAME";

                using var cmd = new OracleCommand(sql, conn);
                cmd.Parameters.Add(":p_course_id", OracleDbType.Int32).Value = courseId;
                cmd.Parameters.Add(":p_date", OracleDbType.Date).Value = dtpSelDate.Value.Date;

                using var reader = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(reader);
                dgvConnected.DataSource = dt;
                SetStatus(
                    $"{dt.Rows.Count} record(s) found for Course {courseId} on {dtpSelDate.Value:dd-MMM-yyyy}.",
                    dt.Rows.Count > 0 ? Color.DarkBlue : Color.DarkOrange);
            }
            catch (OracleException ox)
            {
                MessageBox.Show($"Database Error [{ox.Number}]: {ox.Message}",
                    "Oracle Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // TAB C – FR-5: VIEW ASSIGNED COURSES
        // Phase 2 A.4 – Stored procedure returning MULTIPLE rows
        //
        // Teacher guard:
        //   Teacher ID field is pre-filled and locked to the session
        //   user ID in ApplyRoleRestrictions(), so the SP only ever
        //   receives the teacher's own ID. A belt-and-suspenders check
        //   here catches any attempt to bypass the read-only field.
        // ============================================================
        private void btnSpMultiRow_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSpTeacherId.Text))
            { SetStatus("Please enter a Teacher ID.", Color.DarkOrange); return; }

            if (SessionManager.IsTeacher &&
                txtSpTeacherId.Text.Trim() != SessionManager.UserId.ToString())
            {
                SetStatus("Access denied: you can only view your own assigned courses.", Color.DarkRed);
                txtSpTeacherId.Text = SessionManager.UserId.ToString();
                return;
            }

            try
            {
                using var conn = new OracleConnection(CONN_STR);
                conn.Open();

                using var cmd = new OracleCommand("SP_GET_COURSES_BY_TEACHER", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_teacher_id", OracleDbType.Int32).Value =
                    int.Parse(txtSpTeacherId.Text.Trim());

                var cursorParam = cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor);
                cursorParam.Direction = ParameterDirection.Output;

                using var reader = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(reader);
                dgvConnected.DataSource = dt;
                SetStatus(
                    $"SP returned {dt.Rows.Count} course(s) for Teacher {txtSpTeacherId.Text}.",
                    Color.DarkBlue);
            }
            catch (OracleException ox)
            {
                MessageBox.Show($"Database Error [{ox.Number}]: {ox.Message}",
                    "Oracle Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // TAB D – FR-2: STUDENT ABSENCE SUMMARY
        // Phase 2 A.3 – SP with OUT NUMBER params, NO SysRefCursor
        //
        // Teacher guard:
        //   1. The course must be assigned to this teacher.
        //   2. The student must be actively enrolled in that course.
        // Student guard:
        //   Students can only query their own student ID (unchanged).
        // ============================================================
        private void btnSpSingleRow_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSpStudentId.Text) ||
                string.IsNullOrWhiteSpace(txtSpCourseId.Text))
            { SetStatus("Please enter both Student ID and Course ID.", Color.DarkOrange); return; }

            if (!int.TryParse(txtSpStudentId.Text.Trim(), out int studentId) ||
                !int.TryParse(txtSpCourseId.Text.Trim(), out int courseId))
            { SetStatus("IDs must be numeric.", Color.DarkOrange); return; }

            // ── Student: own record only ──────────────────────────────
            if (SessionManager.IsStudent && studentId != SessionManager.UserId)
            {
                SetStatus("Access denied: you can only view your own absence report.", Color.DarkRed);
                txtSpStudentId.Text = SessionManager.UserId.ToString();
                return;
            }

            // ── Teacher scope checks ──────────────────────────────────
            if (!TeacherOwnsCourse(courseId)) return;
            if (!StudentEnrolledInCourse(studentId, courseId)) return;

            try
            {
                using var conn = new OracleConnection(CONN_STR);
                conn.Open();

                using var cmd = new OracleCommand("SP_GET_ABSENCE_COUNT", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("p_student_id", OracleDbType.Int32).Value = studentId;
                cmd.Parameters.Add("p_course_id", OracleDbType.Int32).Value = courseId;

                var pAbs = cmd.Parameters.Add("p_abs_count", OracleDbType.Decimal);
                pAbs.Direction = ParameterDirection.Output;
                var pSess = cmd.Parameters.Add("p_total_sess", OracleDbType.Decimal);
                pSess.Direction = ParameterDirection.Output;
                var pPct = cmd.Parameters.Add("p_pct_present", OracleDbType.Decimal);
                pPct.Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                int absCount = Convert.ToInt32(pAbs.Value.ToString());
                int totSess = Convert.ToInt32(pSess.Value.ToString());
                decimal pctPres = Convert.ToDecimal(pPct.Value.ToString());

                lblResultAbsences.Text = absCount.ToString();
                lblResultSessions.Text = totSess.ToString();
                lblResultPct.Text = $"{pctPres}%";
                lblResultRisk.Text = pctPres < 75 ? "AT RISK" : "OK";
                lblResultRisk.ForeColor = pctPres < 75 ? Color.DarkRed : Color.DarkGreen;

                SetStatus($"Absence report retrieved for Student {studentId}.", Color.DarkBlue);
            }
            catch (OracleException ox)
            {
                MessageBox.Show($"Database Error [{ox.Number}]: {ox.Message}",
                    "Oracle Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException)
            {
                SetStatus("IDs must be numeric.", Color.DarkRed);
            }
        }

        // ── Helpers ──────────────────────────────────────────────────
        private void SetStatus(string msg, Color color)
        {
            lblConnectedStatus.Text = msg;
            lblConnectedStatus.ForeColor = color;
        }

        private void ClearInsertFields()
        {
            txtInsStudentId.Clear();
            txtInsCourseId.Clear();
            // Don't clear Teacher ID if it was locked from the session
            if (!txtInsTeacherId.ReadOnly) txtInsTeacherId.Clear();
            cmbInsStatus.SelectedIndex = 0;
        }

        private bool ValidateInsert()
        {
            if (string.IsNullOrWhiteSpace(txtInsStudentId.Text) ||
                string.IsNullOrWhiteSpace(txtInsCourseId.Text) ||
                string.IsNullOrWhiteSpace(txtInsTeacherId.Text) ||
                cmbInsStatus.SelectedIndex < 0)
            {
                SetStatus("Please fill in all fields.", Color.DarkOrange);
                return false;
            }
            if (!int.TryParse(txtInsStudentId.Text, out _) ||
                !int.TryParse(txtInsCourseId.Text, out _) ||
                !int.TryParse(txtInsTeacherId.Text, out _))
            {
                SetStatus("Student ID, Course ID and Teacher ID must be integers.", Color.DarkOrange);
                return false;
            }
            return true;
        }
    }
}