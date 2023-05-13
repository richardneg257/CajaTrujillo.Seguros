using CajaTrujillo.Seguros.Entity;
using CajaTrujillo.Seguros.Repository.Interfaces;

namespace CajaTrujillo.Seguros.Repository.Implementaciones;
public class AfiliacionRepository : IAfiliacionRepository
{
    private readonly CajaTrujilloDbContext _context;

    public AfiliacionRepository(CajaTrujilloDbContext context)
    {
        _context = context;
    }

    public async Task Afiliar(Afiliacion afiliacion)
    {
        _context.Afiliaciones.Add(afiliacion);
        await _context.SaveChangesAsync();
    }
}
