namespace Delgado.NucleoCompartido.Interfaces;

public interface IRepositorio<T> : IRepositorioDeLectura<T> where T : class, IRaizAgregada
{
    Task<T> Agregar(T entidad, CancellationToken tokenDeCancelacion = default);
    Task Actualizar(T entidad, CancellationToken tokenDeCancelacion = default);
    Task Eliminar(T entidad, CancellationToken tokenDeCancelacion = default);
    Task EliminarVarios(IEnumerable<T> entidades, CancellationToken tokenDeCancelacion = default);
    Task<int> SalvarCambios(CancellationToken tokenDeCancelacion = default);
}
