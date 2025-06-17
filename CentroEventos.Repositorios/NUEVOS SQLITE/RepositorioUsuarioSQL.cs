
using CentroEventos.Aplicacion;

namespace CentroEventos.Repositorios;

public class RepositorioUsuarioSQL : IRepositorioUsuario
{
    private readonly RepositorioContext _context;

    public RepositorioUsuarioSQL(RepositorioContext context)
    {
        _context = context;
    }
    public Usuario? ObtenerUsuario(int id)
    {
        return _context.Usuarios.FirstOrDefault(u => u.Id == id);
    }
    public Usuario? ValidarCredenciales(string email, string passwordHash)
    {
        return _context.Usuarios
        .FirstOrDefault(u => u.Email.ToLower() == email.ToLower()
                          && u.PasswordHash == passwordHash);
    }
    public void AgregarUsuario(Usuario u)
    {

        {
            _context.Usuarios.Add(u);
            _context.SaveChanges();
        }
    }
    public bool ExisteUsuario(int id)
    {
        
        {
            return _context.Usuarios.Any(u => u.Id == id);
        }
    }
    public void EliminarUsuario(int id)
    {
        
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
            }
        }

    }
    public List<Usuario> Listar()
    {
        {
            return _context.Usuarios.ToList();
        }
    }
    public void ModificarUsuario(int id, Usuario u) // CHEQUEAR SI ESTÁ BIEN
    {
        
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario != null)
            {
                usuario.Nombre = u.Nombre;
                usuario.Apellido = u.Apellido;
                usuario.Email = u.Email;
                usuario.PasswordHash = u.PasswordHash;

                _context.SaveChanges();
            }

        }
    }

    public List<Usuario> ListarUsuarios()
    {
        
        {
            return _context.Usuarios.ToList();
        }
    }

    public bool EmailRepetido(string email)
    {
        
        {
            return _context.Usuarios.Any(u => u.Email == email);
        }
    }

    public int ContarUsuarios()
    {
        
        {
            return _context.Usuarios.Count();
        }
    }
    public Usuario? ObtenerPorCorreo(string email)
    {
        return _context.Usuarios.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
    }
}