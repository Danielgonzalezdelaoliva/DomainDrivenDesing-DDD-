using System;
namespace Delgado.Ddd.Recepcion.Compartido.Modelos
{
    public abstract class BaseDeMensaje
    {
        protected Guid _correlationId = Guid.NewGuid();
        public Guid CorrelationId() => _correlationId;
    }
}
