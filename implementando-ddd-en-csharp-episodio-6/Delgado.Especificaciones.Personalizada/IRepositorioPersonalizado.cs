using Delgado.Especificaciones.Comun;
using Delgado.Especificaciones.Personalizada.Especificaciones;

namespace Delgado.Especificaciones.Personalizada;

public interface IRepositorioPersonalizado
{
    IReadOnlyList<Servicio> ListarServiciosDelDiaDeHoy();
    IReadOnlyList<Servicio> ListarServiciosUsandoExpresion(Func<Servicio, bool> expresion);
    IReadOnlyList<Servicio> ListarServiciosUsandoExpresiones(Func<Servicio, bool> expresion1, Func<Servicio, bool> expresion2);
    IReadOnlyList<Servicio> ListarServiciosUsandoEspecificacionGenerica(EspecificacionGenerica<Servicio> especificacion);
    IReadOnlyCollection<Servicio> ListarServiciosUsandoEspecificacionDelDia(EspecificacionServicioDelDiaDeHoy especificacion);
    IReadOnlyCollection<Servicio> ListarServiciosUsandoEspecificacion(Especificacion<Servicio> especificacion);
}
