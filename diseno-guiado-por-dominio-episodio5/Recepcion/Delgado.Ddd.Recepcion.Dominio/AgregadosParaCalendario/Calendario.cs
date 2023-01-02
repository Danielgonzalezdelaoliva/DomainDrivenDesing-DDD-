using System;
using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using Delgado.Ddd.KernellCompartido;
using Delgado.Ddd.KernellCompartido.Interfaces;
using Delgado.Ddd.Recepcion.Dominio.AgregadosParaCalendario.Guardias;
using Delgado.Ddd.Recepcion.Dominio.Eventos;

namespace Delgado.Ddd.Recepcion.Dominio.AgregadosParaCalendario
{
    public class Calendario: EntidadBase<Guid>, IRaizDeAgregado
    {
        public Calendario(Guid id, RangoDeFechaTiempo rangoDeFechaTiempo, int tiendaId)
        {
            Id = Guard.Against.Default(id, nameof(id));
            RangoDeFechaTiempo = rangoDeFechaTiempo;
            TiendaId = Guard.Against.NegativeOrZero(tiendaId, nameof(tiendaId));
        }

        public Calendario(Guid id, int tiendaId)
        {
            Id = Guard.Against.Default(id, nameof(id));
            TiendaId = Guard.Against.NegativeOrZero(tiendaId, nameof(tiendaId));
        }


        public int TiendaId { get; private set; }
        private readonly List<Cita> _citas = new List<Cita>();
        public IEnumerable<Cita> Citas => _citas.AsReadOnly();
        public RangoDeFechaTiempo RangoDeFechaTiempo { get; private set; }

        public Cita AgregarCita(Cita cita)
        {
            Guard.Against.Null(cita, nameof(cita));
            Guard.Against.Default(cita.Id, nameof(cita.Id));
            Guard.Against.CitaDuplicada(_citas, cita, nameof(cita));


            _citas.Add(cita);
            MarcarCitaConflictiva();

            var evento = new EventoCitaReservada(cita);
            Eventos.Add(evento);

            return cita;
        }

        private void MarcarCitaConflictiva()
        {
            foreach (var cita in _citas)
            {
                //el mismo cliente no puede tener dos citas
                var citasPosiblementeConflictivas = _citas
                    .Where(c => c.ClienteId == cita.ClienteId &&
                    c.RangoDeFechaTiempo.Overlaps(cita.RangoDeFechaTiempo) &&
                    c != cita)
                    .ToList();

                citasPosiblementeConflictivas.ForEach(c => c.HayPosibleConflicto = true);
                cita.HayPosibleConflicto = citasPosiblementeConflictivas.Any();
            }            
        }

    }
}
