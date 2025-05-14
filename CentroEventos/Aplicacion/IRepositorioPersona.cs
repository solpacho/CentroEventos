using System;

namespace CentroEventos.Aplicacion;

public interface IRepositorioPersona
{
    void AgregarPersona(Persona persona);
    Persona? ObtenerPorId(int id);
    List<Persona> ListarPersonas();
    void Modificar(Persona persona);
    void Eliminar(int id);
}
