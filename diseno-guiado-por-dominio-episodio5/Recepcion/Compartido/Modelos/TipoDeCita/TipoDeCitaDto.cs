namespace Delgado.Ddd.Recepcion.Compartido.Modelos.TipoDeCita
{
    /// <summary>
    /// DTO (Data Transfer Object) para el tipo de cita
    /// </summary>
    public class TipoDeCitaDto
    {
        public int TipoCitaId { get; set; }
        public string Nombre { get; set; }
        public int Duracion { get; set; }
    }
}
