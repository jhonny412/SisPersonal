using System.Data.SqlClient;

namespace CAD
{
    public class Conexion
    {
        private const string ConnectionString =
            "Server=Servidor;Initial Catalog=dbControlPersonal;" +
            "Persist Security Info=True;User ID=sa;Password=Sunat_2026;" +
            "Encrypt=False;TrustServerCertificate=True";

        public SqlConnection getConecta()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}