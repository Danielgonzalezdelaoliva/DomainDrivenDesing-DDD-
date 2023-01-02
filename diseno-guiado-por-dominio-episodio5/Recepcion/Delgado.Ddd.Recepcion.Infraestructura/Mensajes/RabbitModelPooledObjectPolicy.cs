using System;
using Microsoft.Extensions.ObjectPool;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace Delgado.Ddd.Recepcion.Infraestructura.Mensajes
{
    public class RabbitModelPooledObjectPolicy : IPooledObjectPolicy<IModel>
    {
        private readonly IConnection _connection;

        public RabbitModelPooledObjectPolicy(
          IOptions<ConfiguracionRabitMq> rabbitMqOptions)
        {
            _connection = GetConnection(rabbitMqOptions.Value);
        }

        private IConnection GetConnection(ConfiguracionRabitMq settings)
        {
            var factory = new ConnectionFactory()
            {
                HostName = settings.Hostname,
                UserName = settings.UserName,
                Password = settings.Password,
                Port = settings.Port,
                VirtualHost = settings.VirtualHost,
            };

            return factory.CreateConnection();
        }

        public IModel Create()
        {
            return _connection.CreateModel();
        }

        public bool Return(IModel obj)
        {
            if (obj.IsOpen)
            {
                return true;
            }
            else
            {
                obj?.Dispose();
                return false;
            }
        }
    }
}
