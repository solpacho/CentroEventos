using System.Data.Common;
using Aplicacion;
using CentroEventos.Aplicacion;

namespace CentroEventos.Repositorios;

public class RepositorioPersona: IRepositorioPersona
{

    readonly string _nombreArchivo = " personas.txt ";
    public void AgregarPersona (Persona persona){
        persona._id = ObtenerNuevoId();
        using var sw = new StreamWriter (_nombreArchivo, true);
        sw.WriteLine (persona._id);
        sw.WriteLine (persona.DNI);
        sw.WriteLine (persona.Nombre);
        sw.WriteLine (persona.Apellido);
        sw.WriteLine (persona.Email);
        sw.WriteLine (persona.Telefono);  
    }


    public Persona? ObtenerPorId (){ //este metodo devuelve la persona que tiene id igual al valor pasado como parametro o null si no existe.
        return ListarPersonas().FirstOrDefault (p => p.Id == id);
    }

    public List<Persona> ListarPersonas(){ //este metodo abre el archivo personas.txt en modo de lectura y convierte las lineas en objetos persona, los agrega a la lista y devuelve la lista completa.

        var personas = new List <Persona>();
        if (!File.Exists(_nombreArchivo) return personas;
        using var sr = new StreamReader (_nombreArchivo);
        while (!sr.EndOfStream){
            var persona = new Persona {
                Id = int.Parse(sr.ReadLine() ?? ""),
                DNI = sr.ReadLine() ?? "",
                Nombre = sr.ReadLine() ?? "",
                Apellido = sr.ReadLine () ?? "",
                Telefono = sr.ReadLine () ?? ""
            };
        }
    }

    public void Modificar (Persona persona){ //este metodo:
        var personas = ListarPersonas(); //cargo todas las personas del archivo
        var indicePersona = personas.FindIndex(p => p.Id == persona.Id); //busco la persona con el mismo id
        if (indicePersona == -1) //si no se encuentra salgo del metodo 
            return;
        personas[indicePersona] = persona; //reemplazo
        GuardarTodo(personas); //guardo la lista actualizada
    }

    public void Eliminar (int id){
        var personas = ListarPersonas();
        var existe = personas.Any (p => p.Id == id);
        if (!existe)
            return;
        //expresion lambda p => p.Id != id ; p var temporal rep cada persona de la lista, y p.id != id condicion
        var personasActualizadas = personas.Where (p => p.Id != id).ToList();
        GuardarTodo(personasActualizadas);
    }

    private void GuardarTodo (){ //actualiza el archivo
        using var sw = new StreamWriter (_nombreArchivo, false);
        foreach (var p in personas){
            sw.WriteLine(p.Id);
            sw.WriteLine(p.DNI);
            sw.WriteLine(p.Nombre);
            sw.WriteLine(p.Apellido);
            sw.WriteLine(p.Email);
            sw.WriteLine(p.Telefono);
        }
    }

    private int ObtenerNuevoId (){ //devuelvo el numero id que se le asigna a la proxima persona
        var lista = ListarPersonas();
        return lista.Any() ? lista.Max(p => p.Id) + 1 : 1;
        //expresion lambda, si la lista tiene elementos, busca la persona con mayor id y le sumo 1, 
        //si es el primer elemento le asigno 1
    }
    
}
