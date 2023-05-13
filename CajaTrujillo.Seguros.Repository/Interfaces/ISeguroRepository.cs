using CajaTrujillo.Seguros.Entity;

namespace CajaTrujillo.Seguros.Repository.Interfaces;
public interface ISeguroRepository
{
    Task<Seguro?> ObtenerSeguroPorTipo(string tipoSeguro);
}
