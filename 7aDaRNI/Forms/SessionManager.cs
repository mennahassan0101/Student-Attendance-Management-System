// ============================================================
// SessionManager.cs  –  7aDaRNI
// Global static class that holds the currently logged-in user.
// Matches SRS NFR-2: Role-based access control enforced so that
// each user can only perform actions permitted for their role.
// ============================================================
namespace _7aDaRNI
{
    public static class SessionManager
    {
        public static int UserId { get; private set; }
        public static string FullName { get; private set; } = string.Empty;
        public static string Email { get; private set; } = string.Empty;
        public static string Role { get; private set; } = string.Empty;

        // Convenience role checks used by MainForm to enable/disable menus
        public static bool IsAdmin => Role == "ADMIN";
        public static bool IsTeacher => Role == "TEACHER";
        public static bool IsStudent => Role == "STUDENT";

        public static bool IsLoggedIn => !string.IsNullOrEmpty(Role);

        public static void Login(int userId, string fullName, string email, string role)
        {
            UserId = userId;
            FullName = fullName;
            Email = email;
            Role = role;
        }

        public static void Logout()
        {
            UserId = 0;
            FullName = string.Empty;
            Email = string.Empty;
            Role = string.Empty;
        }
    }
}