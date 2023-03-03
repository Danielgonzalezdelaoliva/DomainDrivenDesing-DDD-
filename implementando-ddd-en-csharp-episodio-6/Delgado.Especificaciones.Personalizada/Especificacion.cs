using Delgado.Especificaciones.Personalizada.Especificaciones;
using System.Linq.Expressions;
namespace Delgado.Especificaciones.Personalizada;

public abstract class Especificacion<T>
{
    public bool EsSatisfechoPor(T entidad)
    {
        Func<T, bool> funcionDelegada = ConvertirEspecificacionAExpresion().Compile();
        return funcionDelegada(entidad);
    }

    //La logica es ecapsulada y no insertada en el codigo constructor de un consumidor
    //Una funciona que regresa la una expresion.
    public abstract Expression<Func<T, bool>> ConvertirEspecificacionAExpresion();

    public Especificacion<T> Y(Especificacion<T> especificacion)
    {
        return new YEspecificacion<T>(this, especificacion);
    }
}
