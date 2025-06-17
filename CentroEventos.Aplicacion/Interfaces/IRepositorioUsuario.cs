// agregar usuario
// dar permisos
// listar usuarios
// contraseña

using System;
namespace CentroEventos.Aplicacion;

public interface IRepositorioUsuario
{
    void AgregarUsuario(Usuario u);
    void EliminarUsuario(int id); // id a eliminar

    void ModificarUsuario(Usuario u);
    List<Usuario> ListarUsuarios();

    bool EmailRepetido(string email);

    int ContarUsuarios();
    // implementar void darPermiso

}