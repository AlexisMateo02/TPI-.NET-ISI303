using DTOs;
using Microsoft.Win32;
using System.Security.Cryptography;
using System.Text;

namespace Academia.WindowsForms.Helpers
{
    public class SessionManager
    {
        private const string RegKey = @"Software\AcademiaApp\Session";
        private static readonly byte[] _entropy = Encoding.UTF8.GetBytes("AcademiaAppSalt");

        // Sobrecarga para LoginResponse
        public static void SaveSession(LoginResponse loginResponse)
        {
            SaveSession(loginResponse.Token, loginResponse.NombreUsuario, loginResponse.ExpiresAt);
        }

        // Sobrecarga para parámetros individuales
        public static void SaveSession(string token, string username, DateTime expiry)
        {
            try
            {
                using var key = Registry.CurrentUser.CreateSubKey(RegKey);
                var sessionData = $"{token}|{expiry:o}|{username}";
                var encryptedData = Protect(sessionData);
                key.SetValue("SessionData", encryptedData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error guardando sesión: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static (string? token, DateTime? expiry, string? username) LoadSession()
        {
            try
            {
                using var key = Registry.CurrentUser.OpenSubKey(RegKey);
                if (key?.GetValue("SessionData") is byte[] encryptedData)
                {
                    var sessionData = Unprotect(encryptedData);
                    var parts = sessionData.Split('|');

                    if (parts.Length == 3 && DateTime.TryParse(parts[1], out var expiry) && expiry > DateTime.Now)
                    {
                        return (parts[0], expiry, parts[2]);
                    }
                }
            }
            catch { }

            return (null, null, null);
        }

        public static void ClearSession()
        {
            try
            {
                Registry.CurrentUser.DeleteSubKeyTree(RegKey, false);
            }
            catch { }
        }

        private static byte[] Protect(string data)
        {
            var bytes = Encoding.UTF8.GetBytes(data);
            return ProtectedData.Protect(bytes, _entropy, DataProtectionScope.CurrentUser);
        }

        private static string Unprotect(byte[] data)
        {
            var bytes = ProtectedData.Unprotect(data, _entropy, DataProtectionScope.CurrentUser);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}