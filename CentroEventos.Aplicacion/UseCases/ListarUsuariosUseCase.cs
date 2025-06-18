using System;
namespace CentroEventos.Aplicacion;

public class ListarUsuariosUseCase(IRepositorioUsuario _repoUsuarios, IServicioAutorizacion _servicioAutorizacion)
{
    public List<Usuario> Ejecutar(int idSolicitante)
    {
        if (idSolicitante != 1 && !_servicioAutorizacion.PoseeElPermiso(idSolicitante, Permiso.UsuarioModificacion))
            throw new FalloAutorizacionException("No tiene permisos para listar usuarios.");

        return _repoUsuarios.ListarUsuarios();
    }
}
