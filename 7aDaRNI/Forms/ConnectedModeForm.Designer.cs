// ============================================================
// ConnectedModeForm.Designer.cs  –  7aDaRNI Connected Mode
// All controls created inline - no helper methods (required by VS Designer)
// ============================================================
namespace _7aDaRNI
{
    partial class ConnectedModeForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // ── Declare all controls ──────────────────────────────────
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabA = new System.Windows.Forms.TabPage();
            this.tabB = new System.Windows.Forms.TabPage();
            this.tabC = new System.Windows.Forms.TabPage();
            this.tabD = new System.Windows.Forms.TabPage();

            // Tab A controls
            this.lblInsStudentId = new System.Windows.Forms.Label();
            this.txtInsStudentId = new System.Windows.Forms.TextBox();
            this.lblInsCourseId = new System.Windows.Forms.Label();
            this.txtInsCourseId = new System.Windows.Forms.TextBox();
            this.lblInsTeacherId = new System.Windows.Forms.Label();
            this.txtInsTeacherId = new System.Windows.Forms.TextBox();
            this.lblInsDate = new System.Windows.Forms.Label();
            this.dtpInsDate = new System.Windows.Forms.DateTimePicker();
            this.lblInsStatus = new System.Windows.Forms.Label();
            this.cmbInsStatus = new System.Windows.Forms.ComboBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.lblInsHint = new System.Windows.Forms.Label();

            // Tab B controls
            this.lblSelCourseId = new System.Windows.Forms.Label();
            this.txtSelCourseId = new System.Windows.Forms.TextBox();
            this.lblSelDate = new System.Windows.Forms.Label();
            this.dtpSelDate = new System.Windows.Forms.DateTimePicker();
            this.btnSelectRows = new System.Windows.Forms.Button();
            this.lblSelHint = new System.Windows.Forms.Label();

            // Tab C controls
            this.lblSpTeacherId = new System.Windows.Forms.Label();
            this.txtSpTeacherId = new System.Windows.Forms.TextBox();
            this.btnSpMultiRow = new System.Windows.Forms.Button();
            this.lblSpHint = new System.Windows.Forms.Label();

            // Tab D controls
            this.lblSpStudentId = new System.Windows.Forms.Label();
            this.txtSpStudentId = new System.Windows.Forms.TextBox();
            this.lblSpCourseId = new System.Windows.Forms.Label();
            this.txtSpCourseId = new System.Windows.Forms.TextBox();
            this.btnSpSingleRow = new System.Windows.Forms.Button();
            this.lblSpHint2 = new System.Windows.Forms.Label();
            this.pnlResult = new System.Windows.Forms.Panel();
            this.lblRAbsTitle = new System.Windows.Forms.Label();
            this.lblResultAbsences = new System.Windows.Forms.Label();
            this.lblRSessTitle = new System.Windows.Forms.Label();
            this.lblResultSessions = new System.Windows.Forms.Label();
            this.lblRPctTitle = new System.Windows.Forms.Label();
            this.lblResultPct = new System.Windows.Forms.Label();
            this.lblRRiskTitle = new System.Windows.Forms.Label();
            this.lblResultRisk = new System.Windows.Forms.Label();

            // Shared
            this.dgvConnected = new System.Windows.Forms.DataGridView();
            this.lblConnectedStatus = new System.Windows.Forms.Label();

