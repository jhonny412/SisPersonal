using CE;
using System.Data;
using Tests.Interfaces;

namespace Tests.TestableClasses
{
    public class BL_Usuario_Testable
    {
        private readonly ID_Usuario _dUsuario;

        public BL_Usuario_Testable(ID_Usuario dUsuario)
        {
            _dUsuario = dUsuario;
        }

        public DataTable Login(E_Usuario objUsuario)
        {
            return _dUsuario.Login(objUsuario);
        }

        public int generarCodigo()
        {
            return _dUsuario.generaCodigo();
        }

        public void nuevoRegistro(E_Usuario objUsuario, string accion)
        {
            _dUsuario.nuevoRegistro(objUsuario, accion);
        }

        public DataTable listarUsuarios()
        {
            return _dUsuario.listarUsuarios();
        }

        public DataTable listarTodosUsuarios()
        {
            return _dUsuario.listarTodosUsuarios();
        }

        public void actualizarRegistro(E_Usuario objUsuario, string accion)
        {
            _dUsuario.actualizarRegistro(objUsuario, accion);
        }

        public void eliminarRegistro(E_Usuario objUsuario, string accion)
        {
            _dUsuario.eliminarRegistro(objUsuario, accion);
        }
    }
}