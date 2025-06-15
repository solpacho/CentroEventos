using CentroEventos.Aplicacion;
using Repositorios;

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

    public List<Usuario> ListarUsuarios()
    {
        using (var _context = new RepositorioContext())
        {
            return _context.Usuarios.ToList();
        }
    }

    void EstablecerPassword(string input)
    {
        using (var _context = new RepositorioContext())
        { 
            
        }
    }


}