namespace Delgado.Ddd.Recepcion.Compartido
{
    public class ConfiguracionDeBaseDeUrl
    {
        public const string NOMBRE_DE_CONFIGURACION = "baseDeUrls";

        /// <summary>
        /// El URL base para API
        /// </summary>
        public string BaseDeApi { get; set; }

        /// <summary>
        /// El URL base padra Web
        /// </summary>
        public string BaseDeWeb { get; set; }
    }
}
