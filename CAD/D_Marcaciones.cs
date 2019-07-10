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
    public class D_Marcaciones
    {
        //D_Marcaciones objEMarcacion = new D_Marcaciones();
        Conexion objCon = new Conexion();
        SqlConnection cnx;
        public DataTable ListarMarcaciones()
        {
            cnx = objCon.getConecta();
            cnx.Open();

            //SqlCommand cmd = new SqlCommand("vMarcacionees", cnx);
            SqlDataAdapter da = new SqlDataAdapter("select * from vMarcaciones", cnx);
            //cmd.CommandType = CommandType.StoredProcedure;

            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //cmd.ExecuteReader();

            return dt;
        }
    }
}
