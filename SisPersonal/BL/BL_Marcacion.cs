using CAD;
using CE;
using System;
using System.Data;

namespace BL
{
    public class BL_Marcacion
    {
        private readonly ID_Marcaciones objDMarcacion;

        public BL_Marcacion() : this(new D_Marcaciones()) { }

        public BL_Marcacion(ID_Marcaciones dMarcacion)
        {
            objDMarcacion = dMarcacion;
        }

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