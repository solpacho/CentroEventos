namespace Aplicacion;

public class ReservaBajaUseCase(IRepositorioReserva repositorio, ValidadorReserva validador, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(int idPersona, int idUsuario)
    {
        if (!autorizacion.PoseeElPermiso(IdUsuario, Permiso.UsuarioBaja)) {
            throw new FalloAutorizacionException("No posee permisos para realizar esta acción. \n");
        }

        if (!repositorio.existePersona(idReserva)) {
            throw new EntidadNotFound("No se ha encontrado la reserva. \n")
        }
        //reglas!!
        repositorio.EliminarPersona(idReserva);
    }

}