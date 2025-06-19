using System;


namespace CentroEventos.Aplicacion;

public class EventoDeportivoBajaUseCase(IRepositorioEvento repositorio, IRepositorioReserva repoReservas, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(int idEvento, int IdUsuario)
    {
        if (!autorizacion.PoseeElPermiso(IdUsuario, Permiso.EventoBaja)) {
            throw new FalloAutorizacionException("No posee permisos para realizar esta acción. \n");
        }

        if (!repositorio.ExisteEvento(idEvento)) {
            throw new EntidadNotFoundException("No se ha encontrado el evento. \n");
        }

        //No puede eliminarse un EventoDeportivo si existen Reservas asociadas al mismo
        if (repoReservas.TieneReserva(idEvento)){
            throw new OperacionInvalidaException("No es posibe eliminar un evento que posee reservas asociadas \n");
        }
            
        repositorio.EliminarEvento(idEvento);
    }
}
