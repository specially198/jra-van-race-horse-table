using JraVanRaceHorseTable.Models;
using JraVanRaceHorseTable.Services;
using Microsoft.Extensions.DependencyInjection;

namespace JraVanRaceHorseTable
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
            ApplicationConfiguration.Initialize();

            IServiceCollection services = new ServiceCollection();
            services.AddDbContext<ApplicationDbContext>();
            services.AddTransient<IFormFactory, FormFactory>();
            services.AddTransient<IRaceService, RaceService>();
            services.AddTransient<IRaceUmaService, RaceUmaService>();
            services.AddTransient<IUmaService, UmaService>();
            services.AddTransient<frmMenu>();
            services.AddTransient<frmDenmaList>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();
            frmMenu form = serviceProvider.GetRequiredService<frmMenu>();
            Application.Run(form);
        }
    }
}