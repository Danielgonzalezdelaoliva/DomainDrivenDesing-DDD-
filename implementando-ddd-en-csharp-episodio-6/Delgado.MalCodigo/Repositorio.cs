namespace Delgado.MalCodigo;

public class Repositorio : IRepositorio
{
    private readonly AppDbContext _dbContext;

    public Repositorio(AppDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    /// <summary>
    /// Listar servicios dados en una tienda especifica dentro de un numero de meses atras
    /// </summary>
    /// <param name="tiendaId">La identidad de la tienda</param>
    /// <param name="numeroDeMesesAtras">El numero de meses atras para la busqueda</param>
    /// <returns>Lista de servicios</returns>
    public IReadOnlyList<Servicio> ListarServiciosPorTienda(int tiendaId, int numeroDeMesesAtras)
    {
        var fechaInicial = DateTime.Now.AddMonths(Math.Abs(numeroDeMesesAtras) * -1);
 
            return _dbContext.Servicios
            .Where(s => s.TiendaId == tiendaId && s.Fecha >= fechaInicial)
            .ToList();
    }

    /// <summary>
    /// Lista servicios del dia de hoy por la tienda especificada
    /// </summary>
    /// <param name="tiendaId">Identidad de la tienda</param>
    /// <returns>Lista de servicios</returns>
    public IReadOnlyList<Servicio> ListarServiciosDelDiaDeHoyPorTienda(int tiendaId)
    {
        return _dbContext.Servicios
            .Where(s => s.TiendaId == tiendaId && s.EsServicioDeHoy())
            .ToList();
    }

    /// <summary>
    /// Lista servicios del dia de hoy por la tienda especificada
    /// </summary>
    /// <param name="tiendaId">Identidad de la tienda</param>
    /// <returns>Lista de servicios</returns>
    public IReadOnlyList<Servicio> ListarServiciosDelDiaDeHoyPorTienda_v2(int tiendaId)
    {
        return _dbContext.Servicios
            .ToList()
            .Where(s => s.TiendaId == tiendaId && s.EsServicioDeHoy())
            .ToList();
    }
}
