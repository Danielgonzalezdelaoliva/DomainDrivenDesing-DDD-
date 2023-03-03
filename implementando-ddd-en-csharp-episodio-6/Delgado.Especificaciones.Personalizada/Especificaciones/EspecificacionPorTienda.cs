using Delgado.Especificaciones.Comun;
using System.Linq.Expressions;

namespace Delgado.Especificaciones.Personalizada.Especificaciones;

public sealed class EspecificacionPorTienda : Especificacion<Servicio>
{
    private readonly int _tiendaId;
    public EspecificacionPorTienda(int tiendaId)
    {
        _tiendaId = tiendaId;
    }
    
    public override Expression<Func<Servicio, bool>> ConvertirEspecificacionAExpresion()
    {
        return servicio => servicio.TiendaId == _tiendaId;
    }
}
