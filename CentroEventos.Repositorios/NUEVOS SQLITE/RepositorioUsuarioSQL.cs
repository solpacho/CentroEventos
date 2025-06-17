
using CentroEventos.Aplicacion;

namespace CentroEventos.Repositorios;

public class RepositorioUsuarioSQL : IRepositorioUsuario
{
    public void AgregarUsuario(Usuario u)
    {
        using (var _context = new RepositorioContext())
        {
            _context.Usuarios.Add(u);
            _context.SaveChanges();
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

    public void ModificarUsuario(Usuario u) // CHEQUEAR SI ESTÁ BIEN
    { using (var _context = new RepositorioContext())
        {
            var usuario = _context.Usuarios.Find(u);
            if (usuario != null)
            {
                usuario.Nombre = u.Nombre;
                usuario.Apellido = u.Apellido;
                usuario.Email = u.Email;
                usuario.PasswordHash = u.PasswordHash;
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
            var EmailExistente = _context.Usuarios.Find(email);
            return EmailExistente != null;
        }
    }
    
    public int ContarUsuarios()
    {
        using (var context = new RepositorioContext())
        {
            return context.Usuarios.Count();
        }
    }

}