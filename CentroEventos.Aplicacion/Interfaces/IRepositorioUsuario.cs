// agregar usuario
// dar permisos
// listar usuarios
// contraseña

using System;
namespace CentroEventos.Aplicacion;

public interface IRepositorioUsuario
{
    void AgregarUsuario(Usuario u);

    bool ExisteUsuario(int id);
    void EliminarUsuario(int id); // id a eliminar

    void ModificarUsuario(int id, Usuario u);
    Usuario? ObtenerPorCorreo(string mail);
    Usuario? ObtenerUsuario(int id);
    Usuario? ValidarCredenciales(string email, string PasswordHash);
    List<Usuario> ListarUsuarios();

    bool EmailRepetido(string email);

    int ContarUsuarios();
    
    // implementar void darPermiso

}