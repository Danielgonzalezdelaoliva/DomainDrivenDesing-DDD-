using Microsoft.EntityFrameworkCore;

namespace Delgado.MalCodigo;

public class AppDbContext: DbContext
{
    public DbSet<Servicio> Servicios { get; set; }
}
