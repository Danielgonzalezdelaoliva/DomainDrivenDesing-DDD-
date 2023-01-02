namespace Delgado.Ddd.Recepcion.Compartido.Modelos.Cliente
{
    public class ClienteDto
    {
        public int ClienteId { get; set; }
        public string NombreCompleto { get; set; }
        public string CorreoElectronico { get; set; }
        public string NumeroDeTelefono { get; set; }
        public int? PeluqueroIdFavorito { get; set; }
    }
}
