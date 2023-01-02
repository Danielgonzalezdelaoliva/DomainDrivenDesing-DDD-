using Delgado.Ddd.Recepcion.Dominio.AgregadosParaCalendario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delgado.Ddd.Recepcion.Infraestructura.Datos.Config
{
    public class ConfiguracionDeCalendario : IEntityTypeConfiguration<Calendario>
    {
        public void Configure(EntityTypeBuilder<Calendario> builder)
        {
            builder.Property(p => p.Id).ValueGeneratedNever();
            builder.Ignore(s => s.RangoDeFechaTiempo);
        }
    }
}
