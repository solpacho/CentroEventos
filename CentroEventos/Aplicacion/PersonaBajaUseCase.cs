using CentroEventos.Aplicacion;

namespace Aplicacion;

public class PersonaBajaUseCase(IRepositorioPersona repositorio, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(int idPersona, int idUsuario)
    {
        if (!autorizacion.PoseeElPermiso(IdUsuario, Permiso.UsuarioBaja)) {
            throw new FalloAutorizacionException("No posee permisos para realizar esta acción. \n");
        }

        if (!repositorio.existePersona(idPersona)) {
            throw new EntidadNotFound("No se ha encontrado la persona. \n")
        }
        //reglas!!
        repositorio.EliminarPersona(idPersona);
    }
}