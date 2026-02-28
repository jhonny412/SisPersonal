using System;
using System.Data;
using System.Data.SqlClient;

namespace CAD
{
    public class D_Empleado : ID_Empleado
    {
        Conexion objCon = new Conexion();

        public virtual DataTable buscarPersona(CE.E_Empleado objEmpleado)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = objCon.getConecta())
                {
                    string criterio = objEmpleado.Nombres ?? "";
                    SqlCommand cmd = new SqlCommand("spBuscarEmpleado", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NOMBRES", criterio);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error en la base de datos al buscar empleado: " + ex.Message, ex);
            }
            return dt;
        }

        public virtual DataTable GetEmpleado()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = objCon.getConecta())
                {
                    SqlCommand cmd = new SqlCommand("spListarEmpleados", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al listar empleados: " + ex.Message, ex);
            }
            return dt;
        }

        public int nuevoRegistro(CE.E_Empleado objEmpleado)
        {
            try
            {
                using (SqlConnection connection = objCon.getConecta())
                {
                    SqlCommand cmd = new SqlCommand("spInsertarEmpleado", connection);
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
                    connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al insertar empleado: " + ex.Message, ex);
            }
        }

        public int actualizarRegistro(CE.E_Empleado objEmpleado)
        {
            try
            {
                using (SqlConnection connection = objCon.getConecta())
                {
                    SqlCommand cmd = new SqlCommand("spActualizarEmpleado", connection);
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
                    connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al actualizar empleado: " + ex.Message, ex);
            }
        }

        public int eliminarRegistro(string idEmpleado)
        {
            try
            {
                using (SqlConnection connection = objCon.getConecta())
                {
                    SqlCommand cmd = new SqlCommand("spEliminarEmpleado", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Empleado", idEmpleado);
                    connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al eliminar empleado: " + ex.Message, ex);
            }
        }
    }
}
