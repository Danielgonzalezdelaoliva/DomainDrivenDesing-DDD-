using System;
namespace Delgado.Ddd.Recepcion.Compartido.Modelos.Cliente
{
    public class LlamadaCrearCliente: BaseDeLlamada
    {
        //Ver que la diferencia entre este objeto y el ClienteDto es el clientId
        //Por ello, el DTO se usa en la respuesta y no en la llamada
        
        public string NombreCompleto { get; set; }
        public string CorreoElectronico { get; set; }
        public string NumeroDeTelefono { get; set; }
        public int? PeluqueroIdFavorito { get; set; }
    }
}
