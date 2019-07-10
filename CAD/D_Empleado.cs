using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CE;
using System.Data;
using System.Data.SqlClient;

namespace CAD
{
    public class D_Empleado
    {
        Conexion objCon = new Conexion();
        SqlConnection cnx;
        //E_Empleado objEEmp = new E_Empleado();

        public DataTable buscarPersona(CE.E_Empleado objEmpleado)
        {
            cnx = objCon.getConecta();
            cnx.Open();
            SqlCommand cmd = new SqlCommand("spBuscarEmpleado", cnx);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@dni", SqlDbType.Char, 8).Value = objEmpleado.dni;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //Ejecutando la consulta
            cmd.ExecuteReader();

            return dt;
        }
    }
}
