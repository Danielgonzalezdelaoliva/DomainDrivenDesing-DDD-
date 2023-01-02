using System;
namespace Delgado.Ddd.Recepcion.Compartido.Modelos.Cliente
{
    public class RespuestaBuscarPorClienteId: BaseDeRespuesta
    {
        public ClienteDto Cliente { get; set; } = new ClienteDto();

        public RespuestaBuscarPorClienteId()
        {
        }

        public RespuestaBuscarPorClienteId(Guid correlationId): base(correlationId)
        {

        }
    }
}
