using Ardalis.Specification;

namespace Delgado.Ddd.Recepcion.Dominio.AgregadosSincronizados.Especificaciones.Clientes
{
    public class ClientePorIdEsp: Specification<Cliente>, ISingleResultSpecification
    {
        public ClientePorIdEsp(int id)
        {
            Query.Where(cliente => cliente.Id == id);
        }
    }
}
