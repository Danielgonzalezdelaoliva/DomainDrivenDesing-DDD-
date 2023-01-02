using Ardalis.Specification;

namespace Delgado.Ddd.KernellCompartido.Interfaces
{
    public interface IRepositorioDeLectura<T> : IReadRepositoryBase<T> where T : class, IRaizDeAgregado
    {
    }
}
