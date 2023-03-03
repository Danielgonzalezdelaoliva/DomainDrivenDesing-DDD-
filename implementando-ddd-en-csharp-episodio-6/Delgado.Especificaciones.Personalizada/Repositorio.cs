using Delgado.Especificaciones.Comun;
using Delgado.Especificaciones.Personalizada.Especificaciones;

namespace Delgado.Especificaciones.Personalizada;

public class Repositorio : IRepositorioPersonalizado
{
    private readonly AppDbContext _dbContext;

    public Repositorio(AppDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public IReadOnlyList<Servicio> ListarServiciosDelDiaDeHoy()
    {
        return _dbContext.Servicios
            .Where(x => x.Fecha > DateTime.Today.AddDays(-1))
            .ToList();
    }

    //usando expresiones (delegado). parecido a programacion de funciones. 
    public IReadOnlyList<Servicio> ListarServiciosUsandoExpresion(Func<Servicio, bool> expresion)
    {
        return _dbContext.Servicios
            .Where(expresion)
            .ToList();
    }

    //error de compilador al querer combinar expresiones
    public IReadOnlyList<Servicio> ListarServiciosUsandoExpresiones(Func<Servicio, bool> expresion1, Func<Servicio, bool> expresion2)
    {
        return _dbContext.Servicios
            .Where(expresion1 && expresion2)
            .ToList();
    }

    public IReadOnlyList<Servicio> ListarServiciosUsandoEspecificacionGenerica(EspecificacionGenerica<Servicio> especificacion)
    {
        return _dbContext.Servicios
            .Where(especificacion.Expresion)
            .ToList();
    }

    public IReadOnlyCollection<Servicio> 
        ListarServiciosUsandoEspecificacionDelDia(EspecificacionServicioDelDiaDeHoy especificacion)
    {
        return _dbContext.Servicios
            .Where(especificacion.ConvertirEspecificacionAExpresion())
            .ToList();
    }

    public IReadOnlyCollection<Servicio> ListarServiciosUsandoEspecificacion(Especificacion<Servicio> especificacion)
    {
        return _dbContext.Servicios
            .Where(especificacion.ConvertirEspecificacionAExpresion())
            .ToList();
    }
}
