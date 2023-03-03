namespace Delgado.MalCodigo;

public interface IRepositorio
{
    IReadOnlyList<Servicio> ListarServiciosPorTienda(int tiendaId, int numeroDeMesesAtras);
    IReadOnlyList<Servicio> ListarServiciosDelDiaDeHoyPorTienda(int tiendaId);
    IReadOnlyList<Servicio> ListarServiciosDelDiaDeHoyPorTienda_v2(int tiendaId);
}
