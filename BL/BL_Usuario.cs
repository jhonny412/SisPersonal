using CAD;
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

        public DataTable Login(CE.E_Usuario objUsuario)
        {
            return objDUsuario.Login(objUsuario);
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