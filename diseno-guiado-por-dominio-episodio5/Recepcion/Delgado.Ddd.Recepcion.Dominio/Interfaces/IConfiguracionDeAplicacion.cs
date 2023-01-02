using System;
namespace Delgado.Ddd.Recepcion.Dominio.Interfaces
{
    
        public interface IConfiguracionDeAplicacion
        {
            int TiendaId { get; }
            DateTimeOffset FechaDePrueba { get; }
        }
    
}
