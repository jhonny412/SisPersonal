using CAD;
using System;
using System.Data;

namespace BL
{
    public class BL_Usuario
    {
        private readonly ID_Usuario objDUsuario;

        // Constructor original para mantener compatibilidad
        public BL_Usuario() : this(new D_Usuario()) { }

        // Constructor para inyección de dependencias (para pruebas)
        public BL_Usuario(ID_Usuario dUsuario)
        {
            objDUsuario = dUsuario;
        }

        /// <summary>
        /// Login seguro: Verifica contraseña contra hash almacenado
        /// Implementa rate limiting y logging de auditoría
        /// </summary>
        public DataTable Login(CE.E_Usuario objUsuario)
        {
            // 1. RATE LIMITING: Verificar si el usuario está bloqueado
            var (estaBloqueado, minutosRestantes) = RateLimiter.VerificarBloqueo(objUsuario.Usuario);
            if (estaBloqueado)
            {
                AuthenticationLogger.RegistrarBloqueoRateLimit(objUsuario.Usuario, minutosRestantes);
                throw new Exception($"Cuenta bloqueada por demasiados intentos fallidos. Intente en {minutosRestantes} minutos.");
            }

            // 2. OBTENER HASH DE LA BD
            DataTable dtUsuario = objDUsuario.Login(objUsuario);

            // 3. VERIFICAR SI EL USUARIO EXISTE
            if (dtUsuario == null || dtUsuario.Rows.Count == 0)
            {
                RateLimiter.RegistrarIntentoFallido(objUsuario.Usuario);
                AuthenticationLogger.RegistrarLoginFallido(objUsuario.Usuario, "Usuario no encontrado");
                throw new Exception("Usuario o contraseña incorrectos");
            }

            // 4. OBTENER HASH GUARDADO
            string hashGuardado = dtUsuario.Rows[0]["Clave"].ToString();
            string perfil = dtUsuario.Rows[0]["Perfil"].ToString();

            // 5. VERIFICAR CONTRASEÑA CONTRA HASH
            bool contraseñaCorrecta = SecurityHelper.VerificarContraseña(objUsuario.Clave, hashGuardado);

            if (!contraseñaCorrecta)
            {
                // Contraseña incorrecta
                int intentosFallidos = RateLimiter.ObtenerIntentosFallidos(objUsuario.Usuario) + 1;
                RateLimiter.RegistrarIntentoFallido(objUsuario.Usuario);
                AuthenticationLogger.RegistrarLoginFallido(objUsuario.Usuario, $"Contraseña incorrecta (Intento {intentosFallidos}/{5})");
                
                throw new Exception($"Usuario o contraseña incorrectos. Intento {intentosFallidos} de 5");
            }

            // 6. LOGIN EXITOSO: Resetear intentos y registrar en log
            RateLimiter.ResetearIntentos(objUsuario.Usuario);
            AuthenticationLogger.RegistrarLoginExitoso(objUsuario.Usuario, perfil);

            return dtUsuario;
        }
        
        public int generarCodigo()
        {
            return objDUsuario.generaCodigo();
        }
        
        public void nuevoRegistro(CE.E_Usuario objUsuario, string acccion)
        {
            objDUsuario.nuevoRegistro(objUsuario, acccion);
        }
        
        public DataTable listarUsuarios()
        {
            return objDUsuario.listarUsuarios();
        }
        
        public DataTable listarTodosUsuarios()
        {
            return objDUsuario.listarTodosUsuarios();
        }
        
        public void actualizarRegistro(CE.E_Usuario objUsuario, string acccion)
        {
            objDUsuario.actualizarRegistro(objUsuario, acccion);
        }
        
        public void eliminarRegistro(CE.E_Usuario objUsuario, string acccion)
        {
            objDUsuario.eliminarRegistro(objUsuario, acccion);
        }
    }
}