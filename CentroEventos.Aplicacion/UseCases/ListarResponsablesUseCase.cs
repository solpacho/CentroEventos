using System;
namespace CentroEventos.Aplicacion;

public class ListarResponsablesUseCase(IRepositorioPersona _repoPersona)
{
    public List<Persona> Ejecutar()
    {
        return _repoPersona.ListarResponsables();
    }
}
