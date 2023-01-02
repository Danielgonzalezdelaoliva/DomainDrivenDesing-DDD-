using System;
using System.ComponentModel.DataAnnotations;
using Delgado.Ddd.Recepcion.Compartido.Modelos.TipoDeCita;

namespace Delgado.Ddd.Recepcion.Compartido.Modelos.Cita
{
    /// <summary>
    /// DTO (Data Transfer Object) para Cita
    /// </summary>
    public class CitaDto
    {
        public Guid CitaId { get; set; }
        public Guid CalendarioId { get; set; }
        public int ClienteId { get; set; }
        public string NombreDelCliente { get; set; }

        [Required(ErrorMessage = "El campo de Tipo de Cita es requerido")]
        public int TipoDeCitaId { get; set; }

        public TipoDeCitaDto TipoDeCita { get; set; }

        [Required(ErrorMessage = "El campo Comienzo es requerido")]
        public DateTimeOffset Comienzo { get; set; }

        [Required(ErrorMessage = "El campo Fin es requerido")]
        public DateTimeOffset Fin { get; set; }

        public bool HayPosiblesConflictos { get; set; }
        public bool EstaConfirmada { get; set; }

        public CitaDto Copia { get; set; }

        public override string ToString()
        {
            return $"Id: {CitaId}\n{nameof(CalendarioId)}: {CalendarioId}\n{nameof(ClienteId)}: {ClienteId}\n{nameof(NombreDelCliente)}: {NombreDelCliente}\n{nameof(Comienzo)}: {Comienzo}\n{nameof(Fin)}:{Fin}";
        }
    }
}
