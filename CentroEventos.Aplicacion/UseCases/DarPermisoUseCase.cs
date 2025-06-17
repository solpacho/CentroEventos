namespace CentroEventos.Aplicacion;

public class DarPermisoUseCase
{
    private readonly IServicioAutorizacion _servicioAutorizacion;

    public OtorgarPermisoUseCase(IServicioAutorizacion servicioAutorizacion)
    {
        _servicioAutorizacion = servicioAutorizacion;
    }

    public void Ejecutar(int idEmisor, int idReceptor, Permiso permiso)
    {
        // Sólo permite dar permisos relacionados con usuarios
        var permisosPermitidos = new[] {
            Permiso.UsuarioAlta,
            Permiso.UsuarioBaja,
            Permiso.UsuarioModificacion
        };

        if (!permisosPermitidos.Contains(permiso))
            throw new Exception("No está permitido otorgar este permiso.");

        // Si el emisor no es el administrador (id = 1), se debe verificar que tenga permiso explícito
        if (idEmisor != 1 && !_servicioAutorizacion.PoseeElPermiso(idEmisor, Permiso.UsuarioModificacion))
        {
            throw new Exception("No tiene permiso para otorgar permisos.");
        }
        // Ejecuta el otorgamiento del permiso
        _servicioAutorizacion.DarPermiso(idEmisor, idReceptor, permiso);
    }
}
