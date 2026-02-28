using System;
using System.Configuration;

class Program
{
    static void Main()
    {
        try
        {
            var config = ConfigurationManager.OpenExeConfiguration("D:\\Sistemas\\SisPersonal\\GUI\\bin\\Debug\\GUI.exe");
            var connStr = config.ConnectionStrings.ConnectionStrings["cnx"] != null ? config.ConnectionStrings.ConnectionStrings["cnx"].ConnectionString : null;
            Console.WriteLine("String from GUI.exe.config cnx: " + connStr);
            var connStr2 = config.ConnectionStrings.ConnectionStrings["GUI.Properties.Settings.Control_PersonalConnectionString"] != null ? config.ConnectionStrings.ConnectionStrings["GUI.Properties.Settings.Control_PersonalConnectionString"].ConnectionString : null;
            Console.WriteLine("String from GUI.exe.config Settings: " + connStr2);
        }
        catch(Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
