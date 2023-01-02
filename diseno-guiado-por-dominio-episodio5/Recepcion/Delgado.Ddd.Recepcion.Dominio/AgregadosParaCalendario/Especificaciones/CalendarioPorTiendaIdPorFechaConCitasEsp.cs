using System;
using Ardalis.Specification;
using System.Linq;

namespace Delgado.Ddd.Recepcion.Dominio.AgregadosParaCalendario.Especificaciones
{
    public class CalendarioPorTiendaIdPorFechaConCitasEsp : Specification<Calendario>, ISingleResultSpecification
    {
        public CalendarioPorTiendaIdPorFechaConCitasEsp(int tiendaId, DateTimeOffset fecha)
        {
            var fechaFin = fecha.AddDays(1);
            Query
                .Where(calendario => calendario.TiendaId == tiendaId &&
                    calendario.Citas != null)
                .Include(x => x.Citas.Where(cita => cita.RangoDeFechaTiempo.Comienzo > fecha && cita.RangoDeFechaTiempo.Fin < fechaFin));
        }
    }
}
