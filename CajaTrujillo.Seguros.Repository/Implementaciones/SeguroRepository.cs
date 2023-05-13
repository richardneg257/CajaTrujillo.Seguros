using CajaTrujillo.Seguros.Entity;
using CajaTrujillo.Seguros.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CajaTrujillo.Seguros.Repository.Implementaciones;
public class SeguroRepository : ISeguroRepository
{
    private readonly CajaTrujilloDbContext _context;

    public SeguroRepository(CajaTrujilloDbContext context)
    {
        _context = context;
    }

    public async Task<Seguro?> ObtenerSeguroPorTipo(string tipoSeguro)
    {
        var seguroEntity = await _context.Seguros.FirstOrDefaultAsync(x => x.TipoSeguro == tipoSeguro);
        return seguroEntity;
    }
}
