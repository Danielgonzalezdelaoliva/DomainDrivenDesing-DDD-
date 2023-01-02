using System.Threading;
using System.Threading.Tasks;
using Delgado.Ddd.Recepcion.Dominio.Eventos;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace Delgado.Ddd.Recepcion.API.Hubs
{
    public class AccionParaCitaReservada : INotificationHandler<EventoCitaReservada>
    {
        private readonly IHubContext<HubDeCalendario> _hubContext;

        public AccionParaCitaReservada(IHubContext<HubDeCalendario> contextoDelHub)
        {
            _hubContext = contextoDelHub;
        }

        public Task Handle(EventoCitaReservada args, CancellationToken cancellationToken)
        {
            return _hubContext.Clients.All.SendAsync("RecibirMensaje", args.CitaReservada.RangoDeFechaTiempo.Comienzo + " ha sido reservada", cancellationToken);
        }
    }
}
