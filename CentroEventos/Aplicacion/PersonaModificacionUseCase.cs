using CentroEventos.Aplicacion;using CentroEventos.Aplicacion;

namespace Aplicacion;

public class PersonaModificacionUseCase(IRepositorioPersona repositorio, ValidadorPersona validador, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(Persona persona, int idUsuario)
    {
        if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.UsuarioModificacion)){
            throw new FalloAutorizacionException("No posee el pemiso para realizar esta acción \n");
        }

        if (!validador.Validar(persona, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }

        if (!repositorio.existePersona(persona.Id)){
            throw new EntidadNotFoundException("No se ha encontrado la persona. \n");
        }
    
        repositorio.Modificar(persona);
    }
}
