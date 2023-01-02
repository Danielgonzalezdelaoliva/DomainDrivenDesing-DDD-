using Ardalis.Specification;

namespace Delgado.Ddd.Recepcion.Dominio.AgregadosParaCalendario.Especificaciones
{
    public class CalendarioPorTiendaIdEsp : Specification<Calendario>, ISingleResultSpecification
    {
        public CalendarioPorTiendaIdEsp(int tiendaId)
        {
            Query
                .Where(calendario => calendario.TiendaId == tiendaId);
        }
    }
}
