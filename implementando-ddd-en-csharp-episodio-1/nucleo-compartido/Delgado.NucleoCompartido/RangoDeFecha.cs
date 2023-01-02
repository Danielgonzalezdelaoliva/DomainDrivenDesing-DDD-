using Ardalis.GuardClauses;

namespace Delgado.NucleoCompartido;

public class RangoDeFecha : ObjetoDeValor
{
    public DateTimeOffset Comienzo { get; private set; }
    public DateTimeOffset Fin { get; private set; }

    public RangoDeFecha(DateTimeOffset comienzo, DateTimeOffset fin)
    {
        Guard.Against.OutOfRange(comienzo, nameof(comienzo), comienzo, fin);
        Comienzo = comienzo;
        Fin = fin;
    }

    public RangoDeFecha(DateTimeOffset comienzo, TimeSpan duracion) : this(comienzo, comienzo.Add(duracion))
    {
    }

    public int DuracionEnMinutos()
    {
        return (int)Math.Round((Fin - Comienzo).TotalMinutes, 0);
    }

    public RangoDeFecha NuevaDuracion(TimeSpan nuevaDuracion)
    {
        return new RangoDeFecha(this.Comienzo, nuevaDuracion);
    }

    public RangoDeFecha NuevoFin(DateTimeOffset nuevoFin)
    {
        return new RangoDeFecha(this.Comienzo, nuevoFin);
    }

    public RangoDeFecha NuevoComienzo(DateTimeOffset nuevoComienzo)
    {
        return new RangoDeFecha(nuevoComienzo, this.Fin);
    }

    public static RangoDeFecha CrearRangoDeUnDia(DateTimeOffset dia)
    {
        return new RangoDeFecha(dia, dia.AddDays(1));
    }

    public static RangoDeFecha CrearUnRangoDeUnaSemana(DateTimeOffset diaDeComienzo)
    {
        return new RangoDeFecha(diaDeComienzo, diaDeComienzo.AddDays(7));
    }

    public bool ExisteTraslapo(RangoDeFecha rangoDeFecha)
    {
        return this.Comienzo < rangoDeFecha.Fin &&
            this.Fin > rangoDeFecha.Comienzo;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Comienzo;
        yield return Fin;
    }

}
