using Microsoft.EntityFrameworkCore;

namespace Delgado.Especificaciones.Comun;

public class AppDbContext : DbContext
{
    public DbSet<Servicio> Servicios { get; set; }
}
