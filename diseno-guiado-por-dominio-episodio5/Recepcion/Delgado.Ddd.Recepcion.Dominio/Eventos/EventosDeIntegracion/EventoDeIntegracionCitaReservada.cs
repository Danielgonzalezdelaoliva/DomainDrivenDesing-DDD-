using System;
using Delgado.Ddd.KernellCompartido;

namespace Delgado.Ddd.Recepcion.Dominio.Eventos.EventosDeIntegracion
{
    public class EventoDeIntegracionCitaReservada : BaseDeEventoDeIntegracion
    {
        public EventoDeIntegracionCitaReservada()
        {
            FechaDeEvento = DateTimeOffset.Now;
        }

        public Guid ClienteId { get; set; }
        public string NombreDelCliente { get; set; }
        public string CorreoElectronicoDelCliente { get; set; }
        public string TipoDeCita { get; set; }
        public string NombreDelPeluquero { get; set; }
        public DateTimeOffset FechaHoraDeComienzoDelaCita { get; set; }
        public string TipoDeEvento => nameof(EventoDeIntegracionCitaReservada);

    }
}
