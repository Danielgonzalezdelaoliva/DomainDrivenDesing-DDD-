using System;
using Delgado.Ddd.KernellCompartido;
using Delgado.Ddd.Recepcion.Dominio.AgregadosParaCalendario;

namespace Delgado.Ddd.Recepcion.Dominio.Eventos
{
    public class EventoCitaReservada: BaseDeEventoDeDominio
    {
        public EventoCitaReservada(Cita cita)
        {
            CitaReservada = cita;
        }

        public Guid Id { get; private set; } = Guid.NewGuid();
        public Cita CitaReservada { get; private set; }
    }
}
