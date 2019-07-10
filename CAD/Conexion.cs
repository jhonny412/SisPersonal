using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

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