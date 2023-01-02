using System;
using Delgado.Ddd.Recepcion.Dominio.Interfaces;

namespace Delgado.Ddd.Recepcion.API
{
    public class ConfiguracionesDeOficina : IConfiguracionDeAplicacion
    {
        public ConfiguracionesDeOficina()
        {
        }

        public int TiendaId { get { return 1; } }

        public DateTimeOffset FechaDePrueba
        {
            get
            {
                return new DateTimeOffset(2030, 9, 23, 0, 0, 0, new TimeSpan(-4, 0, 0));
            }
        }
    }
}