using System;
namespace CentroEventos.Aplicacion;

public interface IRepositorioReserva
{
    //id
    int ObtenerNuevoId();
    //

    void AgregarReserva(Reserva reserva);
    List<Reserva> ListarReservas();
    Reserva? ObtenerPorId(int id);
    void Modificar(Reserva reserva);
    void Eliminar(int id);

    // Métodos auxiliares
    bool ExisteReserva(int id);
    bool ReservaExistente(int personaId, int eventoId);
    int CantidadReservasEvento(int eventoId);
    bool TieneReserva(int id);
    
}
