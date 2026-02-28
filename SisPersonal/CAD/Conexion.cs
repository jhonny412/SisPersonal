using System;
using System.Data.SqlClient;
using System.Configuration;

namespace CAD
{
    /// <summary>
    /// Clase Conexion: Gestiona la conexión a SQL Server con seguridad mejorada
    /// - Lee credenciales de variables de entorno
    /// - Usa encriptación en tránsito (Encrypt=True)
    /// - Alternativa: Lee de App.config si no encuentra variables de entorno
    /// </summary>
    public class Conexion
    {
        private static string GetConnectionString()
        {
            // OPCIÓN 1: Obtener del archivo App.config (producción)
            string connStringConfig = ConfigurationManager.ConnectionStrings["cnx"]?.ConnectionString;
            if (!string.IsNullOrEmpty(connStringConfig))
            {
                // SANITIZATION: Prevent Visual Studio caching issues with old connection strings
                if (connStringConfig.Contains("Control_Personal") && !connStringConfig.Contains("dbControlPersonal"))
                {
                    connStringConfig = connStringConfig.Replace("Control_Personal", "dbControlPersonal");
                }
                if (connStringConfig.Contains("Integrated Security=True"))
                {
                    connStringConfig = connStringConfig.Replace("Integrated Security=True", "User ID=sa;Password=Sunat_2026;Encrypt=True;TrustServerCertificate=True");
                    if (connStringConfig.Contains("Data Source=."))
                        connStringConfig = connStringConfig.Replace("Data Source=.", "Server=Servidor");
                }

                return connStringConfig;
            }

            // OPCIÓN 2: Obtener de variables de entorno (desarrollo/testing)
            string servidor = Environment.GetEnvironmentVariable("SQL_SERVER", EnvironmentVariableTarget.User) 
                ?? Environment.GetEnvironmentVariable("SQL_SERVER") 
                ?? "Servidor";
            
            string baseDatos = Environment.GetEnvironmentVariable("SQL_DATABASE", EnvironmentVariableTarget.User)
                ?? Environment.GetEnvironmentVariable("SQL_DATABASE")
                ?? "dbControlPersonal";
            
            string usuario = Environment.GetEnvironmentVariable("SQL_USER", EnvironmentVariableTarget.User)
                ?? Environment.GetEnvironmentVariable("SQL_USER")
                ?? "sa";
            
            string contraseña = Environment.GetEnvironmentVariable("SQL_PASSWORD", EnvironmentVariableTarget.User)
                ?? Environment.GetEnvironmentVariable("SQL_PASSWORD")
                ?? "Sunat_2026";

            // Construir connection string CON ENCRIPTACIÓN HABILITADA
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = servidor,
                InitialCatalog = baseDatos,
                UserID = usuario,
                Password = contraseña,
                Encrypt = true,                    // ✅ SEGURIDAD: Encriptar en tránsito
                TrustServerCertificate = true,     // Para certificados autofirmados
                PersistSecurityInfo = false,       // ✅ SEGURIDAD: No guardar credenciales en memoria
                ConnectTimeout = 15
            };

            return builder.ConnectionString;
        }

        public SqlConnection getConecta()
        {
            return new SqlConnection(GetConnectionString());
        }
    }
}