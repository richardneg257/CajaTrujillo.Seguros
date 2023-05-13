using CajaTrujillo.Seguros.Repository.Interfaces;
using CajaTrujillo.Seguros.Service.Interfaces;

namespace CajaTrujillo.Seguros.Service.Implementaciones;
public class PagosService : IPagosService
{
    private readonly IPagosRepository _pagosRepository;

    public PagosService(IPagosRepository pagosRepository)
    {
        _pagosRepository = pagosRepository;
    }

    public async Task Pagar(string dni)
    {
        await _pagosRepository.Pagar(dni);
    }
}
