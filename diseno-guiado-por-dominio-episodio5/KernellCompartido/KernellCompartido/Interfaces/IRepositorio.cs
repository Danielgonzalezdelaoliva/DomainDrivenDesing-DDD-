using Ardalis.Specification;

namespace Delgado.Ddd.KernellCompartido.Interfaces
{
    public interface IRepositorio<T> : IRepositoryBase<T> where T : class, IRaizDeAgregado
    {
    }
}
