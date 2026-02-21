using CE;
using System.Data;

namespace Tests.Interfaces
{
    public interface ID_Usuario
    {
        DataTable Login(E_Usuario objUsuario);
        int generaCodigo();
        void nuevoRegistro(E_Usuario objUsuario, string accion);
        DataTable listarUsuarios();
        DataTable listarTodosUsuarios();
        void actualizarRegistro(E_Usuario objUsuario, string accion);
        void eliminarRegistro(E_Usuario objUsuario, string accion);
    }
}