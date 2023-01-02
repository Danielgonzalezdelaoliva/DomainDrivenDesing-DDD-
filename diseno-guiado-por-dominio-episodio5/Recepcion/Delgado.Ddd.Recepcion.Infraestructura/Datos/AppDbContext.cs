using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Delgado.Ddd.KernellCompartido;
using Delgado.Ddd.Recepcion.Dominio.AgregadosParaCalendario;
using Delgado.Ddd.Recepcion.Dominio.AgregadosSincronizados;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Delgado.Ddd.Recepcion.Infraestructura.Datos
{
    public class AppDbContext : DbContext
    {
        private readonly IMediator _mediator;

        public AppDbContext(DbContextOptions<AppDbContext> options, IMediator mediator)
            : base(options)
        {
            _mediator = mediator;
        }

        public DbSet<Calendario> Calendarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<TipoDeCita> TiposDeCita { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


        /// <summary>
        /// TODO: Usar DbContext.SavedChanges event (evento) y handler (accion) para dara trabajar con eventos
        /// <para>
        /// https://docs.microsoft.com/en-us/ef/core/logging-events-diagnostics/events
        /// </para>
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // ignore events if no dispatcher provided
            if (_mediator == null) return result;

            var entitiesWithEvents = ChangeTracker
                .Entries()
                .Select(e => e.Entity as EntidadBase<Guid>)
                .Where(e => e?.Eventos != null && e.Eventos.Any())
                .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.Eventos.ToArray();
                entity.Eventos.Clear();
                foreach (var domainEvent in events)
                {
                    await _mediator.Publish(domainEvent).ConfigureAwait(false);
                }
            }

            return result;
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}
