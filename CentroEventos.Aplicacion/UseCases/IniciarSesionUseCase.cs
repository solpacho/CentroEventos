public class IniciarSesionUseCase
{
    private readonly IRepositorioUsuarios _repoUsuarios;
    private readonly IServicioHash _servicioHash;

    public IniciarSesionUseCase(IRepositorioUsuarios repoUsuarios, IServicioHash servicioHash)
    {
        _repoUsuarios = repoUsuarios;
        _servicioHash = servicioHash;
    }

    public Usuario Ejecutar(string correo, string contrasena)
    {
        var usuario = _repoUsuarios.ObtenerPorCorreo(correo);
        if (usuario == null)
            throw new Exception("Correo no encontrado.");

        var hash = _servicioHash.CalcularHash(contrasena);
        if (usuario.HashContrasenia != hash)
            throw new Exception("Contraseña incorrecta.");

        return usuario;
    }
}
