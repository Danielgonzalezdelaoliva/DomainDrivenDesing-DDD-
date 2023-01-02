using System.Collections.Generic;
using System.Reflection;
using Autofac;
using Delgado.Ddd.KernellCompartido.Interfaces;
using Delgado.Ddd.Recepcion.Dominio.AgregadosParaCalendario;
using Delgado.Ddd.Recepcion.Dominio.Interfaces;
using Delgado.Ddd.Recepcion.Infraestructura.Datos;
using Delgado.Ddd.Recepcion.Infraestructura.Mensajes;
using MediatR;
using Module = Autofac.Module;

namespace Delgado.Ddd.Recepcion.Infraestructura
{
    public class ModuloDeInfraestructura : Module
    {
        private readonly bool _isDevelopment = false;
        private readonly List<Assembly> _assemblies = new List<Assembly>();

        public ModuloDeInfraestructura(bool isDevelopment, Assembly callingAssembly = null)
        {
            _isDevelopment = isDevelopment;

            var coreAssembly = Assembly.GetAssembly(typeof(Calendario));
            _assemblies.Add(coreAssembly);

            var infrastructureAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            _assemblies.Add(infrastructureAssembly);

            if (callingAssembly != null)
            {
                _assemblies.Add(callingAssembly);
            }
        }

        protected override void Load(ContainerBuilder builder)
        {
            if (_isDevelopment)
            {
                RegistrarSoloDependenciasEnDesarrollo(builder);
            }
            else
            {
                RegistrarDependenciasEnProduccion(builder);
            }
            RegistrarDependenciasComunes(builder);
        }

        private void RegistrarDependenciasComunes(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(RepositorioEf<>))
                .As(typeof(IRepositorio<>))
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(RepositorioEf<>))
                .InstancePerLifetimeScope();

            // add a cache
            builder.RegisterGeneric(typeof(RepositorioCache<>))
              .As(typeof(IRepositorioDeLectura<>))
                .InstancePerLifetimeScope();

            builder.RegisterType(typeof(PublicadorDeMensajesRabbit))
              .As(typeof(IPublicadorDeMensaje))
              .InstancePerLifetimeScope();

           
            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            

            builder.RegisterType<AppDbContextDatos>().InstancePerLifetimeScope();
        }

        private void RegistrarSoloDependenciasEnDesarrollo(ContainerBuilder builder)
        {
            // Add development only services
        }

        private void RegistrarDependenciasEnProduccion(ContainerBuilder builder)
        {
            // Add production only services
        }
    }
}
