using MediatR;
namespace Delgado.Ddd.Recepcion.Infraestructura.Datos.Sincronizaciones
{
    public class ComandoParaActualizarCliente: IRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
