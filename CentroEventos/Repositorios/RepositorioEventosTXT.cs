using CentroEventos.Aplicacion;
using Microsoft.VisualBasic;

namespace CentroEventos.Repositorios;

public class RepositorioEventosTXT : IRepositorioEvento 
{
    readonly string _nombreArchivo = "Eventos.txt";
    public void AgregarEvento(EventoDeportivo evento)
    {
        evento.Id = ObtenerNuevoId();
        using var sw = new StreamWriter(_nombreArchivo, true); //if true -> reset() if false -> rewrite() 
        sw.WriteLine(evento.Id);
        sw.WriteLine(evento.Nombre);
        sw.WriteLine(evento.Descripcion);
        sw.WriteLine(evento.FechaHoraInicio.ToString("o")); // formato ISO 8601
        sw.WriteLine(evento.DuracionHoras);
        sw.WriteLine(evento.CupoMaximo);
        sw.WriteLine(evento.ResponsableId);
    }

    public List<EventoDeportivo> ListarEventos()
    {
        var resultado = new List<EventoDeportivo>();
        using var sr = new StreamReader(_nombreArchivo);
        while (!sr.EndOfStream)
        {
            var evento = new EventoDeportivo();
            evento.Id = int.Parse(sr.ReadLine() ?? "");
            evento.Nombre = sr.ReadLine() ?? "";
            evento.Descripcion = sr.ReadLine() ?? "";
            evento.FechaHoraInicio = DateTime.Parse(sr.ReadLine() ?? "");
            evento.DuracionHoras = Double.Parse(sr.ReadLine() ?? "");
            evento.CupoMaximo = int.Parse(sr.ReadLine() ?? "");
            evento.ResponsableId = int.Parse(sr.ReadLine() ?? "");
            resultado.Add(evento);
        }
        return resultado;
    }

    public void EliminarEvento(int id)
    {
        List<EventoDeportivo> eventos = ListarEventos(); //listo eventos actuales
        eventos = eventos.Where(e => e.Id != id).ToList(); //saco de la lista actual el evento con id "id"
        using StreamWriter sw = new StreamWriter(_nombreArchivo, false); //hago UN REWRITE DEL TEXTO

        foreach (var evento in eventos)
        {
            sw.WriteLine(evento.Id);
            sw.WriteLine(evento.Nombre);
            sw.WriteLine(evento.Descripcion);
            sw.WriteLine(evento.FechaHoraInicio.ToString("o")); // formato ISO 8601
            sw.WriteLine(evento.DuracionHoras);
            sw.WriteLine(evento.CupoMaximo);
            sw.WriteLine(evento.ResponsableId);
        }
    }

    public int ObtenerNuevoId()
    {
        var lista = ListarEventos();
        return lista.Any() ? lista.Max(p => p.Id) + 1 : 1;
    }

    public bool ExisteEvento(int id)
    {
        var lista = ListarEventos();
        return lista.Any(e => e.Id == id);
    }

    public EventoDeportivo? ObtenerPorId(int id)
    {
        return ListarEventos().FirstOrDefault(e => e.Id == id);
    }
    public bool EsResponsable(int id)
    {
        var lista = ListarEventos();

        return lista.Any(e => e.ResponsableId == id);

    }
    

    private void GuardarTodo(List<EventoDeportivo> lista)
    {
        using var sw = new StreamWriter(_nombreArchivo, false);
        foreach (var evento in lista)
        {
            sw.WriteLine(evento.Id);
            sw.WriteLine(evento.Nombre);
            sw.WriteLine(evento.Descripcion);
            sw.WriteLine(evento.FechaHoraInicio.ToString("o")); // formato ISO 8601
            sw.WriteLine(evento.DuracionHoras);
            sw.WriteLine(evento.CupoMaximo);
            sw.WriteLine(evento.ResponsableId);
           
        }
    }

    public void Modificar(EventoDeportivo evento)
    {
        var lista = ListarEventos();
        int indice = lista.FindIndex(r => r.Id == evento.Id);
        if (indice == -1)
            return;

        lista[indice] = evento;
        GuardarTodo(lista);
    }
}
