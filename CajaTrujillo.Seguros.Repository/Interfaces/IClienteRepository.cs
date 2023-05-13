using CajaTrujillo.Seguros.Entity;

namespace CajaTrujillo.Seguros.Repository.Interfaces;
public interface IClienteRepository
{
    Task<Cliente?> ObtenerPorDniOPorApellidos(string dni, string apellidos);
}
