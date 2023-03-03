using System.Linq.Expressions;

namespace Delgado.Especificaciones;

public interface IEspecificacion<TEntidad>
{
    Expression<Func<TEntidad, bool>> Criterios { get; }
    List<Expression<Func<TEntidad, object>>> ExpresionesParaIncluir { get; }
    List<string> LetrasParaIncluir { get; }
}
