using System;
namespace Delgado.Ddd.Recepcion.Compartido.Modelos.Cita
{
    public class LlamadaListarCitas : BaseDeLlamada
    {
        public const string Ruta = "api/calendario/{CalendarioId}/citas";

        public Guid CalendarioId { get; set; }
        public LlamadaListarCitas()
        {
        }
    }
}
