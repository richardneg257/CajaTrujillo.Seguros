using System.Text;

namespace CajaTrujillo.Seguros.Repository.Helpers;
public static class Helpers
{
    public static string CrearStringAleatorio(int cantidadLetras)
    {
        var alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var sb = new StringBuilder();
        var rnd = new Random();

        for (int i = 0; i < cantidadLetras; i++)
        {
            int indice = rnd.Next(alfabeto.Length);
            sb.Append(alfabeto[indice]);
        }

        return sb.ToString();
    }

    public static int CalcularEdad(DateTime fechaNacimiento)
    {
        var fechaHoy = DateTime.Today;

        var edad = fechaHoy.Year - fechaNacimiento.Year;
        if (fechaNacimiento.AddYears(edad) < fechaHoy)
        {
            edad--;
        }

        return edad;
    }
}
