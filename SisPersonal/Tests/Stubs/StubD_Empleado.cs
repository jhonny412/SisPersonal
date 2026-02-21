using CAD;
using CE;
using System;
using System.Data;

namespace Tests.Stubs
{
    public class StubD_Empleado : D_Empleado
    {
        public DataTable BuscarPersonaResult { get; set; }
        public DataTable GetEmpleadoResult { get; set; }
        public Exception ExceptionToThrow { get; set; }
        public bool ShouldThrowException { get; set; }

        public int BuscarPersonaCallCount { get; private set; }
        public int GetEmpleadoCallCount { get; private set; }

        public E_Empleado LastEmpleadoParameter { get; private set; }

        public StubD_Empleado()
        {
            // Configuración por defecto
            BuscarPersonaResult = new DataTable();
            GetEmpleadoResult = new DataTable();
            ShouldThrowException = false;
        }

        public override DataTable buscarPersona(E_Empleado objEmpleado)
        {
            BuscarPersonaCallCount++;
            LastEmpleadoParameter = objEmpleado;

            if (ShouldThrowException && ExceptionToThrow != null)
                throw ExceptionToThrow;

            return BuscarPersonaResult;
        }

        public override DataTable GetEmpleado()
        {
            GetEmpleadoCallCount++;

            if (ShouldThrowException && ExceptionToThrow != null)
                throw ExceptionToThrow;

            return GetEmpleadoResult;
        }
    }
}