using System;

namespace CentroEventos.Aplicacion;

public class ListarEventosUseCase(IRepositorioEvento repositorio)
{
    public List <EventoDeportivo> Ejecutar() => repositorio.ListarEventos();
}
