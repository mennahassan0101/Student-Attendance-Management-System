// ============================================================
// DisconnectedModeForm.Designer.cs  –  7aDaRNI Disconnected Mode
// All controls created inline - no helper methods (required by VS Designer)
// ============================================================
namespace _7aDaRNI
{
    partial class DisconnectedModeForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabEnroll = new System.Windows.Forms.TabPage();
            this.tabManage = new System.Windows.Forms.TabPage();

            // Tab A – Enroll controls
            this.lblEnrollStudentId = new System.Windows.Forms.Label();
            this.txtEnrollStudentId = new System.Windows.Forms.TextBox();
            this.lblEnrollCourseId = new System.Windows.Forms.Label();
            this.txtEnrollCourseId = new System.Windows.Forms.TextBox();
            this.btnEnroll = new System.Windows.Forms.Button();
            this.lblEnrollHint = new System.Windows.Forms.Label();

            // Tab B – Manage controls
            this.lblSearchName = new System.Windows.Forms.Label();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExpel = new System.Windows.Forms.Button();
            this.btnToggle = new System.Windows.Forms.Button();
            this.lblManageHint = new System.Windows.Forms.Label();

            // Shared
            this.dgvDisconnected = new System.Windows.Forms.DataGridView();
            this.lblDisconnectedStatus = new System.Windows.Forms.Label();

