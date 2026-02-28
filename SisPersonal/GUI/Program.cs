using System;
using System.Windows.Forms;
using Serilog;

namespace GUI
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LoggingConfiguration.Configure();

            // Manejador para excepciones en el hilo de la interfaz de usuario
            Application.ThreadException += (sender, e) => 
            {
                Log.Fatal(e.Exception, "Excepción no manejada en el hilo de UI");
                MessageBox.Show("Ocurrió un error crítico inesperado. Por favor consulte el log para más detalles.", "Error Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            // Manejador para excepciones en otros hilos
            AppDomain.CurrentDomain.UnhandledException += (sender, e) => 
            {
                Log.Fatal(e.ExceptionObject as Exception, "Excepción no manejada en el dominio de la aplicación");
            };

            try
            {
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmLogin());
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Error crítico durante el inicio de la aplicación");
                throw;
            }
            finally
            {
                LoggingConfiguration.CloseAndFlush();
            }
        }
    }
}
