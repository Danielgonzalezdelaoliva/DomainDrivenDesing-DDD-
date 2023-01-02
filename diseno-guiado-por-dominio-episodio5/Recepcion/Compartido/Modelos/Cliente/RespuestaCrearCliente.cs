using System;
namespace Delgado.Ddd.Recepcion.Compartido.Modelos.Cliente
{
    public class RespuestaCrearCliente : BaseDeRespuesta
    {
        public ClienteDto Cliente { get; set; } = new ClienteDto();

        public RespuestaCrearCliente(Guid correlationId): base(correlationId)
        {
            
        }
        public RespuestaCrearCliente()
        {

        }
    }
}
