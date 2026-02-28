using System;
using System.IO;
using Serilog;
using Serilog.Events;

namespace GUI
{
    public static class LoggingConfiguration
    {
        private static string _logDirectory;
        private static string _logFilePath;

        public static void Configure()
        {
            try
            {
                // Intentar encontrar la carpeta Logs en la raíz si estamos en desarrollo
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string devLogs = Path.GetFullPath(Path.Combine(baseDir, @"..\..\..\", "Logs"));
                
                // Si la carpeta superior no existe (producción), usar la carpeta de ejecución
                if (Directory.Exists(Path.GetFullPath(Path.Combine(baseDir, @"..\..\..\"))))
                {
                    _logDirectory = devLogs;
                }
                else
                {
                    _logDirectory = Path.Combine(baseDir, "Logs");
                }

                if (!Directory.Exists(_logDirectory))
                {
                    Directory.CreateDirectory(_logDirectory);
                }

                _logFilePath = Path.Combine(_logDirectory, "sispersonal-.log");

                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                    .Enrich.FromLogContext()
                    .Enrich.WithProperty("Application", "SisPersonal")
                    .Enrich.WithProperty("MachineName", Environment.MachineName)
                    .WriteTo.File(
                        _logFilePath,
                        rollingInterval: RollingInterval.Day,
                        retainedFileCountLimit: 30,
                        fileSizeLimitBytes: 10 * 1024 * 1024, // 10MB
                        rollOnFileSizeLimit: true,
                        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                    .CreateLogger();

                Log.Information("=== Sistema de Personal - Logging Iniciado ===");
            }
            catch (Exception ex)
            {
                // Si falla el logging, al menos intentamos escribir en la consola o ignorar
                System.Diagnostics.Debug.WriteLine("Error configurando Serilog: " + ex.Message);
            }
        }

        public static void CloseAndFlush()
        {
            Log.Information("=== Aplicación Finalizada Correctamente ===");
            Log.CloseAndFlush();
        }

        public static string GetLogDirectory()
        {
            return _logDirectory;
        }
    }
}
