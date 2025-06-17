
namespace CentroEventos.Aplicacion;

public class UsuarioAltaUseCase(IRepositorioUsuario repou, ValidadorUsuario validador, HashHelperUseCase hashHelper)
{
    public void Ejecutar(Usuario u, string passwordPlano)
    {
        // 1. Validación de datos del usuario
        if (!validador.Validar(u, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }

        // 2. Verificación de duplicado hay que implementar
        if (repou.EmailRepetido(u.Email))
        {
            throw new DuplicadoException("El Email ya existe.\n");
        }

        // 3. Generación del hash de la contraseña
        u.PasswordHash = hashHelper.GenerarHash(passwordPlano);

        // 4. Guardado en base de datos
        repou.AgregarUsuario(u);
    }
}
