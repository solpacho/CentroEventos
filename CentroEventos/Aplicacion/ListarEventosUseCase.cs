using System;

namespace CentroDeportivo;

public class ListarEventosUseCase(IRepositorioEvento repositorio)
{
    public void Ejecutar() => repositorio.ListarEventos();
}
