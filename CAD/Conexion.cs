using System.Configuration;
using System.Data.SqlClient;

namespace CAD
{
    public class Conexion
    {
        public SqlConnection getConecta()
        {
            SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString);
            return cnx;
        }
    }
}