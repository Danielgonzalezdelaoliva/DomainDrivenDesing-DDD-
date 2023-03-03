using System.Linq.Expressions;
namespace Delgado.Especificaciones.Comun;
public class Servicio
{
    public int Id { get; set; }
    public int TiendaId { get; set; }
    public string TipoDeServicio { get; set; }
    public decimal Precio { get; set; }
    public int EmpleadoId { get; set; }
    public int ClienteId { get; set; }
    public DateTime Fecha { get; set; }

    //Usando expresiones. LINQ se convierte en SQL cuando usamos ORM
    //Vemos low-level detail. Noy hay abstraccion
    public static readonly Expression<Func<Servicio, bool>> 
        EsDeHoy = x => x.Fecha > DateTime.Today.AddDays(-1);
    public static readonly Expression<Func<Servicio, bool>>
        EsDeHoyYAntesQueHoy = x => x.Fecha <= DateTime.Today;
}
