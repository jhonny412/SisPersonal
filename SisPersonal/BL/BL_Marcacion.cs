using CAD;
using CE;
using System;
using System.Data;

namespace BL
{
    public class BL_Marcacion
    {
        D_Marcaciones objDMarcacion = new D_Marcaciones();
        public DataTable ListarMarcaciones()
        {
            return objDMarcacion.ListarMarcaciones();
        }

        public bool InsertarMarcacion(E_Marcaciones obj)
        {
            return objDMarcacion.InsertarMarcacion(obj);
        }

        public DataTable ConsultarMarcacion(E_Empleado objEmp)
        {
            return objDMarcacion.ConsultarMarcacion(objEmp);
        }

        public DataTable ListarEmpleados()
        {
            return objDMarcacion.ListarEmpleados();
        }

        public DataTable MarcacionXFecha(string id, DateTime desde, DateTime hasta)
        {
            return objDMarcacion.MarcacionXFecha(id, desde, hasta);
        }
    }
}