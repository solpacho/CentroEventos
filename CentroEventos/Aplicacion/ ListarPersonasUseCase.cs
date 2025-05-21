using System;

namespace CentroEventos.Aplicacion;

public class ListarPersonaUseCase(IRepositorioPersona repositorio)
{
    public List<Persona> Ejecutar() => repositorio.ListarPersonas();
}
