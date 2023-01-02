using System;
using System.Text;
using System.Text.Json;
using Ardalis.GuardClauses;
using Delgado.Ddd.Recepcion.Dominio.Eventos.EventosDeIntegracion;
using Delgado.Ddd.Recepcion.Dominio.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.ObjectPool;
using RabbitMQ.Client;

namespace Delgado.Ddd.Recepcion.Infraestructura.Mensajes
{
    public class PublicadorDeMensajesRabbit : IPublicadorDeMensaje
    {
        private readonly DefaultObjectPool<IModel> _objectPool;
        private readonly ILogger<PublicadorDeMensajesRabbit> _logger;

        public PublicadorDeMensajesRabbit(IPooledObjectPolicy<IModel> objectPolicy, ILogger<PublicadorDeMensajesRabbit> logger)
        {
            _objectPool = new DefaultObjectPool<IModel>(objectPolicy, Environment.ProcessorCount * 2);
            _logger = logger;
        }

        public void Publicar(EventoDeIntegracionCitaReservada evento)
        {
            Guard.Against.Null(evento, nameof(evento));

            var channel = _objectPool.Get();

            object message = (object)evento;
            try
            {
                string exchangeName = "Intecambio_de_Recepcion";
                channel.ExchangeDeclare(exchangeName, "direct", true, false, null);

                var messageString = JsonSerializer.Serialize(message);
                var sendBytes = Encoding.UTF8.GetBytes(messageString);

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                channel.BasicPublish(
                  exchange: exchangeName,
                  routingKey: "cita-reservada",
                  basicProperties: properties,
                  body: sendBytes);
                _logger.LogInformation($"Enviando evento de cita reservada: {messageString}");
            }
            finally
            {
                _objectPool.Return(channel);
            }
        }
    }
}
