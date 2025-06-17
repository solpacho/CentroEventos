
using CentroEventos.Aplicacion;

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
            return _context.Personas.Find(id);
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
            _context.Personas.Remove(perExistente);
            _context.SaveChanges();
        }
        }
    }

    public bool DniRepetido(string dni)
    {   using (var _context = new RepositorioContext()){
            return _context.Personas.Any(p => p.DNI == dni);
    }
    }

    public bool EmailRepetido(string email){
        using (var _context = new RepositorioContext()){
            return _context.Personas.Any(p => p.Email == email);
        }
    }

    public bool ExistePersona(int id)
    {   using (var _context = new RepositorioContext()){
            var perExistente = _context.Personas.Find(id);
            return perExistente != null;
        }
    }

    
}
