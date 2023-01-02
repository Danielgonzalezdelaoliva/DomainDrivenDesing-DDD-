using System;
namespace Delgado.Ddd.Recepcion.Compartido.Modelos.Cita
{
    public class RespuestaCrearCita : BaseDeRespuesta
    {
        public CitaDto Cita { get; set; } = new CitaDto();
        public RespuestaCrearCita()
        {
        }

        public RespuestaCrearCita(Guid correlationId) : base(correlationId)
        {
        }
    }
}
