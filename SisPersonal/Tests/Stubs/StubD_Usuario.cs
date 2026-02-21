using CAD;
using CE;
using System;
using System.Data;

namespace Tests.Stubs
{
    public class StubD_Usuario : D_Usuario
    {
        public DataTable LoginResult { get; set; }
        public int GeneraCodigoResult { get; set; }
        public Exception ExceptionToThrow { get; set; }
        public bool ShouldThrowException { get; set; }

        public int LoginCallCount { get; private set; }
        public int GeneraCodigoCallCount { get; private set; }
        public int NuevoRegistroCallCount { get; private set; }
        public int ListarUsuariosCallCount { get; private set; }
        public int ListarTodosUsuariosCallCount { get; private set; }
        public int ActualizarRegistroCallCount { get; private set; }
        public int EliminarRegistroCallCount { get; private set; }

        public E_Usuario LastUsuarioParameter { get; private set; }
        public string LastAccionParameter { get; private set; }

        public StubD_Usuario()
        {
            // Configuración por defecto
            LoginResult = new DataTable();
            GeneraCodigoResult = 1;
            ShouldThrowException = false;
        }

        public override DataTable Login(E_Usuario objUsuario)
        {
            LoginCallCount++;
            LastUsuarioParameter = objUsuario;

            if (ShouldThrowException && ExceptionToThrow != null)
                throw ExceptionToThrow;

            return LoginResult;
        }

        public override int generaCodigo()
        {
            GeneraCodigoCallCount++;

            if (ShouldThrowException && ExceptionToThrow != null)
                throw ExceptionToThrow;

            return GeneraCodigoResult;
        }

        public override void nuevoRegistro(E_Usuario objUsuario, string accion)
        {
            NuevoRegistroCallCount++;
            LastUsuarioParameter = objUsuario;
            LastAccionParameter = accion;

            if (ShouldThrowException && ExceptionToThrow != null)
                throw ExceptionToThrow;
        }

        public override DataTable listarUsuarios()
        {
            ListarUsuariosCallCount++;

            if (ShouldThrowException && ExceptionToThrow != null)
                throw ExceptionToThrow;

            return LoginResult; // Reutilizamos el mismo DataTable para simplicidad
        }

        public override DataTable listarTodosUsuarios()
        {
            ListarTodosUsuariosCallCount++;

            if (ShouldThrowException && ExceptionToThrow != null)
                throw ExceptionToThrow;

            return LoginResult; // Reutilizamos el mismo DataTable para simplicidad
        }

        public override void actualizarRegistro(E_Usuario objUsuario, string accion)
        {
            ActualizarRegistroCallCount++;
            LastUsuarioParameter = objUsuario;
            LastAccionParameter = accion;

            if (ShouldThrowException && ExceptionToThrow != null)
                throw ExceptionToThrow;
        }

        public override void eliminarRegistro(E_Usuario objUsuario, string accion)
        {
            EliminarRegistroCallCount++;
            LastUsuarioParameter = objUsuario;
            LastAccionParameter = accion;

            if (ShouldThrowException && ExceptionToThrow != null)
                throw ExceptionToThrow;
        }
    }
}