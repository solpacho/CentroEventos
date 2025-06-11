using System.Data.Common;

using CentroEventos.Aplicacion;
using Repositorios;

namespace CentroEventos.Repositorios;

public class RepositorioPersonaSQL: IRepositorioPersona
{

    private readonly RepositorioContext _context;

    public RepositorioPersonaSQL(RepositorioContext context)
    {
        _context = context;
    }
    public void AgregarPersona(Persona persona)
    {
        _context.Add(persona);
        _context.SaveChanges();
    }


    public Persona? ObtenerPorId (int id){ //este metodo devuelve la persona que tiene id igual al valor pasado como parametro o null si no existe.
        return _context.Personas.Find();
    }

    public List<Persona> ListarPersonas(){ //este metodo abre el archivo personas.txt en modo de lectura y convierte las lineas en objetos persona, los agrega a la lista y devuelve la lista completa.
        return _context.Personas.ToList();
    }

    public void Modificar (Persona persona){ //este metodo:

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

    public void Eliminar(int id) {
        var perExistente = _context.Personas.Find(id);
        if (perExistente != null)
        {
            _context.Remove(perExistente);
            _context.SaveChanges();
        }
    }

    /*  NO SE USA MÁS?  
        private void GuardarTodo (List<Persona> listaPersonas){ //actualiza el archivo
            using var sw = new StreamWriter (_nombreArchivo, false);
            foreach (var p in listaPersonas){
                sw.WriteLine(p.Id);
                sw.WriteLine(p.DNI);
                sw.WriteLine(p.Nombre);
                sw.WriteLine(p.Apellido);
                sw.WriteLine(p.Email);
                sw.WriteLine(p.Telefono);
            }
        }
    */
    // NO SE USA MÁS?

    public int ObtenerNuevoId (){ //devuelvo el numero id que se le asigna a la proxima persona
        var lista = ListarPersonas();
        return lista.Any() ? lista.Max(p => p.Id) + 1 : 1;
        //expresion lambda, si la lista tiene elementos, busca la persona con mayor id y le sumo 1, 
        //si es el primer elemento le asigno 1
    }
    

    public bool DniRepetido(string dni)
    {
        var dniExistente = _context.Personas.Find(dni);
        return dniExistente != null;
    }

    public bool EmailRepetido(string email){
        var EmailExistente = _context.Personas.Find(email);
        return EmailExistente != null;
    }

    public bool ExistePersona(int id)
    {
        var perExistente = _context.Personas.Find(id);
        return perExistente != null;
    }

    
}
