public class ListarUsuariosUseCase
{
    private readonly IRepositorioUsuarios _repoUsuarios;
    private readonly IServicioAutorizacion _servicioAutorizacion;

    public ListarUsuariosUseCase(IRepositorioUsuarios repoUsuarios, IServicioAutorizacion servicioAutorizacion)
    {
        _repoUsuarios = repoUsuarios;
        _servicioAutorizacion = servicioAutorizacion;
    }

    public List<Usuario> Ejecutar(int idSolicitante)
    {
        if (idSolicitante != 1 && !_servicioAutorizacion.PoseeElPermiso(idSolicitante, Permiso.UsuarioModificacion))
            throw new Exception("No tiene permisos para listar usuarios.");

        return _repoUsuarios.Listar();
    }
}
