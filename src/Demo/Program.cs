using Demo.Configurations;
using Demo.Controlers;
using Demo.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.IO;
using System.Windows.Forms;

namespace Demo
{
    internal static class Program
    {
        private static IConfiguration _configuration;
        private static ServiceCollection _services;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ConfigureServices();

            using (ServiceProvider serviceProvider = _services.BuildServiceProvider())
            {
                var form1 = serviceProvider.GetRequiredService<Form1>();
                Application.Run(form1);
            }
        }

        private static void ConfigureServices()
        {
            _services = new ServiceCollection();
            SetupConfigurations();
            SetupRefit();
            SetupService();
            SetupForms();
        }

        private static void SetupConfigurations()
        {
            var appSettingsPath = Path.Combine(Environment.CurrentDirectory, "appsettings.json");

            var configurationBuilder = new ConfigurationBuilder()
               .AddJsonFile(appSettingsPath, optional: true, reloadOnChange: true);
            _configuration = configurationBuilder.Build();

            _services.Configure<AppSettings>(options => _configuration.Bind(options));
        }

        private static void SetupRefit()
        {
            var apiUrl = _configuration.GetValue<string>("apiUrl");

            // Configure refit settings here
            var settings = new RefitSettings()
            {
                CollectionFormat = CollectionFormat.Multi
            };

            // Add Controllers
            _services.AddRefitClient<IUsers>(settings)
                    .ConfigureHttpClient(c => c.BaseAddress = new Uri(apiUrl));

            _services.AddRefitClient<IModules>(settings)
                    .ConfigureHttpClient(c => c.BaseAddress = new Uri(apiUrl));
        }

        private static void SetupService()
        {
            _services.AddSingleton<UserServices>();
        }
            
        private static void SetupForms()
        {
            _services.AddScoped<Form1>();
        }
    }
}
