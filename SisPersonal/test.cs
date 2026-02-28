using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string cs = "Server=Servidor;Initial Catalog=Control_Personal;User ID=sa;Password=Sunat_2026;Encrypt=True;TrustServerCertificate=True;PersistSecurityInfo=False;Connection Timeout=15";
        try
        {
            using (SqlConnection c = new SqlConnection(cs))
            {
                c.Open();
                Console.WriteLine("Success sa");
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine("Error sa: " + ex.Message);
        }

        string cs2 = "Server=Servidor;Initial Catalog=Control_Personal;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;PersistSecurityInfo=False;Connection Timeout=15";
        try
        {
            using (SqlConnection c = new SqlConnection(cs2))
            {
                c.Open();
                Console.WriteLine("Success windows auth");
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine("Error windows: " + ex.Message);
        }
    }
}
