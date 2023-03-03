namespace Delgado.MalCodigo;

public class UI
{
    private readonly IRepositorio _repositorio;

    public UI(IRepositorio repositorio)
    {
        this._repositorio = repositorio;
    }

    /// <summary>
    /// Ejemplo de un UI filtrando resultados de un repositorio
    /// </summary>
    /// <returns>Lista de servicios del dia de hoy</returns>
    public IReadOnlyList<Servicio> ListarServiciosDeHoy()
    {
        var servicios = _repositorio.ListarServiciosPorTienda(tiendaId: 1, numeroDeMesesAtras: 1);
        var serviciosDeHoy = servicios.Where(s => s.Fecha > DateTime.Today.AddDays(-1)).ToList();
        return serviciosDeHoy;
    }

    /// <summary>
    /// Ejemplo de un UI filtrando resultados de un repositorio
    /// </summary>
    /// <returns>Lista de servicios del dia de hoy</returns>
    public IReadOnlyList<Servicio> ListarServiciosDeHoy_v2()
    {
        var servicios = _repositorio.ListarServiciosPorTienda(tiendaId: 1, numeroDeMesesAtras: 1);
        var serviciosDeHoy = servicios.Where(s => s.EsServicioDeHoy()).ToList();
        return serviciosDeHoy;
    }
}
