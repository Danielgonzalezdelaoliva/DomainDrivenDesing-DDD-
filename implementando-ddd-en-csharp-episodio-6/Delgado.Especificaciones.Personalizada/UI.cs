using Delgado.Especificaciones.Comun;
using Delgado.Especificaciones.Personalizada.Especificaciones;

namespace Delgado.Especificaciones.Personalizada;

public class UI
{
    private readonly IRepositorioPersonalizado _repositorio;

    public UI(IRepositorioPersonalizado repositorio)
    {
        _repositorio = repositorio;
    }

    public void UsandoEspecificacionComoValidador()
    {
        //aca aun no usamos especificacion para filtrar datos
        var servicio = _repositorio.ListarServiciosDelDiaDeHoy().First();

        //solo para ejemplificar una como la especificacion podria usarse como validador
        var expresionGenericaDelDiaDeHoy = 
            new EspecificacionGenerica<Servicio>(x => x.Fecha > DateTime.Today.AddDays(-1));
        if(expresionGenericaDelDiaDeHoy.EsSatisfechaPor(servicio))
        {
            //algo
        }
    }

    public IReadOnlyList<Servicio> UsandoEspecificacionComoFiltro()
    {
        //Note que aunque usamos especificacion
        //estamos pasando manualmente la logica de la especificacion
        //y conocemos del dominio (logica del negocio) desde la capa de presentacion
        var expresionGenericaDelDiaDeHoy = 
            new EspecificacionGenerica<Servicio>(x => x.Fecha > DateTime.Today.AddDays(-1));
        var servicios = _repositorio
            .ListarServiciosUsandoEspecificacionGenerica(expresionGenericaDelDiaDeHoy);
        return servicios;
    }

    //simulacro de codigo en UI o API (consumidor)
    public IReadOnlyCollection<Servicio> UsandoEspecificacion()
    {
        //puede que esta especificacion este definida en otra capa que no sea la de presentacion
        var especificacion = new EspecificacionServicioDelDiaDeHoy();
        var resultado = _repositorio.ListarServiciosUsandoEspecificacionDelDia(especificacion);
        return resultado;
    }

    //ejemplo usando especificacion para validar desde el UI
    public static bool ValidandoServicioDelDia(Servicio servicio)
    {
        var especificacion = new EspecificacionServicioDelDiaDeHoy();
        return especificacion.EsSatisfechoPor(servicio);
    }

    //ejemplo combinando especificaciones
    public IReadOnlyCollection<Servicio> CombinandoEspecificaciones(int tiendaId)
    {
        var especificacionServiciosDelDiaDeHoy = 
            new EspecificacionServicioDelDiaDeHoy();
        var especificacionPorTiendaId = 
            new EspecificacionPorTienda(tiendaId);
        var especificacionCombinada =
            especificacionServiciosDelDiaDeHoy.Y(especificacionPorTiendaId);

        var resultado = _repositorio.ListarServiciosUsandoEspecificacion(especificacionCombinada);
        return resultado;
    }

}
