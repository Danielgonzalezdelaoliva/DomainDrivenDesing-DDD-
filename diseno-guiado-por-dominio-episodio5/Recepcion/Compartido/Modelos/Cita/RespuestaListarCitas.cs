using System;
using System.Collections.Generic;

namespace Delgado.Ddd.Recepcion.Compartido.Modelos.Cita
{
    public class RespuestaListarCitas : BaseDeRespuesta
    {
        public List<CitaDto> Citas { get; set; } = new List<CitaDto>();
        public int CantidadDeRegistros { get; set; }

        public RespuestaListarCitas()
        {
        }

        public RespuestaListarCitas(Guid correlationId) : base(correlationId)
        {
        }
    }
}
