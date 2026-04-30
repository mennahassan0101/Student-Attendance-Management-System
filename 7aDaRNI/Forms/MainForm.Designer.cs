// ============================================================
// MainForm.Designer.cs  –  7aDaRNI Main Navigation Form
// ============================================================
namespace _7aDaRNI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogout_i = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSep_i = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit_i = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuForms = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConn_i = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDisc_i = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReports = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRpt1_i = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRpt2_i = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSub = new System.Windows.Forms.Label();
            this.pnlUserBar = new System.Windows.Forms.Panel();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.lblCards = new System.Windows.Forms.Label();

            this.menuStrip.SuspendLayout();
            this.SuspendLayout();

            // ── menuStrip ─────────────────────────────────────────────
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(15, 30, 60);
            this.menuStrip.ForeColor = System.Drawing.Color.White;
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
                { this.mnuFile, this.mnuForms, this.mnuReports });

            // File menu
            this.mnuFile.Text = "&File";
            this.mnuFile.ForeColor = System.Drawing.Color.White;
            this.mnuLogout_i.Text = "&Sign Out";
            this.mnuLogout_i.Click += new System.EventHandler(this.mnuLogout_Click);
            this.mnuExit_i.Text = "E&xit";
            this.mnuExit_i.Click += new System.EventHandler(this.mnuExit_Click);
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
                { this.mnuLogout_i, this.mnuSep_i, this.mnuExit_i });

            // Forms menu
            this.mnuForms.Text = "F&orms";
            this.mnuForms.ForeColor = System.Drawing.Color.White;
            this.mnuConn_i.Text = "&Connected Mode  (Mark / View Attendance)";
            this.mnuConn_i.Click += new System.EventHandler(this.mnuConnected_Click);
            this.mnuDisc_i.Text = "&Disconnected Mode  (Enroll / Manage Students)";
            this.mnuDisc_i.Click += new System.EventHandler(this.mnuDisconnected_Click);
            this.mnuForms.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
                { this.mnuConn_i, this.mnuDisc_i });

            // Reports menu
            this.mnuReports.Text = "&Reports";
            this.mnuReports.ForeColor = System.Drawing.Color.White;
            this.mnuRpt1_i.Text = "Report 1 - &Attendance by Course  (grouped + formula)";
            this.mnuRpt1_i.Click += new System.EventHandler(this.mnuReport1_Click);
            this.mnuRpt2_i.Text = "Report 2 - &Student Attendance Summary  (summarized + parameter)";
            this.mnuRpt2_i.Click += new System.EventHandler(this.mnuReport2_Click);
            this.mnuReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
                { this.mnuRpt1_i, this.mnuRpt2_i });

            // ── Header panel ──────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(0, 100, 190);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 90;

            this.lblTitle.Text = "7aDaRNI – Student Attendance Management System";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 17f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(18, 12);

            this.lblSub.Text = "Team 44  ·  Supervisor TA: Alaa Khaled  ·  Phase 2 Implementation";
            this.lblSub.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.lblSub.ForeColor = System.Drawing.Color.FromArgb(200, 225, 255);
            this.lblSub.AutoSize = true;
            this.lblSub.Location = new System.Drawing.Point(20, 54);

            this.pnlHeader.Controls.AddRange(new System.Windows.Forms.Control[]
                { this.lblTitle, this.lblSub });

            // ── User info bar (shows logged-in user + role) ───────────
            this.pnlUserBar.BackColor = System.Drawing.Color.FromArgb(230, 240, 255);
            this.pnlUserBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUserBar.Height = 32;
            this.pnlUserBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblUserInfo.Text = "Loading...";
            this.lblUserInfo.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblUserInfo.ForeColor = System.Drawing.Color.FromArgb(0, 60, 130);
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Location = new System.Drawing.Point(12, 7);

            this.pnlUserBar.Controls.Add(this.lblUserInfo);

            // ── Navigation info label ─────────────────────────────────
            this.lblCards.Text =
                "Use the menu bar above to navigate:\r\n\r\n" +
                "  Forms  →  Connected Mode          Mark Attendance (FR-1)  ·  View Attendance (FR-2)  ·  View Courses (FR-5)  ·  Absence Report\r\n" +
                "  Forms  →  Disconnected Mode       Enroll Student (FR-4)   ·  Manage / Expel Students (FR-7 / Admin only)\r\n" +
                "  Reports → Report 1                Attendance by Course — grouped columns, formula field, parameter\r\n" +
                "  Reports → Report 2                Student Summary — summarized columns, summary field, parameter\r\n\r\n" +
                "  Grayed-out items are restricted based on your role.";
            this.lblCards.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.lblCards.ForeColor = System.Drawing.Color.FromArgb(40, 40, 60);
            this.lblCards.Location = new System.Drawing.Point(24, 148);
            this.lblCards.Size = new System.Drawing.Size(870, 160);

            // ── Form ──────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7f, 15f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 360);
            this.Controls.AddRange(new System.Windows.Forms.Control[]
                { this.lblCards, this.pnlUserBar, this.pnlHeader, this.menuStrip });
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(940, 400);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "7aDaRNI – Main Menu";
            this.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);

            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuFile, mnuLogout_i, mnuExit_i;
        private System.Windows.Forms.ToolStripSeparator mnuSep_i;
        private System.Windows.Forms.ToolStripMenuItem mnuForms, mnuConn_i, mnuDisc_i;
        private System.Windows.Forms.ToolStripMenuItem mnuReports, mnuRpt1_i, mnuRpt2_i;
        private System.Windows.Forms.Panel pnlHeader, pnlUserBar;
        private System.Windows.Forms.Label lblTitle, lblSub, lblUserInfo, lblCards;
    }
}