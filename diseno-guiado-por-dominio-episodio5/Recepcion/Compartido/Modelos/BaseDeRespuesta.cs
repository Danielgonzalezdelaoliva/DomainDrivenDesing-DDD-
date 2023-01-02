using System;
namespace Delgado.Ddd.Recepcion.Compartido.Modelos
{
    /// <summary>
    /// Clase base para las respuestas de API
    /// <para>
    ///  Base class for API responses 
    /// </para>
    /// </summary>
    public abstract class BaseDeRespuesta: BaseDeMensaje
    {
        public BaseDeRespuesta()
        {

        }

        public BaseDeRespuesta(Guid correlationId): base()
        {
            base._correlationId = correlationId;
        }
    }
}
