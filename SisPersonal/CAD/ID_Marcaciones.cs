using CE;
using System;
using System.Data;

namespace CAD
{
    public interface ID_Marcaciones
    {
        DataTable ListarMarcaciones();
        bool InsertarMarcacion(E_Marcaciones obj);
        DataTable ConsultarMarcacion(E_Empleado objEmp);
        DataTable ListarEmpleados();
        DataTable MarcacionXFecha(string id, DateTime desde, DateTime hasta);
    }
}
