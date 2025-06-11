using System;

namespace CentroEventos.Aplicacion;

public interface IRepositorioPersona
{
    //id
    int ObtenerNuevoId();
    //

    void AgregarPersona(Persona persona);
    Persona? ObtenerPorId(int id);
    List<Persona> ListarPersonas();
    void Modificar(Persona persona);
    void Eliminar(int id);
    
    bool DniRepetido(string dni);
    bool EmailRepetido(string mail); 
    bool ExistePersona(int id);

}
