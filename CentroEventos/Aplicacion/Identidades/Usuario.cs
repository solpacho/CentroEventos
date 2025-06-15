// Cadausuario debe tener nombre, apellido, correo electrónico, contraseña y una lista de permisos.
using System.Data.Common;

namespace CentroEventos.Aplicacion;

public class Usuario
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Email { get; set; }
    public string Password { get; private set; }
    public List<Permiso> Permisos { get; set; } = new List<Permiso>();

    public Usuario(string nom, string ape, string em, string passw)
    {
        Nombre = nom;
        Apellido = ape;
        Email = em;
    }

    public Usuario() { }

    public override String ToString()
    {
        return $"Nombre: {Nombre}, Apellido: {Apellido}, Email: {Email}";
    }

}