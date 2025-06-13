using CentroEventos.Aplicacion;
using Repositorios;

namespace CentroEventos.Repositorios;

public class RepositorioPersonaSQL: IRepositorioPersona
{
    public void AgregarPersona(Persona persona)
    {
        using (var _context = new RepositorioContext()){
            _context.Add(persona);
            _context.SaveChanges();
        }
    }


    public Persona? ObtenerPorId (int id){ 
            using (var _context = new RepositorioContext()){
            return _context.Personas.Find();
        }
    }

    public List<Persona> ListarPersonas(){ 
            using (var _context = new RepositorioContext()){
            return _context.Personas.ToList();
        }
    }

    public void Modificar (Persona persona){ //este metodo:
        using (var _context = new RepositorioContext()){
        var perExistente = _context.Personas.Find(persona.Id);
        if (perExistente != null)
        {
            perExistente.Apellido = persona.Apellido;
            perExistente.DNI = persona.DNI;
            perExistente.Email = persona.Email;
            perExistente.Nombre = persona.Nombre;
            perExistente.Telefono = persona.Telefono;

            _context.SaveChanges();
        }
        }
    }

    public void Eliminar(int id) {
        using (var _context = new RepositorioContext()){
        var perExistente = _context.Personas.Find(id);
        if (perExistente != null)
        {
            _context.Remove(perExistente);
            _context.SaveChanges();
        }
        }
    }
    // NO SE USA MÁS?

    public int ObtenerNuevoId (){ //devuelvo el numero id que se le asigna a la proxima persona
        var lista = ListarPersonas();
        return lista.Any() ? lista.Max(p => p.Id) + 1 : 1;
        //expresion lambda, si la lista tiene elementos, busca la persona con mayor id y le sumo 1, 
        //si es el primer elemento le asigno 1
    }
    

    public bool DniRepetido(string dni)
    {   using (var _context = new RepositorioContext()){
            var dniExistente = _context.Personas.Find(dni);
            return dniExistente != null;
    }
    }

    public bool EmailRepetido(string email){
        using (var _context = new RepositorioContext()){
            var EmailExistente = _context.Personas.Find(email);
            return EmailExistente != null;
        }
    }

    public bool ExistePersona(int id)
    {   using (var _context = new RepositorioContext()){
            var perExistente = _context.Personas.Find(id);
            return perExistente != null;
        }
    }

    
}
