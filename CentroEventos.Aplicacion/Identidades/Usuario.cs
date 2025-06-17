// Cadausuario debe tener nombre, apellido, correo electrónico, contraseña y una lista de permisos.
using System.Data.Common;

namespace CentroEventos.Aplicacion;

public class Usuario
{   
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public List<Permiso> Permisos { get; set; } = new List<Permiso>();

    public Usuario(string nom, string ape, string em)
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