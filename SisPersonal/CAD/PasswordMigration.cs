using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace CAD
{
    /// <summary>
    /// Clase PasswordMigration: Herramienta para migrar contraseñas a hash seguro
    /// - Lee contraseñas en texto plano de la BD
    /// - Las convierte a hash PBKDF2
    /// - Las guarda de vuelta en la BD
    /// 
    /// NOTA: Esta clase solo se debe usar UNA VEZ para migrar contraseñas existentes
    /// Después de ejecutar, todas las contraseñas estarán hasheadas
    /// </summary>
    public class PasswordMigration
    {
        private Conexion objCon = new Conexion();
        private const int HASH_ITERATIONS = 10000;
        private const int SALT_SIZE = 16;
        private const int HASH_SIZE = 32;

        /// <summary>
        /// Genera un hash seguro (duplicado de SecurityHelper para evitar referencias circulares)
        /// </summary>
        private string HashContraseña(string contraseña)
        {
            if (string.IsNullOrEmpty(contraseña))
                throw new ArgumentException("La contraseña no puede estar vacía");

            byte[] salt = new byte[SALT_SIZE];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            using (var pbkdf2 = new Rfc2898DeriveBytes(contraseña, salt, HASH_ITERATIONS, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(HASH_SIZE);
                byte[] hashWithSalt = new byte[SALT_SIZE + HASH_SIZE];
                Array.Copy(salt, 0, hashWithSalt, 0, SALT_SIZE);
                Array.Copy(hash, 0, hashWithSalt, SALT_SIZE, HASH_SIZE);
                return Convert.ToBase64String(hashWithSalt);
            }
        }

        /// <summary>
        /// Ejecuta la migración de contraseñas a hash
        /// ADVERTENCIA: Ejecute esto solo una vez en la BD
        /// </summary>
        public void MigrarContraseñasAHash()
        {
            SqlConnection cnx = null;
            try
            {
                cnx = objCon.getConecta();
                cnx.Open();

                // Obtener todas las contraseñas actuales
                string query = "SELECT IdUsuario, Clave FROM Usuarios";
                SqlCommand cmd = new SqlCommand(query, cnx);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Procesar cada usuario
                foreach (DataRow row in dt.Rows)
                {
                    int idUsuario = Convert.ToInt32(row["IdUsuario"]);
                    string claveActual = row["Clave"].ToString().Trim();

                    // Generar hash
                    string claveHash = HashContraseña(claveActual);

                    // Actualizar en BD
                    string updateQuery = "UPDATE Usuarios SET Clave = @Clave WHERE IdUsuario = @IdUsuario";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, cnx);
                    updateCmd.Parameters.AddWithValue("@Clave", claveHash);
                    updateCmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    updateCmd.ExecuteNonQuery();

                    System.Diagnostics.Debug.WriteLine($"Usuario ID {idUsuario}: Contraseña migrada a hash");
                }

                Console.WriteLine($"✓ Migración completada: {dt.Rows.Count} usuarios procesados");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en migración de contraseñas: {ex.Message}");
            }
            finally
            {
                if (cnx != null && cnx.State == ConnectionState.Open)
                    cnx.Close();
            }
        }

        /// <summary>
        /// Verifica el estado de la migración
        /// Retorna cuántas contraseñas aún están en texto plano
        /// </summary>
        public int VerificarEstadoMigracion()
        {
            SqlConnection cnx = null;
            try
            {
                cnx = objCon.getConecta();
                cnx.Open();

                // Las contraseñas hasheadas en Base64 son más largas (68-80 caracteres típicamente)
                // Las contraseñas en texto plano son máximo 25 caracteres
                string query = @"
                    SELECT COUNT(*) as ContraseñasPlanas 
                    FROM Usuarios 
                    WHERE LEN(Clave) < 50";  

                SqlCommand cmd = new SqlCommand(query, cnx);
                int contrasenasPlanas = Convert.ToInt32(cmd.ExecuteScalar());

                return contrasenasPlanas;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error verificando estado: {ex.Message}");
            }
            finally
            {
                if (cnx != null && cnx.State == ConnectionState.Open)
                    cnx.Close();
            }
        }
    }
}
