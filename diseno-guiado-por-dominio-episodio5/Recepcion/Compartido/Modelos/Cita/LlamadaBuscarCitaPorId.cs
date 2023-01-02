using System;
namespace Delgado.Ddd.Recepcion.Compartido.Modelos.Cita
{
    public class LlamadaBuscarCitaPorId : BaseDeLlamada
    {
        public const string Ruta = "api/calendario/{CalendarioId}/citas/{CitaId}";

        public Guid CalendarioId { get; set; }
        public Guid CitaId { get; set; }
    }
}
