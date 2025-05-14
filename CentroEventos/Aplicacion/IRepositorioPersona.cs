using System;

namespace CentroEventos.Aplicacion;

public interface IRepositorioPersona
{
    void Agregar(Persona persona);
    Persona? ObtenerPorId(int id);
    List<Persona> ListarPersonas();
    void Modificar(Persona persona);
    void Eliminar(int id);
}
