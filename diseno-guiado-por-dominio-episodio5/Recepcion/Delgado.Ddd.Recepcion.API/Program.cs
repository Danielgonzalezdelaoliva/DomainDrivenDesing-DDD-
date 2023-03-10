using System;
using Autofac.Extensions.DependencyInjection;
using Delgado.Ddd.Recepcion.Infraestructura.Datos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Delgado.Ddd.Recepcion.API
{
    public class Program
    {
        public static async System.Threading.Tasks.Task Main(string[] args)
        {
            var host = CreateHostBuilder(args)
                        .Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var hostEnvironment = services.GetService<IWebHostEnvironment>();
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogInformation($"Comenzando en {hostEnvironment.EnvironmentName}...");

                try
                {
                    var servicioDeAlimentacionDeDatos = services.GetRequiredService<AppDbContextDatos>();
                    await servicioDeAlimentacionDeDatos.LlenarDatosAsync(new ConfiguracionesDeOficina().FechaDePrueba.Date);

                    //var contextoDeAplicacion = services.GetRequiredService<AppDbContext>();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Un error ha ocurrido alimentando la base de datos");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
              .UseServiceProviderFactory(new AutofacServiceProviderFactory())
              .ConfigureWebHostDefaults(webBuilder =>
              {
                  webBuilder.UseStartup<Startup>();
              });
    }
}
