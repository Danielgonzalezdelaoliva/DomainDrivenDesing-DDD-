using System;
using MediatR;

namespace Delgado.Ddd.KernellCompartido
{
    public abstract class BaseDeEventoDeIntegracion : INotification
    {
        public DateTimeOffset FechaDeEvento { get; protected set; } = DateTime.UtcNow;
        string TipoDeEvento { get; }

    }
}
