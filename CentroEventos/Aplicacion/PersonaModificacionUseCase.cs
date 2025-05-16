using CentroEventos.Aplicacion;

namespace Aplicacion;

public class PersonaModificacionUseCase(IRepositorioPersona repositorio, ValidadorPersona validador, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(Persona persona, int idUsuario)
    {
        if (!validador.Validar(persona))
            throw new Exception(ValidacionException);
        if (repositorio.ObtenerPorId(persona._id) == null)
            throw new Exception(EntidadNotFoundException);
        if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.UsuarioModificacion))
            throw new Exception(FalloAutorizacionException);
        repositorio.Modificar(persona);
    }
}