            this.tabControl1.SuspendLayout();
            this.tabA.SuspendLayout();
            this.tabB.SuspendLayout();
            this.tabC.SuspendLayout();
            this.tabD.SuspendLayout();
            this.pnlResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvConnected).BeginInit();
            this.SuspendLayout();

            // ══════════════════════════════════════════════════════════
            // TAB A  – Mark Attendance
            // ══════════════════════════════════════════════════════════
            this.tabA.Text = "A) Mark Attendance";
            this.tabA.Padding = new System.Windows.Forms.Padding(8);
            this.tabA.UseVisualStyleBackColor = true;

            this.lblInsStudentId.Text = "Student ID:";
            this.lblInsStudentId.AutoSize = true;
            this.lblInsStudentId.Location = new System.Drawing.Point(10, 20);
            this.lblInsStudentId.Font = new System.Drawing.Font("Segoe UI", 9f);

            this.txtInsStudentId.Location = new System.Drawing.Point(90, 17);
            this.txtInsStudentId.Width = 80;

            this.lblInsCourseId.Text = "Course ID:";
            this.lblInsCourseId.AutoSize = true;
            this.lblInsCourseId.Location = new System.Drawing.Point(190, 20);
            this.lblInsCourseId.Font = new System.Drawing.Font("Segoe UI", 9f);

            this.txtInsCourseId.Location = new System.Drawing.Point(270, 17);
            this.txtInsCourseId.Width = 80;

            this.lblInsTeacherId.Text = "Teacher ID:";
            this.lblInsTeacherId.AutoSize = true;
            this.lblInsTeacherId.Location = new System.Drawing.Point(370, 20);
            this.lblInsTeacherId.Font = new System.Drawing.Font("Segoe UI", 9f);

            this.txtInsTeacherId.Location = new System.Drawing.Point(455, 17);
            this.txtInsTeacherId.Width = 80;

            this.lblInsDate.Text = "Session Date:";
            this.lblInsDate.AutoSize = true;
            this.lblInsDate.Location = new System.Drawing.Point(10, 57);
            this.lblInsDate.Font = new System.Drawing.Font("Segoe UI", 9f);

            this.dtpInsDate.Location = new System.Drawing.Point(100, 53);
            this.dtpInsDate.Width = 140;
            this.dtpInsDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.lblInsStatus.Text = "Status:";
            this.lblInsStatus.AutoSize = true;
            this.lblInsStatus.Location = new System.Drawing.Point(260, 57);
            this.lblInsStatus.Font = new System.Drawing.Font("Segoe UI", 9f);

            this.cmbInsStatus.Location = new System.Drawing.Point(315, 54);
            this.cmbInsStatus.Width = 110;
            this.cmbInsStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInsStatus.Items.AddRange(new object[] { "PRESENT", "ABSENT" });
            this.cmbInsStatus.SelectedIndex = 0;

            this.btnInsert.Text = "Mark Attendance";
            this.btnInsert.Location = new System.Drawing.Point(10, 92);
            this.btnInsert.Size = new System.Drawing.Size(150, 30);
            this.btnInsert.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnInsert.ForeColor = System.Drawing.Color.White;
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsert.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);

            this.lblInsHint.Text = "FR-1: Mark Attendance | Phase 2 A.2 – INSERT without stored procedure, bind variables";
            this.lblInsHint.AutoSize = true;
            this.lblInsHint.Location = new System.Drawing.Point(10, 132);
            this.lblInsHint.Font = new System.Drawing.Font("Segoe UI", 8.5f, System.Drawing.FontStyle.Italic);
            this.lblInsHint.ForeColor = System.Drawing.Color.FromArgb(0, 100, 180);

            this.tabA.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblInsStudentId, this.txtInsStudentId,
                this.lblInsCourseId,  this.txtInsCourseId,
                this.lblInsTeacherId, this.txtInsTeacherId,
                this.lblInsDate,      this.dtpInsDate,
                this.lblInsStatus,    this.cmbInsStatus,
                this.btnInsert,       this.lblInsHint });

            // ══════════════════════════════════════════════════════════
            // TAB B  – View Attendance
            // ══════════════════════════════════════════════════════════
            this.tabB.Text = "B) View Attendance";
            this.tabB.Padding = new System.Windows.Forms.Padding(8);
            this.tabB.UseVisualStyleBackColor = true;

            this.lblSelCourseId.Text = "Course ID:";
            this.lblSelCourseId.AutoSize = true;
            this.lblSelCourseId.Location = new System.Drawing.Point(10, 20);
            this.lblSelCourseId.Font = new System.Drawing.Font("Segoe UI", 9f);

            this.txtSelCourseId.Location = new System.Drawing.Point(90, 17);
            this.txtSelCourseId.Width = 100;

            this.lblSelDate.Text = "Session Date:";
            this.lblSelDate.AutoSize = true;
            this.lblSelDate.Location = new System.Drawing.Point(210, 20);
            this.lblSelDate.Font = new System.Drawing.Font("Segoe UI", 9f);

            this.dtpSelDate.Location = new System.Drawing.Point(300, 17);
            this.dtpSelDate.Width = 140;
            this.dtpSelDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.btnSelectRows.Text = "View Attendance";
            this.btnSelectRows.Location = new System.Drawing.Point(10, 55);
            this.btnSelectRows.Size = new System.Drawing.Size(150, 30);
            this.btnSelectRows.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnSelectRows.ForeColor = System.Drawing.Color.White;
            this.btnSelectRows.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectRows.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnSelectRows.Click += new System.EventHandler(this.btnSelectRows_Click);

            this.lblSelHint.Text = "FR-2: View Attendance | Phase 2 A.1 – SELECT with bind variables & command parameters";
            this.lblSelHint.AutoSize = true;
            this.lblSelHint.Location = new System.Drawing.Point(10, 95);
            this.lblSelHint.Font = new System.Drawing.Font("Segoe UI", 8.5f, System.Drawing.FontStyle.Italic);
            this.lblSelHint.ForeColor = System.Drawing.Color.FromArgb(0, 100, 180);

            this.tabB.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblSelCourseId, this.txtSelCourseId,
                this.lblSelDate,     this.dtpSelDate,
                this.btnSelectRows,  this.lblSelHint });

            // ══════════════════════════════════════════════════════════
            // TAB C  – View Assigned Courses (SP Multi-Row)
            // ══════════════════════════════════════════════════════════
            this.tabC.Text = "C) View Assigned Courses (SP Multi-Row)";
            this.tabC.Padding = new System.Windows.Forms.Padding(8);
            this.tabC.UseVisualStyleBackColor = true;

            this.lblSpTeacherId.Text = "Teacher ID:";
            this.lblSpTeacherId.AutoSize = true;
            this.lblSpTeacherId.Location = new System.Drawing.Point(10, 20);
            this.lblSpTeacherId.Font = new System.Drawing.Font("Segoe UI", 9f);

            this.txtSpTeacherId.Location = new System.Drawing.Point(90, 17);
            this.txtSpTeacherId.Width = 100;

            this.btnSpMultiRow.Text = "View Assigned Courses";
            this.btnSpMultiRow.Location = new System.Drawing.Point(10, 55);
            this.btnSpMultiRow.Size = new System.Drawing.Size(190, 30);
            this.btnSpMultiRow.BackColor = System.Drawing.Color.FromArgb(0, 140, 80);
            this.btnSpMultiRow.ForeColor = System.Drawing.Color.White;
            this.btnSpMultiRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpMultiRow.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnSpMultiRow.Click += new System.EventHandler(this.btnSpMultiRow_Click);

            this.lblSpHint.Text = "FR-5: View Assigned Courses | Phase 2 A.4 – Stored procedure returning multiple rows (SYS_REFCURSOR)";
            this.lblSpHint.AutoSize = true;
            this.lblSpHint.Location = new System.Drawing.Point(10, 95);
            this.lblSpHint.Font = new System.Drawing.Font("Segoe UI", 8.5f, System.Drawing.FontStyle.Italic);
            this.lblSpHint.ForeColor = System.Drawing.Color.FromArgb(0, 100, 180);

            this.tabC.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblSpTeacherId, this.txtSpTeacherId,
                this.btnSpMultiRow,  this.lblSpHint });

            // ══════════════════════════════════════════════════════════
            // TAB D  – Absence Report (SP OUT NUMBER)
            // ══════════════════════════════════════════════════════════
            this.tabD.Text = "D) Absence Report (SP OUT NUMBER)";
            this.tabD.Padding = new System.Windows.Forms.Padding(8);
            this.tabD.UseVisualStyleBackColor = true;

            this.lblSpStudentId.Text = "Student ID:";
            this.lblSpStudentId.AutoSize = true;
            this.lblSpStudentId.Location = new System.Drawing.Point(10, 20);
            this.lblSpStudentId.Font = new System.Drawing.Font("Segoe UI", 9f);

            this.txtSpStudentId.Location = new System.Drawing.Point(90, 17);
            this.txtSpStudentId.Width = 100;

            this.lblSpCourseId.Text = "Course ID:";
            this.lblSpCourseId.AutoSize = true;
            this.lblSpCourseId.Location = new System.Drawing.Point(210, 20);
            this.lblSpCourseId.Font = new System.Drawing.Font("Segoe UI", 9f);

            this.txtSpCourseId.Location = new System.Drawing.Point(285, 17);
            this.txtSpCourseId.Width = 100;

            this.btnSpSingleRow.Text = "Get Absence Report";
            this.btnSpSingleRow.Location = new System.Drawing.Point(10, 55);
            this.btnSpSingleRow.Size = new System.Drawing.Size(170, 30);
            this.btnSpSingleRow.BackColor = System.Drawing.Color.FromArgb(0, 140, 80);
            this.btnSpSingleRow.ForeColor = System.Drawing.Color.White;
            this.btnSpSingleRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpSingleRow.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnSpSingleRow.Click += new System.EventHandler(this.btnSpSingleRow_Click);

            // Result panel
            this.pnlResult.Location = new System.Drawing.Point(200, 48);
            this.pnlResult.Size = new System.Drawing.Size(580, 75);
            this.pnlResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlResult.BackColor = System.Drawing.Color.FromArgb(245, 248, 255);

            this.lblRAbsTitle.Text = "Absences:";
            this.lblRAbsTitle.AutoSize = true;
            this.lblRAbsTitle.Location = new System.Drawing.Point(10, 10);
            this.lblRAbsTitle.Font = new System.Drawing.Font("Segoe UI", 9f);

            this.lblResultAbsences.Text = "-";
            this.lblResultAbsences.AutoSize = true;
            this.lblResultAbsences.Location = new System.Drawing.Point(10, 28);
            this.lblResultAbsences.Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
            this.lblResultAbsences.ForeColor = System.Drawing.Color.FromArgb(0, 80, 160);

            this.lblRSessTitle.Text = "Total Sessions:";
            this.lblRSessTitle.AutoSize = true;
            this.lblRSessTitle.Location = new System.Drawing.Point(110, 10);
            this.lblRSessTitle.Font = new System.Drawing.Font("Segoe UI", 9f);

            this.lblResultSessions.Text = "-";
            this.lblResultSessions.AutoSize = true;
            this.lblResultSessions.Location = new System.Drawing.Point(110, 28);
            this.lblResultSessions.Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
            this.lblResultSessions.ForeColor = System.Drawing.Color.FromArgb(0, 80, 160);

            this.lblRPctTitle.Text = "Attendance %:";
            this.lblRPctTitle.AutoSize = true;
            this.lblRPctTitle.Location = new System.Drawing.Point(240, 10);
            this.lblRPctTitle.Font = new System.Drawing.Font("Segoe UI", 9f);

            this.lblResultPct.Text = "-";
            this.lblResultPct.AutoSize = true;
            this.lblResultPct.Location = new System.Drawing.Point(240, 28);
            this.lblResultPct.Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
            this.lblResultPct.ForeColor = System.Drawing.Color.FromArgb(0, 80, 160);

            this.lblRRiskTitle.Text = "Risk Status:";
            this.lblRRiskTitle.AutoSize = true;
            this.lblRRiskTitle.Location = new System.Drawing.Point(390, 10);
            this.lblRRiskTitle.Font = new System.Drawing.Font("Segoe UI", 9f);

            this.lblResultRisk.Text = "-";
            this.lblResultRisk.AutoSize = true;
            this.lblResultRisk.Location = new System.Drawing.Point(390, 28);
            this.lblResultRisk.Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
            this.lblResultRisk.ForeColor = System.Drawing.Color.FromArgb(0, 80, 160);

            this.pnlResult.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblRAbsTitle,    this.lblResultAbsences,
                this.lblRSessTitle,   this.lblResultSessions,
                this.lblRPctTitle,    this.lblResultPct,
                this.lblRRiskTitle,   this.lblResultRisk });

            this.lblSpHint2.Text = "FR-2: View Attendance | Phase 2 A.3 – SP with OUT NUMBER parameters, no SysRefCursor";
            this.lblSpHint2.AutoSize = true;
            this.lblSpHint2.Location = new System.Drawing.Point(10, 135);
            this.lblSpHint2.Font = new System.Drawing.Font("Segoe UI", 8.5f, System.Drawing.FontStyle.Italic);
            this.lblSpHint2.ForeColor = System.Drawing.Color.FromArgb(0, 100, 180);

            this.tabD.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblSpStudentId, this.txtSpStudentId,
                this.lblSpCourseId,  this.txtSpCourseId,
                this.btnSpSingleRow, this.pnlResult,
                this.lblSpHint2 });

            // ══════════════════════════════════════════════════════════
            // TAB CONTROL
            // ══════════════════════════════════════════════════════════
            this.tabControl1.Location = new System.Drawing.Point(8, 8);
            this.tabControl1.Size = new System.Drawing.Size(860, 185);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.tabControl1.TabPages.AddRange(new System.Windows.Forms.TabPage[] {
                this.tabA, this.tabB, this.tabC, this.tabD });

            // ══════════════════════════════════════════════════════════
            // DATA GRID VIEW
            // ══════════════════════════════════════════════════════════
            this.dgvConnected.Location = new System.Drawing.Point(8, 200);
            this.dgvConnected.Size = new System.Drawing.Size(860, 240);
            this.dgvConnected.ReadOnly = true;
            this.dgvConnected.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConnected.BackgroundColor = System.Drawing.Color.White;
            this.dgvConnected.RowHeadersWidth = 24;
            this.dgvConnected.EnableHeadersVisualStyles = false;
            this.dgvConnected.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(0, 80, 160);
            this.dgvConnected.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.White;
            this.dgvConnected.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);

            // ══════════════════════════════════════════════════════════
            // STATUS LABEL
            // ══════════════════════════════════════════════════════════
            this.lblConnectedStatus.Location = new System.Drawing.Point(8, 448);
            this.lblConnectedStatus.Size = new System.Drawing.Size(860, 22);
            this.lblConnectedStatus.Font =
                new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);

            // ══════════════════════════════════════════════════════════
            // FORM
            // ══════════════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(7f, 15f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 480);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.tabControl1, this.dgvConnected, this.lblConnectedStatus });
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "7aDaRNI – Connected Mode (ODP.Net)";
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 248);

            this.tabControl1.ResumeLayout(false);
            this.tabA.ResumeLayout(false);
            this.tabA.PerformLayout();
            this.tabB.ResumeLayout(false);
            this.tabB.PerformLayout();
            this.tabC.ResumeLayout(false);
            this.tabC.PerformLayout();
            this.tabD.ResumeLayout(false);
            this.tabD.PerformLayout();
            this.pnlResult.ResumeLayout(false);
            this.pnlResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvConnected).EndInit();
            this.ResumeLayout(false);
        }

        // ── Field declarations ────────────────────────────────────────
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabA, tabB, tabC, tabD;
        private System.Windows.Forms.Label lblInsStudentId, lblInsCourseId, lblInsTeacherId;
        private System.Windows.Forms.Label lblInsDate, lblInsStatus, lblInsHint;
        private System.Windows.Forms.TextBox txtInsStudentId, txtInsCourseId, txtInsTeacherId;
        private System.Windows.Forms.DateTimePicker dtpInsDate;
        private System.Windows.Forms.ComboBox cmbInsStatus;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Label lblSelCourseId, lblSelDate, lblSelHint;
        private System.Windows.Forms.TextBox txtSelCourseId;
        private System.Windows.Forms.DateTimePicker dtpSelDate;
        private System.Windows.Forms.Button btnSelectRows;
        private System.Windows.Forms.Label lblSpTeacherId, lblSpHint;
        private System.Windows.Forms.TextBox txtSpTeacherId;
        private System.Windows.Forms.Button btnSpMultiRow;
        private System.Windows.Forms.Label lblSpStudentId, lblSpCourseId, lblSpHint2;
        private System.Windows.Forms.TextBox txtSpStudentId, txtSpCourseId;
        private System.Windows.Forms.Button btnSpSingleRow;
        private System.Windows.Forms.Panel pnlResult;
        private System.Windows.Forms.Label lblRAbsTitle, lblResultAbsences;
        private System.Windows.Forms.Label lblRSessTitle, lblResultSessions;
        private System.Windows.Forms.Label lblRPctTitle, lblResultPct;
        private System.Windows.Forms.Label lblRRiskTitle, lblResultRisk;
        private System.Windows.Forms.DataGridView dgvConnected;
        private System.Windows.Forms.Label lblConnectedStatus;
    }
}