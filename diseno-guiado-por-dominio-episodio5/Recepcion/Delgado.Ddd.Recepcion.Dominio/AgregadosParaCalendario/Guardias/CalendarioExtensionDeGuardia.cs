using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using Delgado.Ddd.Recepcion.Dominio.Excepciones;

namespace Delgado.Ddd.Recepcion.Dominio.AgregadosParaCalendario.Guardias
{
    public static class CalendarioExtensionDeGuardia
    {
        public static void CitaDuplicada(this IGuardClause guardia, IEnumerable<Cita> citasExistentes, Cita nuevaCita, string nombreDelParametro)
        {
            if (citasExistentes.Any(a => a.Id == nuevaCita.Id))
            {
                throw new ExcepcionCitaDuplicada("No puede ingresar una cita duplicada al calendario.", nombreDelParametro);
            }
        }
    }
}
