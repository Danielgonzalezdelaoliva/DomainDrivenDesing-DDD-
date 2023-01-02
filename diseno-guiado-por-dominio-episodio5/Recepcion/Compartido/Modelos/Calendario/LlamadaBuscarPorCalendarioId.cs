using System;
namespace Delgado.Ddd.Recepcion.Compartido.Modelos.Calendario
{
    public class LlamadaBuscarPorCalendarioId: BaseDeLlamada
    {

        public const string Route = "api/calendarios/{calendarioId}";
        public Guid CalendarioId { get; set; }
    }
}
