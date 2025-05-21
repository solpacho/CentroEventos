using System;

namespace CentroEventos.Aplicacion;

public class ListarReservasUseCase(IRepositorioReserva repositorio)
{
    public void Ejecutar() => repositorio.ListarReservas(); 
}
