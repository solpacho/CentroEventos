using System;
namespace CentroEventos.Aplicacion;

public interface IRepositorioReserva
{
    void AgregarReserva(Reserva reserva);
    Reserva? ObtenerPorId(int id);
    List<Reserva> ListarReservas();
    void Modificar(Reserva reserva);
    void Eliminar(int id);

    // Métodos auxiliares
    bool ReservaExistente(int personaId, int eventoId);
    int CantidadReservasEvento(int eventoId);
}
