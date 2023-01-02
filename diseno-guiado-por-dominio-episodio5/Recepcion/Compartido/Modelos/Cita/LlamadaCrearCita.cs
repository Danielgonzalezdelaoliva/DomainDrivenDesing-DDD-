using System;
namespace Delgado.Ddd.Recepcion.Compartido.Modelos.Cita
{
    public class LlamadaCrearCita : BaseDeLlamada
    {
        public const string Ruta = "api/calendario/{CalendarioId}/Citas";

        public int ClienteId { get; set; }
        public Guid CalendarioId { get; set; }

        public int TipoDeCitaId { get; set; }
        public DateTimeOffset FechaDeCita { get; set; }
        public int PeluqueroId { get; set; }
        public int TiendaId { get; set; }
    }
}
