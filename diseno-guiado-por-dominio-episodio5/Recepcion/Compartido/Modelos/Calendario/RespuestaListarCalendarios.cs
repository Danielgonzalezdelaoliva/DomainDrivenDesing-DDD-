using System;
using System.Collections.Generic;

namespace Delgado.Ddd.Recepcion.Compartido.Modelos.Calendario
{
    public class RespuestaListarCalendarios: BaseDeRespuesta
    {
        public List<CalendarioDto> Calendarios { get; set; } = new List<CalendarioDto>();

        public int CantidadDeRegistros { get; set; }

        public RespuestaListarCalendarios()
        {
        }

        public RespuestaListarCalendarios(Guid correlationId):base(correlationId)
        {

        }
    }
}
