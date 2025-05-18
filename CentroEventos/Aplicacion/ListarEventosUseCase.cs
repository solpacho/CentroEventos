using System;

namespace CentroEventos.Aplicacion;

public class ListarEventosUseCase(IRepositorioEvento repositorio)
{
    public void Ejecutar() => repositorio.ListarEventos();
}
