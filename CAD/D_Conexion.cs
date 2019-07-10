using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CAD
{
    public class D_Conexion
    {
        public SqlConnection getConecta()
        {
            SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings[""].ConnectionString);
            return cnx;
        }
    }
}
