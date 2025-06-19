
using CentroEventos.Aplicacion;

namespace CentroEventos.Repositorios;

public class RepositorioUsuarioSQL : IRepositorioUsuario
{
    
    public Usuario? ObtenerUsuario(int id)
    {
        using (var _context = new RepositorioContext())
        {
            return _context.Usuarios.FirstOrDefault(u => u.Id == id);
        }
    }
    public Usuario? ValidarCredenciales(string email, string passwordHash)
    {
        using (var _context = new RepositorioContext())
        {
            return _context.Usuarios
            .FirstOrDefault(u => u.Email.ToLower() == email.ToLower()
                              && u.PasswordHash == passwordHash);
        }
    }
    public void AgregarUsuario(Usuario u)
    {
         using (var _context = new RepositorioContext())
        {
            _context.Usuarios.Add(u);
            _context.SaveChanges();
        }
    }
    public bool ExisteUsuario(int id)
    {
         using (var _context = new RepositorioContext())
        {
            return _context.Usuarios.Any(u => u.Id == id);
        }
    }
    public void EliminarUsuario(int id)
    {
         using (var _context = new RepositorioContext())
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
            }
        }

    }

    public void ModificarUsuario(int id, Usuario u) // CHEQUEAR SI ESTÁ BIEN
    {
         using (var _context = new RepositorioContext())
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
         using (var _context = new RepositorioContext())
        {
            return _context.Usuarios.ToList();
        }
    }

    public bool EmailRepetido(string email)
    {
         using (var _context = new RepositorioContext())
        {
            return _context.Usuarios.Any(u => u.Email.ToLower() == email.ToLower());
        }
    }

    public int ContarUsuarios()
    {
         using (var _context = new RepositorioContext())
        {
            return _context.Usuarios.Count();
        }
    }
    public Usuario? ObtenerPorCorreo(string email)
    {
         using (var _context = new RepositorioContext())
        return _context.Usuarios.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
    }
}
