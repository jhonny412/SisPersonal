using System;
using System.IO;
using System.Text;

namespace BL
{
    /// <summary>
    /// Clase AuthenticationLogger: Registra intentos de autenticación
    /// - Guarda en archivo de log todos los intentos (exitosos y fallidos)
    /// - Información de auditoría: usuario, timestamp, IP, resultado
    /// </summary>
    public static class AuthenticationLogger
    {
        private static readonly string LogPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "SisPersonal",
            "Logs"
        );

        private static readonly object _lockObject = new object();

        static AuthenticationLogger()
        {
            // Crear directorio de logs si no existe
            if (!Directory.Exists(LogPath))
            {
                Directory.CreateDirectory(LogPath);
            }
        }

        /// <summary>
        /// Registra un intento de login exitoso
        /// </summary>
        /// <param name="usuario">Nombre de usuario</param>
        /// <param name="perfil">Perfil del usuario (Administrador/Empleado)</param>
        public static void RegistrarLoginExitoso(string usuario, string perfil)
        {
            RegistrarEvento("LOGIN_EXITOSO", usuario, perfil, "Autenticación correcta");
        }

        /// <summary>
        /// Registra un intento de login fallido
        /// </summary>
        /// <param name="usuario">Nombre de usuario</param>
        /// <param name="motivo">Motivo del fallo (contraseña incorrecta, usuario no existe, etc)</param>
        public static void RegistrarLoginFallido(string usuario, string motivo)
        {
            RegistrarEvento("LOGIN_FALLIDO", usuario, "N/A", motivo);
        }

        /// <summary>
        /// Registra un bloqueo por rate limiting
        /// </summary>
        /// <param name="usuario">Nombre de usuario</param>
        /// <param name="minutosRestantes">Minutos que falta para que se desbloquee</param>
        public static void RegistrarBloqueoRateLimit(string usuario, int minutosRestantes)
        {
            RegistrarEvento("RATE_LIMIT_BLOQUEADO", usuario, "N/A", 
                $"Usuario bloqueado por demasiados intentos fallidos. Minutos restantes: {minutosRestantes}");
        }

        /// <summary>
        /// Registra un cambio de contraseña
        /// </summary>
        /// <param name="usuario">Nombre de usuario</param>
        public static void RegistrarCambioContraseña(string usuario)
        {
            RegistrarEvento("CONTRASEÑA_CAMBIADA", usuario, "N/A", "Contraseña actualizada");
        }

        /// <summary>
        /// Registra un evento de seguridad genérico
        /// </summary>
        private static void RegistrarEvento(string tipo, string usuario, string perfil, string detalles)
        {
            lock (_lockObject)
            {
                try
                {
                    string nombreArchivo = Path.Combine(LogPath, $"auth_{DateTime.Now:yyyy-MM-dd}.log");

                    string entrada = string.Format(
                        "[{0:yyyy-MM-dd HH:mm:ss}] [{1}] Usuario: {2} | Perfil: {3} | Detalles: {4}{5}",
                        DateTime.Now,
                        tipo,
                        usuario ?? "DESCONOCIDO",
                        perfil,
                        detalles,
                        Environment.NewLine
                    );

                    File.AppendAllText(nombreArchivo, entrada, Encoding.UTF8);
                }
                catch (Exception ex)
                {
                    // Si falla el logging, no debe afectar la funcionalidad de la app
                    System.Diagnostics.Debug.WriteLine($"Error al registrar evento de autenticación: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Lee el archivo de log del día actual
        /// </summary>
        /// <returns>Contenido del archivo de log</returns>
        public static string ObtenerLogDelDia()
        {
            try
            {
                string nombreArchivo = Path.Combine(LogPath, $"auth_{DateTime.Now:yyyy-MM-dd}.log");
                if (File.Exists(nombreArchivo))
                {
                    return File.ReadAllText(nombreArchivo, Encoding.UTF8);
                }
                return "No hay registros para hoy";
            }
            catch (Exception ex)
            {
                return $"Error al leer logs: {ex.Message}";
            }
        }

        /// <summary>
        /// Obtiene información sobre archivos de log disponibles
        /// </summary>
        /// <returns>Lista de archivos de log</returns>
        public static string[] ObtenerArchivosLog()
        {
            try
            {
                if (Directory.Exists(LogPath))
                {
                    return Directory.GetFiles(LogPath, "auth_*.log");
                }
                return Array.Empty<string>();
            }
            catch
            {
                return Array.Empty<string>();
            }
        }
    }
}
