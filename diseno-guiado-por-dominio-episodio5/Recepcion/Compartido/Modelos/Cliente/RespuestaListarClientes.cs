using System;
using System.Collections.Generic;

namespace Delgado.Ddd.Recepcion.Compartido.Modelos.Cliente
{
    public class RespuestaListarClientes: BaseDeRespuesta
    {
        public List<ClienteDto> Clientes { get; set; } = new List<ClienteDto>();
        public int CantidadDeRegistros { get; set; }

        public RespuestaListarClientes()
        {
        }

        public RespuestaListarClientes(Guid correlationId): base(correlationId)
        {
        }
    }
}
