namespace CentroEventos.Aplicacion;

public class DarPermisoUseCase(IServicioAutorizacion _servicioAutorizacion)
{
    public void Ejecutar(int idEmisor, int idReceptor, Permiso permiso)
    {
        var permisosPermitidos = new[] {
            Permiso.UsuarioAlta,
            Permiso.UsuarioBaja,
            Permiso.UsuarioModificacion,
            Permiso.EventoAlta,
            Permiso.EventoBaja,
            Permiso.EventoModificacion,
            Permiso.ReservaAlta,
            Permiso.ReservaBaja,
            Permiso.ReservaModificacion,
            Permiso.PersonaAlta,
            Permiso.PersonaBaja,
            Permiso.PersonaModificacion,
            Permiso.DarPermiso
        };

        if (!permisosPermitidos.Contains(permiso))
            throw new Exception("No está permitido otorgar este permiso.");

        // Si el emisor no es el administrador (id = 1), se debe verificar que tenga permiso explícito
        if (idEmisor != 1 && !_servicioAutorizacion.PoseeElPermiso(idEmisor, Permiso.DarPermiso))
        {
            throw new Exception("No tiene permiso para otorgar permisos.");
        }


        // Ejecuta el otorgamiento del permiso
        _servicioAutorizacion.DarPermiso(idEmisor, idReceptor, permiso);
    }
}
