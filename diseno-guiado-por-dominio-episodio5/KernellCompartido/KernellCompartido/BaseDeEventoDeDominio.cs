using System;
using MediatR;
namespace Delgado.Ddd.KernellCompartido
{
    public abstract class BaseDeEventoDeDominio : INotification
    {
        public DateTimeOffset FechaDeEvento { get; protected set; } = DateTimeOffset.UtcNow;
    }
}
