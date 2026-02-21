using CE;
using System.Data;
using Tests.Interfaces;

namespace Tests.TestableClasses
{
    public class BL_Empleado_Testable
    {
        private readonly ID_Empleado _dEmpleado;

        public BL_Empleado_Testable(ID_Empleado dEmpleado)
        {
            _dEmpleado = dEmpleado;
        }

        public DataTable buscarPersona(E_Empleado objEmpleado)
        {
            return _dEmpleado.buscarPersona(objEmpleado);
        }

        public DataTable GetEmpleado()
        {
            return _dEmpleado.GetEmpleado();
        }
    }
}