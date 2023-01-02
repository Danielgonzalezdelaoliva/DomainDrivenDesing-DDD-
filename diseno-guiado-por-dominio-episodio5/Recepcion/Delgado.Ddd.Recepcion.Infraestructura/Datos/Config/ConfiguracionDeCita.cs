using Delgado.Ddd.Recepcion.Dominio.AgregadosParaCalendario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delgado.Ddd.Recepcion.Infraestructura.Datos.Config
{
    public class ConfiguracionDeCita : IEntityTypeConfiguration<Cita>
    {
        public void Configure(EntityTypeBuilder<Cita> builder)
        {
            builder.ToTable("Citas").HasKey(x => x.Id);

            builder.Property(p => p.Id).ValueGeneratedNever();

            builder.OwnsOne(p => p.RangoDeFechaTiempo, p =>
            {
                p.Property(pp => pp.Comienzo)
                .HasColumnName("RangoDeTiempo_Comienzo");
                p.Property(pp => pp.Fin)
                .HasColumnName("RangoDeTiempo_Fin");
            });            
        }
    }
}
