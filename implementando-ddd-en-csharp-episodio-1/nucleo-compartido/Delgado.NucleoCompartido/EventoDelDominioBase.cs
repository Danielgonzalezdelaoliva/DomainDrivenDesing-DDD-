using MediatR;
namespace Delgado.NucleoCompartido;

public class EventoDelDominioBase : INotification
{
    public DateTimeOffset FechaUtcDelEvento { get; protected set; } = DateTimeOffset.UtcNow;
}