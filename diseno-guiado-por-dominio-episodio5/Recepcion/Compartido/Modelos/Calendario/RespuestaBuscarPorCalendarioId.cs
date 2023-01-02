using System;
namespace Delgado.Ddd.Recepcion.Compartido.Modelos.Calendario
{
    public class RespuestaBuscarPorCalendarioId: BaseDeRespuesta
    {
        public CalendarioDto Calendario { get; set; } = new CalendarioDto();

        public RespuestaBuscarPorCalendarioId()
        {
        }

        public RespuestaBuscarPorCalendarioId(Guid correlationId): base(correlationId)
        {

        }
    }
}
