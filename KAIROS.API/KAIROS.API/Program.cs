using KAIROS.API.Repositorio;
using KAIROS.API.Repositorio.Interface;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace KAIROS.API
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var serviceProvider = new ServiceCollection()
           .AddScoped<IExcelRepositorio, ExcelRepositorio>()
            .BuildServiceProvider();
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(serviceProvider));
            
        }
    }
}