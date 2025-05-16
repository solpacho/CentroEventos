namespace CentroEventos.Aplicacion;

public class PersonaAltaUseCase(IRepositorioPersona repositorio, ValidadorPersona validador, IServicioAutorizacion autorizacion){

    public void Ejecutar(Persona persona, int idUsuario)
    {
        if (!validador.Validar(persona, out string mensajeError))
            throw new ValidacionException(mensajeError);

        if (repositorio.DniRepetido(persona.Dni)) {
            throw new DuplicadoException("El Dni ya existe. \n");
        }

        if (repositorio.EmailRepetido(persona.Email)) {
            throw new DuplicadoException("El Email ya existe. \n");
        }

        persona.Id = repositorio.ObtenerNuevoId(); //asigno id.

        repositorio.AgregarPersona(persona);
    }

}
