using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAD;

namespace BL
{
    public class BL_Empleado
    {
        D_Empleado objDEmp = new D_Empleado();
        public DataTable buscarPersona(CE.E_Empleado objEmpleado)
        {
            return objDEmp.buscarPersona(objEmpleado);
        }
    }
}
