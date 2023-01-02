using System;
namespace Delgado.Ddd.Recepcion.Dominio.Excepciones
{
    public class ExcepcionClienteNoEncontrado: Exception
    {
        public ExcepcionClienteNoEncontrado(string message): base(message)
        {
        }

        public ExcepcionClienteNoEncontrado(int clienteId): base($"El cliente con id: [{clienteId}] no ha sido encontrado!")
        {

        }
    }
}
