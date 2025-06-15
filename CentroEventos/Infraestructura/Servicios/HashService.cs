using System.Security.Cryptography;
using System.Text;
using CentroEventos.Aplicacion.Servicios;

namespace CentroEventos.Infraestructura.Servicios;

public class HashService : IHashService
{
    public string Hash(string input)
    {
        using var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(input);
        var hash = sha256.ComputeHash(bytes);
        return Convert.ToHexString(hash);
    }
}
