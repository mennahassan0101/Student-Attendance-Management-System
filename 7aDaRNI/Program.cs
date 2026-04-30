// ============================================================
// Program.cs  –  7aDaRNI Application Entry Point
//
// Auth flow (matches SRS Sequence Diagram):
//   1. LoginForm shown first (SYS_Interface)
//   2. Credentials sent to USERS table (Course Database)
//   3. Auth component validates → OK or FAIL
//   4. On OK  → MainForm opens with role-based menus
//   5. On FAIL → login form stays, error shown, max 3 attempts
// ============================================================
using System;
using System.Windows.Forms;

namespace _7aDaRNI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ── Step 1: Show Login (SYS_Interface → Auth) ──
            using var login = new LoginForm();
            if (login.ShowDialog() != DialogResult.OK)
            {
                // User cancelled or max attempts reached → exit
                return;
            }

            // ── Step 2: Authorization OK → open Main Form ──
            Application.Run(new MainForm());
        }
    }
}