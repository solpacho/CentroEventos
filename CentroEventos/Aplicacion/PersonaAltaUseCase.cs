using Aplicacion;

namespace CentroEventos.Aplicacion;

public class PersonaAltaUseCase(IRepositorioPersona repositorio, ValidadorPersona validador, IServicioAutorizacion autorizacion){

    public void Ejecutar(Persona persona, int idUsuario)
    {
        if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.UsuarioAlta)) { //preguntar primero
            throw new FalloAutorizacionException("No posee permisos para realizar esta acción. \n");
        }

        if (!validador.Validar(persona, out string mensajeError)){
            throw new ValidacionException(mensajeError);
        }
        
        if (repositorio.DniRepetido(persona.DNI)){
            throw new DuplicadoException("El Dni ya existe. \n");
        }

        if (repositorio.EmailRepetido(persona.Email)){
            throw new DuplicadoException("El Email ya existe. \n");
        }

        repositorio.AgregarPersona(persona);
    }

}
