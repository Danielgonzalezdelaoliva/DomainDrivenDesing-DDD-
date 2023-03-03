namespace Delgado.Funciones;

public class Historial
{
    public DateTime Fecha { get; private set; }
    public Guid TipoDeServicioId { get; private set; }
    public string TipoDeServicio { get; private set; }
    public decimal Precio { get; private set; }
    public Guid TiendaId { get; private set; }
    public string Tienda { get; private set; }

    public Historial(DateTime fecha,
                      Guid tipoDeServicioId,
                      string tipoDeServicio,
                      decimal precio,
                      Guid tiendaId,
                      string tienda)
    {
        Fecha = fecha;
        TipoDeServicioId = tipoDeServicioId;
        TipoDeServicio = tipoDeServicio;
        Precio = precio;
        TiendaId = tiendaId;
        Tienda = tienda;
    }
}

public static class HistorialDeDatos
{
    public static List<Historial> ListaDeHistorial()
    {
        return new List<Historial>
        {
            //new Historial(DateTime.Now, )
        };
    }
}


