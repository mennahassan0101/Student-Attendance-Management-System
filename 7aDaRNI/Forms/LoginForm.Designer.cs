// ============================================================
// LoginForm.Designer.cs  –  7aDaRNI Login Form
// ============================================================
namespace _7aDaRNI
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.lblAppSub = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.lblLoginTitle = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblHint = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();

            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();

            // ── Header Panel ──────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(0, 100, 190);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 90;

            this.lblAppTitle.Text = "7aDaRNI";
            this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 22f, System.Drawing.FontStyle.Bold);
            this.lblAppTitle.ForeColor = System.Drawing.Color.White;
            this.lblAppTitle.AutoSize = true;
            this.lblAppTitle.Location = new System.Drawing.Point(24, 10);

            this.lblAppSub.Text = "Student Attendance Management System";
            this.lblAppSub.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.lblAppSub.ForeColor = System.Drawing.Color.FromArgb(200, 225, 255);
            this.lblAppSub.AutoSize = true;
            this.lblAppSub.Location = new System.Drawing.Point(26, 52);

            this.pnlHeader.Controls.AddRange(new System.Windows.Forms.Control[]
                { this.lblAppTitle, this.lblAppSub });

            // ── Body Panel ───────────────────────────────────────────
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(248, 249, 252);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Padding = new System.Windows.Forms.Padding(40, 20, 40, 20);

            // Login title
            this.lblLoginTitle.Text = "Sign in to your account";
            this.lblLoginTitle.Font = new System.Drawing.Font("Segoe UI", 13f, System.Drawing.FontStyle.Bold);
            this.lblLoginTitle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 60);
            this.lblLoginTitle.AutoSize = true;
            this.lblLoginTitle.Location = new System.Drawing.Point(40, 22);

            // Email
            this.lblEmail.Text = "Email address";
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(40, 65);

            this.txtEmail.Location = new System.Drawing.Point(40, 83);
            this.txtEmail.Size = new System.Drawing.Size(320, 28);
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10f);

            this.txtEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmail_KeyDown);

            // Password
            this.lblPassword.Text = "Password";
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(40, 125);

            this.txtPassword.Location = new System.Drawing.Point(40, 143);
            this.txtPassword.Size = new System.Drawing.Size(320, 28);
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.txtPassword.PasswordChar = '●';

            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);

            // Status label (errors / messages)
            this.lblStatus.Location = new System.Drawing.Point(40, 182);
            this.lblStatus.Size = new System.Drawing.Size(320, 36);
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.lblStatus.Text = string.Empty;

            // Login button
            this.btnLogin.Text = "Sign In";
            this.btnLogin.Location = new System.Drawing.Point(40, 225);
            this.btnLogin.Size = new System.Drawing.Size(150, 36);
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // Cancel button
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Location = new System.Drawing.Point(204, 225);
            this.btnCancel.Size = new System.Drawing.Size(100, 36);
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(230, 230, 235);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Hint – sample credentials for testing
            this.lblHint.Text =
                "Sample credentials:\r\n" +
                "Admin   :  admin@7adarni.edu  /  hashed_admin\r\n" +
                "Teacher :  ahmed@7adarni.edu  /  hashed_t1\r\n" +
                "Student :  sami@student.edu   /  hashed_s1";
            this.lblHint.Location = new System.Drawing.Point(40, 278);
            this.lblHint.Size = new System.Drawing.Size(320, 80);
            this.lblHint.Font = new System.Drawing.Font("Segoe UI", 8f);
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(120, 130, 160);
            this.lblHint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHint.BackColor = System.Drawing.Color.FromArgb(240, 244, 255);
            this.lblHint.Padding = new System.Windows.Forms.Padding(6);

            // Version
            this.lblVersion.Text = "Team 44  ·  Phase 2  ·  April 2026";
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 8f);
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(160, 165, 180);
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(40, 370);

            this.pnlBody.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblLoginTitle, this.lblEmail, this.txtEmail,
                this.lblPassword, this.txtPassword, this.lblStatus,
                this.btnLogin, this.btnCancel, this.lblHint, this.lblVersion });

            // ── Form ──────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7f, 15f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 490);
            this.Controls.AddRange(new System.Windows.Forms.Control[]
                { this.pnlBody, this.pnlHeader });
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "7aDaRNI – Sign In";
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 252);
            this.AcceptButton = this.btnLogin;
            this.CancelButton = this.btnCancel;

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader, pnlBody;
        private System.Windows.Forms.Label lblAppTitle, lblAppSub;
        private System.Windows.Forms.Label lblLoginTitle, lblEmail, lblPassword;
        private System.Windows.Forms.Label lblStatus, lblHint, lblVersion;
        private System.Windows.Forms.TextBox txtEmail, txtPassword;
        private System.Windows.Forms.Button btnLogin, btnCancel;
    }
}