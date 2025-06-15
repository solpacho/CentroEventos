// agregar usuario
// dar permisos
// listar usuarios
// contraseña

using System;
using Aplicacion;
namespace CentroEventos.Aplicacion;

public interface IRepositorioUsuario
{
    void AgregarUsuario(Usuario u);
    List<Usuario> ListarUsuarios();

    // implementar void darPermiso

    void EstablecerPassword(string input);
}