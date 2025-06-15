namespace CentroEventos.Aplicacion;
using System.Security.Cryptography;
using System.Text;

public static class HashHelper
{
    public static string ObtenerSHA256Hash(string input)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] hash = sha256.ComputeHash(bytes);
            return Convert.ToHexString(hash);
        }
    }
}