            this.tabControl.SuspendLayout();
            this.tabEnroll.SuspendLayout();
            this.tabManage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvDisconnected).BeginInit();
            this.SuspendLayout();

            // ══════════════════════════════════════════════════════════
            // TAB A  – Enroll Student
            // ══════════════════════════════════════════════════════════
            this.tabEnroll.Text = "A) Enroll Student (FR-4)";
            this.tabEnroll.Padding = new System.Windows.Forms.Padding(8);
            this.tabEnroll.UseVisualStyleBackColor = true;

            this.lblEnrollStudentId.Text = "Student ID:";
            this.lblEnrollStudentId.AutoSize = true;
            this.lblEnrollStudentId.Location = new System.Drawing.Point(10, 20);
            this.lblEnrollStudentId.Font = new System.Drawing.Font("Segoe UI", 9f);

            this.txtEnrollStudentId.Location = new System.Drawing.Point(90, 17);
            this.txtEnrollStudentId.Width = 90;

            this.lblEnrollCourseId.Text = "Course ID:";
            this.lblEnrollCourseId.AutoSize = true;
            this.lblEnrollCourseId.Location = new System.Drawing.Point(200, 20);
            this.lblEnrollCourseId.Font = new System.Drawing.Font("Segoe UI", 9f);

            this.txtEnrollCourseId.Location = new System.Drawing.Point(280, 17);
            this.txtEnrollCourseId.Width = 90;

            this.btnEnroll.Text = "Enroll Student";
            this.btnEnroll.Location = new System.Drawing.Point(10, 55);
            this.btnEnroll.Size = new System.Drawing.Size(140, 30);
            this.btnEnroll.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnEnroll.ForeColor = System.Drawing.Color.White;
            this.btnEnroll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnroll.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);

            this.lblEnrollHint.Text = "FR-4: Enroll in Course | Disconnected mode INSERT via DataSet + OracleDataAdapter.Update()";
            this.lblEnrollHint.AutoSize = true;
            this.lblEnrollHint.Location = new System.Drawing.Point(10, 95);
            this.lblEnrollHint.Font = new System.Drawing.Font("Segoe UI", 8.5f, System.Drawing.FontStyle.Italic);
            this.lblEnrollHint.ForeColor = System.Drawing.Color.FromArgb(0, 100, 180);

            this.tabEnroll.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblEnrollStudentId, this.txtEnrollStudentId,
                this.lblEnrollCourseId,  this.txtEnrollCourseId,
                this.btnEnroll,          this.lblEnrollHint });

            // ══════════════════════════════════════════════════════════
            // TAB B  – Manage Students
            // ══════════════════════════════════════════════════════════
            this.tabManage.Text = "B) Manage Students (FR-7 / Admin)";
            this.tabManage.Padding = new System.Windows.Forms.Padding(8);
            this.tabManage.UseVisualStyleBackColor = true;

            this.lblSearchName.Text = "Search by Name:";
            this.lblSearchName.AutoSize = true;
            this.lblSearchName.Location = new System.Drawing.Point(10, 20);
            this.lblSearchName.Font = new System.Drawing.Font("Segoe UI", 9f);

            this.txtSearchName.Location = new System.Drawing.Point(115, 17);
            this.txtSearchName.Width = 200;

            this.btnSearch.Text = "Load / Search";
            this.btnSearch.Location = new System.Drawing.Point(330, 15);
            this.btnSearch.Size = new System.Drawing.Size(115, 28);
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 8.5f, System.Drawing.FontStyle.Bold);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            this.btnSave.Text = "Save Changes";
            this.btnSave.Location = new System.Drawing.Point(460, 15);
            this.btnSave.Size = new System.Drawing.Size(115, 28);
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(0, 140, 60);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 8.5f, System.Drawing.FontStyle.Bold);
            this.btnSave.Enabled = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnExpel.Text = "Expel Student";
            this.btnExpel.Location = new System.Drawing.Point(590, 15);
            this.btnExpel.Size = new System.Drawing.Size(115, 28);
            this.btnExpel.BackColor = System.Drawing.Color.FromArgb(180, 30, 30);
            this.btnExpel.ForeColor = System.Drawing.Color.White;
            this.btnExpel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpel.Font = new System.Drawing.Font("Segoe UI", 8.5f, System.Drawing.FontStyle.Bold);
            this.btnExpel.Click += new System.EventHandler(this.btnExpel_Click);

            this.btnToggle.Text = "Toggle Active";
            this.btnToggle.Location = new System.Drawing.Point(720, 15);
            this.btnToggle.Size = new System.Drawing.Size(110, 28);
            this.btnToggle.BackColor = System.Drawing.Color.FromArgb(160, 90, 0);
            this.btnToggle.ForeColor = System.Drawing.Color.White;
            this.btnToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggle.Font = new System.Drawing.Font("Segoe UI", 8.5f, System.Drawing.FontStyle.Bold);
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);

            this.lblManageHint.Text = "Admin: Manage Students | FR-7: Expel | Phase 2 B.1 (Search by name) + B.2 (OracleCommandBuilder Update)";
            this.lblManageHint.AutoSize = true;
            this.lblManageHint.Location = new System.Drawing.Point(10, 55);
            this.lblManageHint.Font = new System.Drawing.Font("Segoe UI", 8.5f, System.Drawing.FontStyle.Italic);
            this.lblManageHint.ForeColor = System.Drawing.Color.FromArgb(0, 100, 180);

            this.tabManage.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblSearchName, this.txtSearchName,
                this.btnSearch, this.btnSave, this.btnExpel, this.btnToggle,
                this.lblManageHint });

            // ══════════════════════════════════════════════════════════
            // TAB CONTROL
            // ══════════════════════════════════════════════════════════
            this.tabControl.Location = new System.Drawing.Point(8, 8);
            this.tabControl.Size = new System.Drawing.Size(860, 140);
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.tabControl.TabPages.AddRange(new System.Windows.Forms.TabPage[] {
                this.tabEnroll, this.tabManage });

            // ══════════════════════════════════════════════════════════
            // DATA GRID VIEW
            // ══════════════════════════════════════════════════════════
            this.dgvDisconnected.Location = new System.Drawing.Point(8, 155);
            this.dgvDisconnected.Size = new System.Drawing.Size(860, 280);
            this.dgvDisconnected.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDisconnected.BackgroundColor = System.Drawing.Color.White;
            this.dgvDisconnected.EditMode =
                System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDisconnected.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDisconnected.RowHeadersWidth = 24;
            this.dgvDisconnected.EnableHeadersVisualStyles = false;
            this.dgvDisconnected.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(0, 80, 160);
            this.dgvDisconnected.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.White;
            this.dgvDisconnected.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.dgvDisconnected.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDisconnected_DataBindingComplete);


            // ══════════════════════════════════════════════════════════
            // STATUS LABEL
            // ══════════════════════════════════════════════════════════
            this.lblDisconnectedStatus.Location = new System.Drawing.Point(8, 442);
            this.lblDisconnectedStatus.Size = new System.Drawing.Size(860, 22);
            this.lblDisconnectedStatus.Font =
                new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);

            // ══════════════════════════════════════════════════════════
            // FORM
            // ══════════════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(7f, 15f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 475);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.tabControl, this.dgvDisconnected, this.lblDisconnectedStatus });
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "7aDaRNI – Disconnected Mode (ODP.Net)";
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 248);

            this.tabControl.ResumeLayout(false);
            this.tabEnroll.ResumeLayout(false);
            this.tabEnroll.PerformLayout();
            this.tabManage.ResumeLayout(false);
            this.tabManage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvDisconnected).EndInit();
            this.ResumeLayout(false);
        }

        // ── Field declarations ────────────────────────────────────────
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabEnroll, tabManage;
        private System.Windows.Forms.Label lblEnrollStudentId, lblEnrollCourseId, lblEnrollHint;
        private System.Windows.Forms.TextBox txtEnrollStudentId, txtEnrollCourseId;
        private System.Windows.Forms.Button btnEnroll;
        private System.Windows.Forms.Label lblSearchName, lblManageHint, lblDisconnectedStatus;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Button btnSearch, btnSave, btnExpel, btnToggle;
        private System.Windows.Forms.DataGridView dgvDisconnected;
    }
}