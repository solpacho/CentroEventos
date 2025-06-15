using Aplicacion;

namespace CentroEventos.Aplicacion;

public class UsuarioAltaUseCase(IRepositorioUsuario repou, ValidadorUsuario validador)
{
    public void Ejecutar(Usuario u)
    { // IMPLEMENTAR 
        if (!validador.Validar(u, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }
        
        if (repou.EmailRepetido(u.Email)){
            throw new DuplicadoException("El Email ya existe. \n");
        }
    }
}