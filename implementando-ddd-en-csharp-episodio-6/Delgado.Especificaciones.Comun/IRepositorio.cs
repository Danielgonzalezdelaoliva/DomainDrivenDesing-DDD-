namespace Delgado.Especificaciones.Comun;

public interface IRepositorio
{
    IReadOnlyList<Servicio> ListarServiciosDelDiaDeHoy();
    IReadOnlyList<Servicio> ListarServiciosUsandoExpresion(Func<Servicio,bool> expresion);
    IReadOnlyList<Servicio> ListarServiciosUsandoExpresiones(Func<Servicio, bool> expresion1, Func<Servicio, bool> expresion2);    
}
