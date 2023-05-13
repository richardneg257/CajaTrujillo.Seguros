using CajaTrujillo.Seguros.Entity;
using CajaTrujillo.Seguros.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CajaTrujillo.Seguros.Repository.Implementaciones;
public class ClienteRepository : IClienteRepository
{
    private readonly CajaTrujilloDbContext _context;

    public ClienteRepository(CajaTrujilloDbContext context)
    {
        _context = context;
    }

    public async Task<Cliente?> ObtenerPorDniOPorApellidos(string dni, string apellidos)
    {
        var clienteEntity = await _context.Clientes.FirstOrDefaultAsync(x => x.Dni == dni || x.Apellidos == apellidos);
        return clienteEntity;
    }
}
