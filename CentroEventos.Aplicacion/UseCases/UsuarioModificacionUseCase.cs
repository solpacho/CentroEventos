using CentroEventos.Aplicacion;

namespace CentroEventos.Aplicacion;

public class UsuarioModificacionUseCase(IRepositorioUsuario repou, IServicioAutorizacion servicio)
{
    public void Ejecutar(int id, int idModificar, Usuario u)
    {
        // 1. Verificación de existencia de usuario
        if (!repou.ExisteUsuario(id) || (!repou.ExisteUsuario(idModificar)))
        {
            throw new EntidadNotFoundException("No existe usuario");
        }
        // 2. Verificación de permisos
        if (!servicio.PoseeElPermiso(id, Permiso.UsuarioModificacion))
        {
            throw new FalloAutorizacionException("No tiene permiso para dar modificar usuarios.");
        }

        repou.ModificarUsuario(idModificar, u); 
    }
}
