using Delgado.Ddd.Recepcion.Dominio.Eventos.EventosDeIntegracion;

namespace Delgado.Ddd.Recepcion.Dominio.Interfaces
{
    public interface IPublicadorDeMensaje
    {
        void Publicar(EventoDeIntegracionCitaReservada evento);
    }
}
