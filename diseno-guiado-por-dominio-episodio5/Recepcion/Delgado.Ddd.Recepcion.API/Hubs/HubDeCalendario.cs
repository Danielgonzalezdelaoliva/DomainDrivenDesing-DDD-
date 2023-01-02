using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
namespace Delgado.Ddd.Recepcion.API.Hubs
{
    public class HubDeCalendario: Hub
    {
        public Task ActualizarCalendarioAsync(string mensaje)
        {
            return Clients.Others.SendAsync("RecibirMensaje", mensaje);
        }
    }
}
