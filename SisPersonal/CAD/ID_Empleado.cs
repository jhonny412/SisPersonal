using CE;
using System.Data;

namespace CAD
{
    public interface ID_Empleado
    {
        DataTable buscarPersona(E_Empleado objEmpleado);
        DataTable GetEmpleado();
        int nuevoRegistro(E_Empleado objEmpleado);
        int actualizarRegistro(E_Empleado objEmpleado);
        int eliminarRegistro(string idEmpleado);
    }
}