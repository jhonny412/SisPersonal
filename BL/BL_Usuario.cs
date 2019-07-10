using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAD;
using CE;
using System.Data;

namespace BL
{
    public class BL_Usuario
    {
        D_Usuario objDUsuario = new D_Usuario();
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