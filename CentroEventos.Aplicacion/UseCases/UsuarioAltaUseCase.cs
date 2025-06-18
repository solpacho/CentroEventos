using CentroEventos.Aplicacion;

namespace CentroEventos.Aplicacion;

// falta agregar AUTORIZACIÓN para poder dar alta usuario
public class UsuarioAltaUseCase(IRepositorioUsuario repou, ValidadorUsuario validador, IServicioAutorizacion autorizacion, HashHelperUseCase hashHelper)
{
    public void Ejecutar(Usuario u, string passwordPlano)
    {   
        // 1. Validación de datos del usuario
        if (!validador.Validar(u, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }

        // 2. Verificación de duplicado
        if (repou.EmailRepetido(u.Email))
        {
            throw new DuplicadoException("El Email ya existe.\n");
        }

        // 3. Generación del hash de la contraseña
        u.PasswordHash = hashHelper.GenerarHash(passwordPlano);

        if (repou.ContarUsuarios() == 0) // si es el adminsitrador, dar todos los permisos
        {
            u.Permisos = Enum.GetValues<Permiso>().ToList();
        }
        // 4. Guardado en base de datos
        repou.AgregarUsuario(u); 
    }
}
