using System;
namespace Delgado.Ddd.Recepcion.Compartido.Modelos.Cita
{
    public class RespuestaBuscarCitaPorId : BaseDeRespuesta
    {
        public CitaDto Cita { get; set; } = new CitaDto();
        public RespuestaBuscarCitaPorId()
        {
        }

        public RespuestaBuscarCitaPorId(Guid correlationId) : base(correlationId)
        {
        }
    }
}
