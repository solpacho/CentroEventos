using CentroEventos.Aplicacion;

namespace CentroEventos.Aplicacion;

public class ReservaModificacionUseCase(IRepositorioReserva repositorio, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(Reserva reserva, int idUsuario)
    {
        if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.ReservaModificacion)){
            throw new FalloAutorizacionException("No posee permisos para realizar esta acción. \n");
        }

        if (!repositorio.ExisteReserva(reserva.Id)){
            throw new Exception("No se ha encontrado la reserva \n");
        }
 
        repositorio.Modificar(reserva);
        Console.WriteLine("Reserva modificada con éxito");
    }
}
