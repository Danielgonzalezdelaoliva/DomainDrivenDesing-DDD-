using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Delgado.Ddd.Recepcion.Dominio.AgregadosSincronizados;
using MediatR;
using Microsoft.Extensions.Logging;
namespace Delgado.Ddd.Recepcion.Infraestructura.Datos.Sincronizaciones
{
    /// <summary>
    /// The client update handler
    /// </summary>
    public class AccionParaActualizarCliente : IRequestHandler<ComandoParaActualizarCliente>
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<AccionParaActualizarCliente> _logger;

        public AccionParaActualizarCliente(AppDbContext dbContext, ILogger<AccionParaActualizarCliente> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        /// <summary>
        /// La accion a seguir para actualizar el Cliente
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(ComandoParaActualizarCliente request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"AccionParaActualizarCliente actualizando el Cliente {request.Nombre} para sincronizar datos.");
            var client = _dbContext.Set<Cliente>().Find(request.Id);
            var nombreActual = client.NombreCompleto;

            if (request.Nombre == nombreActual)
            {
                // no change
                return Unit.Value;
            }

            // use reflection to set name
            var tipo = client.GetType();
            var prop = tipo.GetProperty(nameof(client.NombreCompleto));
            prop.SetValue(client, request.Nombre, null);

            _ = await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
