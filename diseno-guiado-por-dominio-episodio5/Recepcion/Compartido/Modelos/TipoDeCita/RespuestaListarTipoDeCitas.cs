using System;
using System.Collections.Generic;

namespace Delgado.Ddd.Recepcion.Compartido.Modelos.TipoDeCita
{
    public class RespuestaListarTipoDeCitas : BaseDeRespuesta
    {
        public List<TipoDeCitaDto> TiposDeCita { get; set; } = new List<TipoDeCitaDto>();
        public int CantidadDeRegistros { get; set; }

        public RespuestaListarTipoDeCitas()
        {
        }

        public RespuestaListarTipoDeCitas(Guid correlationId) : base(correlationId)
        {
        }
    }
}
