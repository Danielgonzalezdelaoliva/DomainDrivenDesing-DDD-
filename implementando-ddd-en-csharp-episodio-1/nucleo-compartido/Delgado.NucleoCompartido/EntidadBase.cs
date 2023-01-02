namespace Delgado.NucleoCompartido;

/// <summary>
/// La entidad base usando el Id otorgado con tipo generico
/// </summary>
public abstract class EntidadBase<TId>
{
    public TId Id { get; set; }
    public List<EventoDelDominioBase> Eventos = new();
}
