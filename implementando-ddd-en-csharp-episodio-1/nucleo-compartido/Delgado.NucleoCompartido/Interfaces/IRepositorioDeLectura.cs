using Ardalis.Specification;
namespace Delgado.NucleoCompartido.Interfaces;
/// <summary>
/// Interface definiendo funcionalidad para solamente leer registros de una base de datos
/// </summary>
/// <typeparam name="T">T representa el objeto agregado</typeparam>
public interface IRepositorioDeLectura<T> where T : class, IRaizAgregada
{

    //ISingleResultSpecification --> esperar solo un resultado
    Task<T> BuscarPorEspecificacion<Especificacion>(
            Especificacion especificacion,
            CancellationToken tokenDeCancelacion = default)
            where Especificacion : ISingleResultSpecification, ISpecification<T>;

    // variable generiaca TResultado para incluir por ejemplo ActionResult
    Task<TResultado> BuscarPorEspecificacion<TResultado>(
        ISpecification<T, TResultado> especificacion,
        CancellationToken tokenDeCancelacion = default);

    Task<List<T>> Listar(CancellationToken tokenDeCancelacion = default);

    Task<List<T>> Listar(
        ISpecification<T> especificacion,
        CancellationToken tokenDeCancelacion = default);

    Task<List<TResultado>> Listar<TResultado>(
        ISpecification<T, TResultado> especificacion,
        CancellationToken tokenDeCancelacion = default);
}
