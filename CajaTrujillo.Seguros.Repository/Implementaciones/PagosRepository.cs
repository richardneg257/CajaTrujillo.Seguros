using CajaTrujillo.Seguros.Entity;
using CajaTrujillo.Seguros.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CajaTrujillo.Seguros.Repository.Implementaciones;
public class PagosRepository : IPagosRepository
{
    private readonly CajaTrujilloDbContext _context;

    public PagosRepository(CajaTrujilloDbContext context)
    {
        _context = context;
    }

    public async Task Pagar(string dni)
    {
        var cliente = await _context.Clientes.Include(x => x.Afiliaciones).ThenInclude(x => x.Seguro).FirstOrDefaultAsync(x => x.Dni == dni);
        foreach(var afiliacion in cliente.Afiliaciones)
        {
            var fechaAfiliacionPrimerDia = new DateTime(afiliacion.FechaAfiliacion.Year, afiliacion.FechaAfiliacion.Month, 1);
            var ahora = DateTime.Now;
            var fechaActualPrimerDia = new DateTime(ahora.Year, ahora.Month, 1);
            var fechaRecorrido = fechaAfiliacionPrimerDia;
            while(fechaRecorrido < fechaActualPrimerDia)
            {
                var pago = await _context.Pagos.FirstOrDefaultAsync(x => x.AfiliacionId == afiliacion.Id && x.Anio == fechaAfiliacionPrimerDia.Year && x.Mes == fechaAfiliacionPrimerDia.Month);
                if(pago == null)
                {
                    _context.Pagos.Add(new Pago()
                    {
                        AfiliacionId = afiliacion.Id,
                        Anio = fechaRecorrido.Year,
                        Mes = fechaRecorrido.Month
                    });
                }
                fechaRecorrido = fechaRecorrido.AddMonths(1);
            }
        }

        await _context.SaveChangesAsync();
    }
}
