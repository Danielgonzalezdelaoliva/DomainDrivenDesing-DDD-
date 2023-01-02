using System;
using Ardalis.GuardClauses;
using Delgado.Ddd.KernellCompartido;
using Delgado.Ddd.Recepcion.Dominio.AgregadosSincronizados;
using Delgado.Ddd.Recepcion.Dominio.Eventos;

namespace Delgado.Ddd.Recepcion.Dominio.AgregadosParaCalendario
{
    public class Cita: EntidadBase<Guid>
    {
        

        public Cita()
        {
        }

        public Cita(Guid id, Guid calendarioId, int clienteId, int peluqueroId, int tiendaId, int tipoDeCitaId, RangoDeFechaTiempo rangoDeFechaTiempo, DateTimeOffset fechaDeConfirmacion)
        {
            Id = Guard.Against.Default(id, nameof(id));
            CalendarioId = Guard.Against.Default(calendarioId, nameof(calendarioId));
            ClienteId = Guard.Against.NegativeOrZero(clienteId, nameof(clienteId));
            PeluqueroId = Guard.Against.NegativeOrZero(peluqueroId, nameof(peluqueroId));
            TiendaId = Guard.Against.NegativeOrZero(tiendaId, nameof(tiendaId));
            TipoDeCitaId = Guard.Against.NegativeOrZero(tipoDeCitaId, nameof(tipoDeCitaId));
            RangoDeFechaTiempo = Guard.Against.Null(rangoDeFechaTiempo,nameof(rangoDeFechaTiempo));
            FechaDeConfirmacion = fechaDeConfirmacion;
        }

        public Guid CalendarioId { get; private set; }
        public int ClienteId { get; private set; }
        public int? PeluqueroId { get; private set; }
        public int? TiendaId { get; private set; }
        public int TipoDeCitaId { get; private set; }

        public RangoDeFechaTiempo RangoDeFechaTiempo { get; private set; }
        public DateTimeOffset FechaDeConfirmacion { get; private set; }
        public bool HayPosibleConflicto { get; set; }


        /// <summary>
        /// Actualizar el tipo de cita
        /// </summary>
        /// <param name="tipoDeCita">El tipo de cita</param>
        /// <param name="accionDeCalendario">La accion a tomar</param>
        public void ActualizarTipoDeCita(TipoDeCita tipoDeCita, Action accionDeCalendario)
        {
            Guard.Against.Null(tipoDeCita, nameof(tipoDeCita));

            if (TipoDeCitaId == tipoDeCita.Id) return;
            RangoDeFechaTiempo = RangoDeFechaTiempo.NewEnd(RangoDeFechaTiempo.Comienzo.AddMinutes(tipoDeCita.Duracion));

            TipoDeCitaId = tipoDeCita.Id;

            accionDeCalendario?.Invoke();

            var evento = new EventoCitaActualizada(this);
            Eventos.Add(evento);

        }

        //Otras funciones van aca como: confirmar cita, etc. suguiendo el mismo patron con el metodo anterior
    }
}
