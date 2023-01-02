using System.Threading;
using System.Threading.Tasks;
using Delgado.Ddd.Recepcion.Dominio.Eventos;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace Delgado.Ddd.Recepcion.API.Hubs
{
    public class AccionParaCitaActualizada : INotificationHandler<EventoCitaActualizada>
    {
        private readonly IHubContext<HubDeCalendario> _hubContext;

        public AccionParaCitaActualizada(IHubContext<HubDeCalendario> contextoDelHub)
        {
            _hubContext = contextoDelHub;
        }

        public Task Handle(EventoCitaActualizada args, CancellationToken cancellationToken)
        {
            return _hubContext.Clients.All.SendAsync("RecibirMensaje", args.CitaActualizada.RangoDeFechaTiempo.Comienzo + " ha sido actualizada", cancellationToken);
        }
    }
}
