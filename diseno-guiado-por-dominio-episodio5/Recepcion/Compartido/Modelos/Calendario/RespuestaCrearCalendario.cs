using System;
namespace Delgado.Ddd.Recepcion.Compartido.Modelos.Calendario
{
    public class RespuestaCrearCalendario: BaseDeRespuesta
    {
        public CalendarioDto Calendario { get; set; } = new CalendarioDto();

        public RespuestaCrearCalendario()
        {
        }

        public RespuestaCrearCalendario(Guid correlationId) : base(correlationId) { }
    }
}
