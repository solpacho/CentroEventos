using CentroEventos.Aplicacion;

namespace CentroEventos.Aplicacion;

// falta agregar AUTORIZACIÓN para poder dar alta usuario
public class UsuarioBajaUseCase(IRepositorioUsuario repou, IServicioAutorizacion servicio)
{
    public void Ejecutar(int id, int idEliminar)
    {
        // 1. Verificación de existencia de usuario
        if (!repou.ExisteUsuario(id) || (!repou.ExisteUsuario(idEliminar)))
        {
            throw new EntidadNotFoundException("No existe usuario");
        }
        // 2. Validación de datos del usuario
        if (!servicio.PoseeElPermiso(id, Permiso.UsuarioBaja))
        {
            throw new FalloAutorizacionException("No tiene permiso para dar de baja usuarios.");
        }

        repou.EliminarUsuario(idEliminar); 
    }
}
