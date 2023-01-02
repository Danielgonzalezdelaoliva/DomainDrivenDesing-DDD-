using System;
using Delgado.Ddd.KernellCompartido;
using Delgado.Ddd.Recepcion.Dominio.AgregadosParaCalendario;

namespace Delgado.Ddd.Recepcion.Dominio.Eventos
{
    public class EventoCitaActualizada: BaseDeEventoDeDominio
    {
        public EventoCitaActualizada(Cita cita)
        {
            CitaActualizada = cita;
        }

        public Guid Id { get; private set; } = Guid.NewGuid();
        public Cita CitaActualizada { get; private set; }
    }
}
