using CE;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CAD
{
    public class D_Usuario : ID_Usuario
    {
        Conexion objCon = new Conexion();
        SqlConnection cnx;
        E_Usuario objUsuario = new E_Usuario();

        //Codigo de Login
        public virtual DataTable Login(CE.E_Usuario objUsuario)
        {
            cnx = objCon.getConecta();
            try
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand("[spLogin]", cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@usuario", SqlDbType.Char, 25).Value = objUsuario.Usuario;
                cmd.Parameters.Add("@clave", SqlDbType.Char, 25).Value = objUsuario.Clave;
                //Creando DataAdapter
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                //Evaluando coincidencias
                cmd.ExecuteNonQuery();
                return dt;
            }
            catch (Exception ex2)
            {
                throw new Exception(ex2.Message);
            }
        }
        public virtual void nuevoRegistro(CE.E_Usuario objUsuario, string acccion)
        {
            cnx = objCon.getConecta();
            cnx.Open();
            SqlCommand cmd = new SqlCommand("spAbcUsuario", cnx);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Accion", SqlDbType.Char, 15).Value = acccion;
            cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = objUsuario.IdUsuario;
            cmd.Parameters.Add("@Usuario", SqlDbType.Char, 25).Value = objUsuario.Usuario;
            cmd.Parameters.Add("@Clave", SqlDbType.Char, 25).Value = objUsuario.Clave;
            cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = objUsuario.Estado;
            cmd.Parameters.Add("@Perfil", SqlDbType.Char, 25).Value = objUsuario.Perfil;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            cnx.Close();
        }
        public virtual void eliminarRegistro(CE.E_Usuario objUsuario, string acccion)
        {
            cnx = objCon.getConecta();
            cnx.Open();
            SqlCommand cmd = new SqlCommand("spAbcUsuario", cnx);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Accion", SqlDbType.Char, 15).Value = acccion;
            cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = objUsuario.IdUsuario;
            cmd.Parameters.Add("@Usuario", SqlDbType.Char, 25).Value = objUsuario.Usuario;
            cmd.Parameters.Add("@Clave", SqlDbType.Char, 25).Value = objUsuario.Clave;
            cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = objUsuario.Estado;
            cmd.Parameters.Add("@Perfil", SqlDbType.Char, 25).Value = objUsuario.Perfil;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            cnx.Close();
        }
        public virtual void actualizarRegistro(CE.E_Usuario objUsuario, string acccion)
        {
            cnx = objCon.getConecta();
            cnx.Open();
            SqlCommand cmd = new SqlCommand("spAbcUsuario", cnx);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Accion", SqlDbType.Char, 15).Value = acccion;
            cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = objUsuario.IdUsuario;
            cmd.Parameters.Add("@Usuario", SqlDbType.Char, 25).Value = objUsuario.Usuario;
            cmd.Parameters.Add("@Clave", SqlDbType.Char, 25).Value = objUsuario.Clave;
            cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = objUsuario.Estado;
            cmd.Parameters.Add("@Perfil", SqlDbType.Char, 25).Value = objUsuario.Perfil;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            cnx.Close();
        }
        public virtual DataTable listarUsuarios()
        {
            cnx = objCon.getConecta();
            SqlDataAdapter da = new SqlDataAdapter("select * from vUsuarios", cnx);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public virtual DataTable listarTodosUsuarios()
        {
            cnx = objCon.getConecta();
            SqlDataAdapter da = new SqlDataAdapter("select * from vTodosUsuarios", cnx);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public virtual int generaCodigo()
        {
            cnx = objCon.getConecta();
            cnx.Open();
            SqlCommand cmd = new SqlCommand("spUltimoUsuario", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            return Convert.ToInt32(cmd.ExecuteScalar().ToString()) + 1;
        }
    }
}
