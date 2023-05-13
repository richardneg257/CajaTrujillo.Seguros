namespace CajaTrujillo.Seguros.Repository.Interfaces;
public interface IPagosRepository
{
    Task Pagar(string dni);
}
