using System;
using System.Collections.Generic;

namespace Delgado.Ddd.Recepcion.Compartido.Modelos.Calendario
{
    public class CalendarioDto
    {
        public Guid Id { get; set; }
        public int TiendaId { get; set; }
        public DateTime Comienzo { get; set; }
        public DateTime Fin { get; set; }

        public List<Guid> CitaIds { get; set; } = new List<Guid>();

    }
}