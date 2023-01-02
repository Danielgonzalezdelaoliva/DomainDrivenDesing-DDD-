using Delgado.Ddd.Recepcion.Dominio.AgregadosSincronizados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delgado.Ddd.Recepcion.Infraestructura.Datos.Config
{
    public class ConfiguracionDeCliente : IEntityTypeConfiguration<Cliente>
    {
        
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes").HasKey(x => x.Id);

            builder.Property(c => c.CorreoElectronico)
              .HasMaxLength(ConstantesDeColumna.MAX_LARGO_DE_NOMBRE);

            builder.Property(c => c.NombreCompleto)
              .HasMaxLength(ConstantesDeColumna.MAX_LARGO_DE_NOMBRE);
        }
    }
}
