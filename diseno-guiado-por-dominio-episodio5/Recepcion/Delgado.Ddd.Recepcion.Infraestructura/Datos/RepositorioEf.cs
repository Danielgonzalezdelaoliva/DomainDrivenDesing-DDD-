using Ardalis.Specification.EntityFrameworkCore;
using Delgado.Ddd.KernellCompartido.Interfaces;

namespace Delgado.Ddd.Recepcion.Infraestructura.Datos
{
    public class RepositorioEf<T> : RepositoryBase<T>, IRepositorio<T> where T : class, IRaizDeAgregado
    {
        public RepositorioEf(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
