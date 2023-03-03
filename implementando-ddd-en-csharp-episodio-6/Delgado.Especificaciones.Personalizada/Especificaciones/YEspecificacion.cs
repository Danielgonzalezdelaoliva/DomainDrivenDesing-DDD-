using System.Linq.Expressions;
namespace Delgado.Especificaciones.Personalizada.Especificaciones;
public sealed class YEspecificacion<T> : Especificacion<T>
{
    private readonly Especificacion<T> _izquierda;
    private readonly Especificacion<T> _derecha;

    public YEspecificacion(Especificacion<T>izquierda, Especificacion<T>derecha)
    {
        _izquierda = izquierda;
        _derecha = derecha;
    }
    
    public override Expression<Func<T, bool>> ConvertirEspecificacionAExpresion()
    {
        Expression<Func<T,bool>> expresionDeLaIzquierda = 
            _izquierda.ConvertirEspecificacionAExpresion();

        Expression<Func<T, bool>> expresionDeLaDerecha =
            _derecha.ConvertirEspecificacionAExpresion();

        //Opciones: AndAlso, OrElse
        BinaryExpression yExpresion = 
            Expression.AndAlso(expresionDeLaDerecha.Body, expresionDeLaIzquierda.Body);

        return 
            Expression.Lambda<Func<T, bool>>(yExpresion, expresionDeLaIzquierda.Parameters.Single());
    }
}
