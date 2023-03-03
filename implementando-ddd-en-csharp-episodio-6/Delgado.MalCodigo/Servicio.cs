namespace Delgado.MalCodigo;

public class Servicio
{
    public int Id { get; set; }
    public int TiendaId { get; set; }
    public string TipoDeServicio { get; set; }
    public decimal Precio { get; set;}
    public int EmpleadoId { get; set; }
    public int ClienteId { get; set; }
    public DateTime Fecha { get; set; }

    public virtual bool EsServicioDeHoy()
    {
        return Fecha > DateTime.Today.AddDays(-1);
    }
}
