using Delgado.Especificaciones.Comun;
using System.Linq.Expressions;

namespace Delgado.Especificaciones.Personalizada.Especificaciones;

public sealed class EspecificacionServicioDelDiaDeHoy : Especificacion<Servicio>
{
    public override Expression<Func<Servicio, bool>> ConvertirEspecificacionAExpresion()
    {
        return servicio => servicio.Fecha > DateTime.Today.AddDays(-1);
    }
}
