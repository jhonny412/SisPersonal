using CE;
using System.Data;

namespace Tests.Interfaces
{
    public interface ID_Empleado
    {
        DataTable buscarPersona(E_Empleado objEmpleado);
        DataTable GetEmpleado();
    }
}