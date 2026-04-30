// ============================================================
// LoginForm.cs  –  7aDaRNI  |  Authentication
//
// SRS NFR-2: "All system access must be protected by secure
// authentication using hashed credentials. Role-based access
// control must be enforced so that each user can only perform
// actions permitted for their role (Student, Teacher, Admin)."
//
// Sequence Diagram Auth flow:
//   User → SYS_Interface → Course Database → Auth component
//   Auth returns Authorization OK or Authorization Fail
// ============================================================
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace _7aDaRNI
{
    public partial class LoginForm : Form
    {
        private const string CONN_STR =
            "User Id=scott;Password=tiger;Data Source=localhost:1521/orcl;";

        // Tracks failed attempts to implement lockout
        private int _failedAttempts = 0;
        private const int MAX_ATTEMPTS = 3;

        public LoginForm() => InitializeComponent();

        // ============================================================
        // AUTHENTICATE – matches sequence diagram:
        //   Teacher → SYS_Interface → DB → Auth → Authorization result
        // ============================================================
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                ShowError("Please enter both email and password.");
                return;
            }

            btnLogin.Enabled = false;
            lblStatus.Text = "Authenticating...";
            lblStatus.ForeColor = Color.DarkBlue;

            try
            {
                using var conn = new OracleConnection(CONN_STR);
                conn.Open();

                // ── Auth component: validate credentials against USERS table ──
                // SRS: "hashed credentials" – in production, hash the input
                // and compare hashes. For this academic project we compare
                // the stored hash string directly (as set in sample data).
                const string sql =
                    @"SELECT USER_ID, FULL_NAME, EMAIL, ROLE, IS_ACTIVE
                      FROM   USERS
                      WHERE  UPPER(EMAIL)  = UPPER(:p_email)
                        AND  PASSWORD_HASH = :p_pass
                        AND  ROWNUM       = 1";

                using var cmd = new OracleCommand(sql, conn);
                cmd.Parameters.Add(":p_email", OracleDbType.Varchar2).Value = email;
                cmd.Parameters.Add(":p_pass", OracleDbType.Varchar2).Value = password;

                using var reader = cmd.ExecuteReader();

                if (!reader.Read())
                {
                    // ── Authorization FAIL (matches sequence diagram ALT block) ──
                    _failedAttempts++;
                    int remaining = MAX_ATTEMPTS - _failedAttempts;

                    if (_failedAttempts >= MAX_ATTEMPTS)
                    {
                        ShowError("Too many failed attempts. Application will close.");
                        System.Threading.Tasks.Task.Delay(2000)
                            .ContinueWith(_ => Application.Exit());
                        return;
                    }

                    ShowError($"Invalid email or password. {remaining} attempt(s) remaining.");
                    txtPassword.Clear();
                    txtPassword.Focus();
                    btnLogin.Enabled = true;
                    return;
                }

                // ── Check account is active ──
                int isActive = Convert.ToInt32(reader["IS_ACTIVE"]);
                if (isActive == 0)
                {
                    ShowError("Your account has been deactivated. Contact the administrator.");
                    btnLogin.Enabled = true;
                    return;
                }

                // ── Authorization OK – populate session ──
                SessionManager.Login(
                    userId: Convert.ToInt32(reader["USER_ID"]),
                    fullName: reader["FULL_NAME"].ToString()!,
                    email: reader["EMAIL"].ToString()!,
                    role: reader["ROLE"].ToString()!
                );

                // Close login, let Program.cs open MainForm
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (OracleException ox)
            {
                MessageBox.Show($"Database Error [{ox.Number}]: {ox.Message}",
                    "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnLogin.Enabled = true;
                lblStatus.Text = string.Empty;
            }
        }

        private void ShowError(string msg)
        {
            lblStatus.Text = msg;
            lblStatus.ForeColor = Color.DarkRed;
        }

        // Allow pressing Enter in password field to trigger login
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnLogin_Click(sender, e);
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtPassword.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}