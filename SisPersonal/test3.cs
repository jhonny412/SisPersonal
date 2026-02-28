using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string cs = "Server=Servidor;Initial Catalog=dbControlPersonal;User ID=sa;Password=Sunat_2026;";
        try
        {
            using (SqlConnection c = new SqlConnection(cs))
            {
                c.Open();
                SqlCommand cmd = new SqlCommand("SELECT OBJECT_DEFINITION(OBJECT_ID('spAbcUsuario'))", c);
                Console.WriteLine(cmd.ExecuteScalar());
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
