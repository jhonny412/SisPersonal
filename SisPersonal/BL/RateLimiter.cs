using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    /// <summary>
    /// Clase RateLimiter: Controla intentos fallidos de login
    /// - Máximo 5 intentos fallidos
    /// - Bloqueo de 15 minutos después de exceder límite
    /// - Reseteo de contador tras login exitoso
    /// </summary>
    public static class RateLimiter
    {
        private static Dictionary<string, LoginAttempt> _loginAttempts = new Dictionary<string, LoginAttempt>();
        private const int MAX_INTENTOS = 5;
        private const int BLOQUEO_MINUTOS = 15;

        private class LoginAttempt
        {
            public int IntentosFallidos { get; set; }
            public DateTime UltimoIntento { get; set; }
        }

        /// <summary>
        /// Verifica si un usuario está bloqueado por demasiados intentos fallidos
        /// </summary>
        /// <param name="usuario">Nombre de usuario</param>
        /// <returns>Tupla (EstaBloqueado, MinutosRestantes)</returns>
        public static (bool EstaBloqueado, int MinutosRestantes) VerificarBloqueo(string usuario)
        {
            if (!_loginAttempts.ContainsKey(usuario))
                return (false, 0);

            var intento = _loginAttempts[usuario];

            // Verificar si ha excedido el límite
            if (intento.IntentosFallidos >= MAX_INTENTOS)
            {
                // Calcular tiempo transcurrido
                TimeSpan tiempoTranscurrido = DateTime.Now - intento.UltimoIntento;
                int minutosRestantes = BLOQUEO_MINUTOS - (int)tiempoTranscurrido.TotalMinutes;

                // Si aún está dentro del período de bloqueo
                if (minutosRestantes > 0)
                {
                    return (true, minutosRestantes);
                }
                else
                {
                    // Resetear contador después del bloqueo
                    _loginAttempts[usuario].IntentosFallidos = 0;
                    return (false, 0);
                }
            }

            return (false, 0);
        }

        /// <summary>
        /// Registra un intento fallido de login
        /// </summary>
        /// <param name="usuario">Nombre de usuario</param>
        public static void RegistrarIntentoFallido(string usuario)
        {
            if (!_loginAttempts.ContainsKey(usuario))
            {
                _loginAttempts[usuario] = new LoginAttempt 
                { 
                    IntentosFallidos = 1, 
                    UltimoIntento = DateTime.Now 
                };
            }
            else
            {
                _loginAttempts[usuario].IntentosFallidos++;
                _loginAttempts[usuario].UltimoIntento = DateTime.Now;
            }
        }

        /// <summary>
        /// Resetea el contador de intentos fallidos para un usuario (login exitoso)
        /// </summary>
        /// <param name="usuario">Nombre de usuario</param>
        public static void ResetearIntentos(string usuario)
        {
            if (_loginAttempts.ContainsKey(usuario))
            {
                _loginAttempts.Remove(usuario);
            }
        }

        /// <summary>
        /// Obtiene el número de intentos fallidos para un usuario
        /// </summary>
        /// <param name="usuario">Nombre de usuario</param>
        /// <returns>Número de intentos fallidos</returns>
        public static int ObtenerIntentosFallidos(string usuario)
        {
            if (!_loginAttempts.ContainsKey(usuario))
                return 0;

            return _loginAttempts[usuario].IntentosFallidos;
        }

        /// <summary>
        /// Limpia intentos expirados (antiguos) para liberar memoria
        /// Se debe llamar periódicamente
        /// </summary>
        public static void LimpiarIntentosExpirados()
        {
            var usuariosExpirados = _loginAttempts
                .Where(x => DateTime.Now - x.Value.UltimoIntento > TimeSpan.FromMinutes(BLOQUEO_MINUTOS + 5))
                .Select(x => x.Key)
                .ToList();

            foreach (var usuario in usuariosExpirados)
            {
                _loginAttempts.Remove(usuario);
            }
        }
    }
}
