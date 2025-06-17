// agregar usuario
// dar permisos
// listar usuarios
// contraseña

using System;

namespace CentroEventos.Aplicacion;

public interface IRepositorioUsuario
{
    void AgregarUsuario(Usuario u);
    List<Usuario> ListarUsuarios();
    bool EmailRepetido(string email);

    // implementar void darPermiso

}
