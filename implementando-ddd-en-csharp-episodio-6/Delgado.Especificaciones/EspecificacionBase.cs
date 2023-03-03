using System.Linq.Expressions;

namespace Delgado.Especificaciones;

public abstract class EspecificacionBase<TEntidad> : IEspecificacion<TEntidad>
{
    public EspecificacionBase(Expression<Func<TEntidad, bool>> criterios)
    {
        Criterios = criterios;
    }

    public Expression<Func<TEntidad, bool>> Criterios { get; }

    public List<Expression<Func<TEntidad, object>>> ExpresionesParaIncluir => new();

    public List<string> LetrasParaIncluir => new();

    protected virtual void AgregarExpresion(Expression<Func<TEntidad, object>> expresion)
    {
        ExpresionesParaIncluir.Add(expresion);
    }

    protected virtual void AgregarExpresion(string letraParaIncluir)
    {
        LetrasParaIncluir.Add(letraParaIncluir);
    }
}
