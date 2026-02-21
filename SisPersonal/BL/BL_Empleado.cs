using CAD;
using System.Data;

namespace BL
{
    public class BL_Empleado
    {
        private readonly ID_Empleado objDEmp;

        // Constructor original para mantener compatibilidad
        public BL_Empleado() : this(new D_Empleado()) { }

        // Constructor para inyección de dependencias (para pruebas)
        public BL_Empleado(ID_Empleado dEmpleado)
        {
            objDEmp = dEmpleado;
        }

        public DataTable buscarPersona(CE.E_Empleado objEmpleado)
        {
            return objDEmp.buscarPersona(objEmpleado);
        }
        
        public DataTable GetEmpleado()
        {
            return objDEmp.GetEmpleado();
        }

        public int nuevoRegistro(CE.E_Empleado objEmpleado)
        {
            return objDEmp.nuevoRegistro(objEmpleado);
        }

        public int actualizarRegistro(CE.E_Empleado objEmpleado)
        {
            return objDEmp.actualizarRegistro(objEmpleado);
        }

        public int eliminarRegistro(string idEmpleado)
        {
            return objDEmp.eliminarRegistro(idEmpleado);
        }
    }
}
