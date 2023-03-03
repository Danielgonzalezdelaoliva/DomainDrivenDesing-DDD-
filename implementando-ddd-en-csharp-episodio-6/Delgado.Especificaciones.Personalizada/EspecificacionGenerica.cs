using System.Linq.Expressions;
namespace Delgado.Especificaciones.Personalizada;

public class EspecificacionGenerica<T>
{
    public Expression<Func<T, bool>> Expresion { get; }
    
    public EspecificacionGenerica(Expression<Func<T, bool>> expresion)
    {
        Expresion = expresion;
    }

    public bool EsSatisfechaPor(T entidad)
    {
        return Expresion.Compile().Invoke(entidad);
    }
}
