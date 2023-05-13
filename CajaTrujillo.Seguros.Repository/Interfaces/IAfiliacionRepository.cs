using CajaTrujillo.Seguros.Entity;

namespace CajaTrujillo.Seguros.Repository.Interfaces;
public interface IAfiliacionRepository
{
    Task Afiliar(Afiliacion afiliacion);
}
