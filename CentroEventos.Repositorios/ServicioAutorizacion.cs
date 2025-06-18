using CentroEventos.Aplicacion;
namespace CentroEventos.Repositorios;
public class ServicioAutorizacionProvisorio : IServicioAutorizacion
{

    public bool PoseeElPermiso(int id, Permiso permiso)
    {
        using (var _context = new RepositorioContext())
        {
            var usuario = _context.Usuarios.Find(id);
            return usuario != null && usuario.Permisos.Contains(permiso);
        }
    }

    public void DarPermiso(int idEmisor, int idReceptor, Permiso permiso) // solo puede dar permisos respecto a USUARIOS, modificar
    {
        using (var _context = new RepositorioContext())
        {
            var adm = _context.Usuarios.Find(idEmisor);
            if (adm != null && idEmisor == 1)
            { // si ya hay adm, y si el idem es 1 (adm)
                var usuario = _context.Usuarios.Find(idReceptor);
                if (usuario != null && !usuario.Permisos.Contains(permiso)) // si existe y si no tiene ya ese permiso
                {
                    usuario.Permisos.Add(permiso);
                    _context.SaveChanges(); // Persistir cambios
                }
            }
        }
    }

}
