namespace Delgado.Ddd.Recepcion.Compartido.Modelos.Cliente
{
    public class LlamadaBuscarPorClienteId: BaseDeLlamada
    {
        public const string Ruta = "api/clientes/{ClienteId}";

        public int ClienteId { get; set; }
    }
}
