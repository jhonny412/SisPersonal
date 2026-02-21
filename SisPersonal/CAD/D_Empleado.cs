using System;
using System.Data;
using System.Data.SqlClient;

namespace CAD
{
    public class D_Empleado : ID_Empleado
    {
        Conexion objCon = new Conexion();
        SqlConnection cnx;
        //E_Empleado objEEmp = new E_Empleado();

        public virtual DataTable buscarPersona(CE.E_Empleado objEmpleado)
        {
            DataTable dt = new DataTable();
            using (cnx = objCon.getConecta())
            {
                SqlCommand cmd = new SqlCommand("spBuscarEmpleado", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criterio", objEmpleado.Nombres); // Buscaremos por nombre por defecto
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public virtual DataTable GetEmpleado()
        {
            DataTable dt = new DataTable();
            using (cnx = objCon.getConecta())
            {
                SqlCommand cmd = new SqlCommand("spListarEmpleados", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public int nuevoRegistro(CE.E_Empleado objEmpleado)
        {
            int r = 0;
            using (cnx = objCon.getConecta())
            {
                SqlCommand cmd = new SqlCommand("spInsertarEmpleado", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Empleado", objEmpleado.ID_Empleado);
                cmd.Parameters.AddWithValue("@Ape_Paterno", objEmpleado.Ape_Paterno);
                cmd.Parameters.AddWithValue("@Ape_Materno", objEmpleado.Ape_Materno);
                cmd.Parameters.AddWithValue("@Nombres", objEmpleado.Nombres);
                cmd.Parameters.AddWithValue("@DNI", objEmpleado.DNI);
                cmd.Parameters.AddWithValue("@Direccion", (object)objEmpleado.Direccion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Foto", (object)objEmpleado.Foto ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Estado", objEmpleado.Estado);
                cmd.Parameters.AddWithValue("@SBasicoHora", objEmpleado.SBasicoHora);
                cmd.Parameters.AddWithValue("@SHorasExtraHora", objEmpleado.SHorasExtraHora);
                cnx.Open();
                r = cmd.ExecuteNonQuery();
            }
            return r;
        }

        public int actualizarRegistro(CE.E_Empleado objEmpleado)
        {
            int r = 0;
            using (cnx = objCon.getConecta())
            {
                SqlCommand cmd = new SqlCommand("spActualizarEmpleado", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Empleado", objEmpleado.ID_Empleado);
                cmd.Parameters.AddWithValue("@Ape_Paterno", objEmpleado.Ape_Paterno);
                cmd.Parameters.AddWithValue("@Ape_Materno", objEmpleado.Ape_Materno);
                cmd.Parameters.AddWithValue("@Nombres", objEmpleado.Nombres);
                cmd.Parameters.AddWithValue("@DNI", objEmpleado.DNI);
                cmd.Parameters.AddWithValue("@Direccion", (object)objEmpleado.Direccion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Foto", (object)objEmpleado.Foto ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Estado", objEmpleado.Estado);
                cmd.Parameters.AddWithValue("@SBasicoHora", objEmpleado.SBasicoHora);
                cmd.Parameters.AddWithValue("@SHorasExtraHora", objEmpleado.SHorasExtraHora);
                cnx.Open();
                r = cmd.ExecuteNonQuery();
            }
            return r;
        }

        public int eliminarRegistro(string idEmpleado)
        {
            int r = 0;
            using (cnx = objCon.getConecta())
            {
                SqlCommand cmd = new SqlCommand("spEliminarEmpleado", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Empleado", idEmpleado);
                cnx.Open();
                r = cmd.ExecuteNonQuery();
            }
            return r;
        }
    }
}
