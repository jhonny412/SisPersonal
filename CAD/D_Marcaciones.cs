using CE;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CAD
{
    public class D_Marcaciones
    {
        //D_Marcaciones objEMarcacion = new D_Marcaciones();
        Conexion objCon = new Conexion();
        SqlConnection cnx;
        public DataTable ListarMarcaciones()
        {
            cnx = objCon.getConecta();
            cnx.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from vMarcaciones", cnx);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public bool InsertarMarcacion(E_Marcaciones obj)
        {
            bool accion = false;

            using (cnx = objCon.getConecta())
            {
                try
                {
                    cnx.Open();
                    SqlCommand cmd = new SqlCommand("sp_InsertMarcacion", cnx);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //cmd.Parameters.Add("@Id_Marcacion", SqlDbType.Char, 5).Value = obj.Id_Marcacion;
                    cmd.Parameters.Add("@Id_Empleado", SqlDbType.Char, 5).Value = obj.Id_Empleado;
                    cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = obj.Fecha;
                    cmd.Parameters.Add("@H_Ingreso", SqlDbType.VarChar, 20).Value = obj.H_Ingreso;
                    cmd.Parameters.Add("@HS_Refrigerio", SqlDbType.VarChar, 20).Value = obj.HS_Refrigerio;
                    cmd.Parameters.Add("@HI_Refrigerio", SqlDbType.VarChar, 20).Value = obj.HI_Refrigerio;
                    cmd.Parameters.Add("@H_Salida", SqlDbType.VarChar, 20).Value = obj.H_Salida;
                    cmd.Parameters.Add("@TH_Refrigerio", SqlDbType.VarChar, 20).Value = obj.TH_Refrigerio;
                    cmd.Parameters.Add("@TH_Trabajadas", SqlDbType.VarChar, 20).Value = obj.TH_Trabajadas;
                    cmd.Parameters.Add("@Observacion", SqlDbType.VarChar, 300).Value = obj.Observacion;
                    cmd.Parameters.Add("@MENSAJE", SqlDbType.VarChar, 300).Direction = ParameterDirection.Output;

                    int fila = cmd.ExecuteNonQuery();
                    if (fila > 0)
                    {
                        accion = true;
                    }
                    obj.Mensaje = cmd.Parameters["@MENSAJE"].Value.ToString();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return accion;
            }
        }

        public DataTable ConsultarMarcacion(E_Empleado objEmp)
        {
            DataTable dt = new DataTable();
            using (cnx = objCon.getConecta())
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand("spMarcacionEmpleado", cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@dni", objEmp.dni);
                cmd.Parameters.AddWithValue("@FECHA", objEmp.Fecha);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable ListarEmpleados()
        {
            cnx = objCon.getConecta();
            cnx.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from vListaEmpleados", cnx);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable MarcacionXFecha(string id, DateTime desde, DateTime hasta)
        {
            DataTable dt = new DataTable();
            using (cnx = objCon.getConecta())
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand("spMarcacionXFecha", cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ID", SqlDbType.Char, 10).Value = id;
                cmd.Parameters.Add("@FECHA_DESDE", SqlDbType.DateTime).Value = desde;
                cmd.Parameters.Add("@FECHA_HASTA", SqlDbType.DateTime).Value = hasta;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
