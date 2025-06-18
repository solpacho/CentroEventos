
using CentroEventos.Aplicacion;

public class IniciarSesionUseCase
{
    private readonly IRepositorioUsuario _repoUsuarios;
    private readonly IHashService _servicioHash;

    public IniciarSesionUseCase(IRepositorioUsuario repoUsuarios, IHashService servicioHash)
    {
        _repoUsuarios = repoUsuarios;
        _servicioHash = servicioHash;
    }

    public Usuario Ejecutar(String correo, string contrasena)
    {
        var usuario = _repoUsuarios.ObtenerPorCorreo(correo);
        if (usuario == null)
            throw new Exception("Correo no encontrado.");

        var hash = _servicioHash.Hash(contrasena);
        if (usuario.PasswordHash != hash)
            throw new Exception("Contraseña incorrecta.");

        return usuario;
    }
}
