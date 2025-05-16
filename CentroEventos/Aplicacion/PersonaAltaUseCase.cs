using CentroEventos.Aplicacion;

namespace Aplicacion;

public class PersonaAltaUseCase(IRepositorioPersona repositorio, ValidadorPersona validador, IServicioAutorizacion autorizacion){

    public void Ejecutar(Persona persona, int idUsuario)
    {
        if (!validador.Validar(persona))
            throw new Exception(ValidacionException);
        if (repositorio.ObtenerPorId(persona._id) != null)
            throw new Exception(DuplicadoException);
        if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.UsuarioAlta))
            throw new Exception(FalloAutorizacionException);
        repositorio.AgregarPersona(persona);
    }

}
