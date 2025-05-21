using System;

namespace CentroEventos.Aplicacion;

public class ListarPersonaUseCase(IRepositorioPersona repositorio)
{
    public void Ejecutar() => repositorio.ListarPersonas();
}
