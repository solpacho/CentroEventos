namespace Aplicacion;

public class ReservaBajaUseCase(IRepositorioReserva repositorio, ValidadorReserva validador, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(Reserva reserva, int idUsuario)
    {
        if (!validador.Validar(resrva))
            throw new Exception(ValidacionException);
        if (repositorio.ObtenerPorId(reserva.id == null)) //no entiendo q dice la warning
            throw new Exception(EntidadNotFoundException);
        if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.ReservaBaja))
            throw new Exception(FalloAutorizacionException);
        repositorio.Eliminar(reserva.id);
    }

}