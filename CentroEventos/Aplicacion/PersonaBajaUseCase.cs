using CentroEventos.Aplicacion;

namespace Aplicacion;

public class PersonaBajaUseCase(IRepositorioPersona repositorio, ValidadorPersona validador, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(Persona persona, int idUsuario)
    {
        if (!validador.Validar(persona))
            throw new Exception(ValidacionException);
        if (repositorio.ObtenerPorId(persona._id) == null)
            throw new Exception(EntidadNotFoundException);
        if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.UsuarioBaja))
            throw new Exception(FalloAutorizacionException);
        repositorio.Eliminar(persona._id);
    }
}