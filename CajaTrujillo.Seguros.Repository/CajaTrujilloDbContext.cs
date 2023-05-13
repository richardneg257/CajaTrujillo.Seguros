using CajaTrujillo.Seguros.Entity;
using Microsoft.EntityFrameworkCore;

namespace CajaTrujillo.Seguros.Repository;
public class CajaTrujilloDbContext : DbContext
{
    public CajaTrujilloDbContext(DbContextOptions<CajaTrujilloDbContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Seguro> Seguros { get; set; }
    public DbSet<Pago> Pagos { get; set; }
    public DbSet<Afiliacion> Afiliaciones { get; set; }
}
