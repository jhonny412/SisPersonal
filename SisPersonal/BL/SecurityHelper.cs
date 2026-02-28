using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace BL
{
    /// <summary>
    /// Clase SecurityHelper: Contiene funciones de seguridad para autenticación
    /// - Hash de contraseñas con PBKDF2
    /// - Validación de complejidad
    /// - Generación de salt
    /// </summary>
    public static class SecurityHelper
    {
        // Configuración de PBKDF2
        private const int HASH_ITERATIONS = 10000;  // Iteraciones de hash
        private const int SALT_SIZE = 16;           // Tamaño del salt en bytes
        private const int HASH_SIZE = 32;           // Tamaño del hash en bytes

        /// <summary>
        /// Genera un hash seguro de una contraseña usando PBKDF2 + Salt
        /// </summary>
        /// <param name="contraseña">Contraseña en texto plano</param>
        /// <returns>Hash + Salt en formato Base64</returns>
        public static string HashContraseña(string contraseña)
        {
            if (string.IsNullOrEmpty(contraseña))
                throw new ArgumentException("La contraseña no puede estar vacía");

            // Generar salt aleatorio
            byte[] salt = new byte[SALT_SIZE];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            // Generar hash PBKDF2
            using (var pbkdf2 = new Rfc2898DeriveBytes(contraseña, salt, HASH_ITERATIONS, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(HASH_SIZE);

                // Combinar salt + hash
                byte[] hashWithSalt = new byte[SALT_SIZE + HASH_SIZE];
                Array.Copy(salt, 0, hashWithSalt, 0, SALT_SIZE);
                Array.Copy(hash, 0, hashWithSalt, SALT_SIZE, HASH_SIZE);

                // Retornar en Base64
                return Convert.ToBase64String(hashWithSalt);
            }
        }

        /// <summary>
        /// Verifica si una contraseña coincide con su hash
        /// </summary>
        /// <param name="contraseña">Contraseña en texto plano</param>
        /// <param name="hashGuardado">Hash almacenado en BD</param>
        /// <returns>True si la contraseña es correcta, False si no</returns>
        public static bool VerificarContraseña(string contraseña, string hashGuardado)
        {
            if (string.IsNullOrEmpty(contraseña) || string.IsNullOrEmpty(hashGuardado))
                return false;

            hashGuardado = hashGuardado.TrimEnd();

            // Un hash PBKDF2 válido (16 bytes salt + 32 bytes hash = 48 bytes) 
            // tendrá exactamente 64 caracteres en Base64.
            // Si la longitud es diferente (probablemente es una contraseña antigua 
            // no migrada o texto plano corto), se compara de forma directa.
            if (hashGuardado.Length != 64)
            {
                return contraseña == hashGuardado;
            }

            try
            {
                // Decodificar el hash almacenado
                byte[] hashWithSalt = Convert.FromBase64String(hashGuardado);

                // Extraer el salt
                byte[] salt = new byte[SALT_SIZE];
                Array.Copy(hashWithSalt, 0, salt, 0, SALT_SIZE);

                // Generar hash con la contraseña ingresada y el salt almacenado
                using (var pbkdf2 = new Rfc2898DeriveBytes(contraseña, salt, HASH_ITERATIONS, HashAlgorithmName.SHA256))
                {
                    byte[] hash = pbkdf2.GetBytes(HASH_SIZE);

                    // Comparar hashes
                    for (int i = 0; i < HASH_SIZE; i++)
                    {
                        if (hashWithSalt[i + SALT_SIZE] != hash[i])
                        {
                            return contraseña == hashGuardado;
                        }
                    }
                    return true;
                }
            }
            catch (Exception)
            {
                return contraseña == hashGuardado;
            }
        }

        /// <summary>
        /// Valida la complejidad de una contraseña
        /// Requisitos:
        /// - Mínimo 8 caracteres
        /// - Debe contener al menos una mayúscula
        /// - Debe contener al menos una minúscula
        /// - Debe contener al menos un número
        /// - Debe contener al menos un carácter especial
        /// </summary>
        /// <param name="contraseña">Contraseña a validar</param>
        /// <returns>Tupla (EsValida, Mensaje)</returns>
        public static (bool EsValida, string Mensaje) ValidarComplejidadContraseña(string contraseña)
        {
            if (string.IsNullOrEmpty(contraseña))
                return (false, "La contraseña no puede estar vacía");

            StringBuilder mensaje = new StringBuilder();
            bool esValida = true;

            // Validar longitud mínima
            if (contraseña.Length < 8)
            {
                mensaje.AppendLine("- Mínimo 8 caracteres");
                esValida = false;
            }

            // Validar mayúscula
            if (!Regex.IsMatch(contraseña, @"[A-Z]"))
            {
                mensaje.AppendLine("- Debe contener al menos una mayúscula (A-Z)");
                esValida = false;
            }

            // Validar minúscula
            if (!Regex.IsMatch(contraseña, @"[a-z]"))
            {
                mensaje.AppendLine("- Debe contener al menos una minúscula (a-z)");
                esValida = false;
            }

            // Validar número
            if (!Regex.IsMatch(contraseña, @"[0-9]"))
            {
                mensaje.AppendLine("- Debe contener al menos un número (0-9)");
                esValida = false;
            }

            // Validar carácter especial
            if (!Regex.IsMatch(contraseña, @"[!@#$%^&*()_+\-=\[\]{};:'\"",.<>?/\\|`~]"))
            {
                mensaje.AppendLine("- Debe contener al menos un carácter especial (!@#$%^&*)");
                esValida = false;
            }

            string mensajeCompleto = esValida ? "Contraseña válida" : "Contraseña débil:\n" + mensaje.ToString();
            return (esValida, mensajeCompleto);
        }

        /// <summary>
        /// Valida la complejidad en modo "leniente" para compatibilidad con contraseñas existentes
        /// Solo requiere: mínimo 6 caracteres
        /// </summary>
        /// <param name="contraseña">Contraseña a validar</param>
        /// <returns>True si es válida, False si no</returns>
        public static bool ValidarComplejidadBasica(string contraseña)
        {
            if (string.IsNullOrEmpty(contraseña))
                return false;

            return contraseña.Length >= 6;
        }
    }
}
