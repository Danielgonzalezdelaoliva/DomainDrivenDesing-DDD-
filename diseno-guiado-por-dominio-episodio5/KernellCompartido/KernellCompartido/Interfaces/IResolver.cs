using System.Threading.Tasks;

namespace Delgado.Ddd.KernellCompartido.Interfaces
{
    public interface IResolver<T> where T : BaseDeEventoDeDominio
    {
        Task ResolverAsync(T args);
    }
}
