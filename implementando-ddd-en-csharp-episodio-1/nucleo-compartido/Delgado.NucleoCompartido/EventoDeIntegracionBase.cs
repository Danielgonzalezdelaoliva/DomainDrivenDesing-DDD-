using MediatR;

namespace Delgado.NucleoCompartido;

/// <summary>
/// Eventos para comunicacion entre contextos limitados
/// </summary>
public abstract class EventoDeIntegracionBase : INotification
{
    public DateTimeOffset FechaUtcDelEvento { get; protected set; } = DateTimeOffset.UtcNow;
    string TipoDeEvento { get; }
}
