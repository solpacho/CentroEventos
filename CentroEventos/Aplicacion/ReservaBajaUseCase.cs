using CentroEventos.Aplicacion;

namespace CentroEventos.Aplicacion;

public class ReservaBajaUseCase(IRepositorioReserva repositorio, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(int idReserva, int idUsuario)
    {
        if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.ReservaBaja)) {
            throw new FalloAutorizacionException("No posee permisos para realizar esta acción. \n");
        }

        if (!repositorio.ExisteReserva(idReserva)) { //faltaria esto en el repo
            throw new EntidadNotFoundException("No se ha encontrado la reserva. \n");
        }


        repositorio.Eliminar(idReserva);
    }

}
