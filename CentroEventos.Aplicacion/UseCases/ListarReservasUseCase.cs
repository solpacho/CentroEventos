using System;

namespace CentroEventos.Aplicacion;

public class ListarReservasUseCase(IRepositorioReserva repositorio)
{
    public List <Reserva> Ejecutar() => repositorio.ListarReservas(); 
}
