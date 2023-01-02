using System;
using Ardalis.Specification;
namespace Delgado.Ddd.Recepcion.Dominio.AgregadosParaCalendario.Especificaciones
{
    public class CalendarioPorIdConCitasEsp: Specification<Calendario>, ISingleResultSpecification
    {
        public CalendarioPorIdConCitasEsp(Guid id)
        {
            Query
                .Where(calendario => calendario.Id == id)
                .Include(calendario => calendario.Citas);;
        }
    }
}
