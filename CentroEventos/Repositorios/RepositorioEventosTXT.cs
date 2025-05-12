using System;

namespace CentroDeportivo;
// using CentroDeportivo.Aplicacion;
public class RepositorioEventosTXT: IRepositorioEvento
{
    readonly string _nombreArchivo = "Eventos.txt";  
     public void AgregarEvento(EventoDeportivo evento) //escribe el evento agregado en el texto
    {
        using var sw = new StreamWriter(_nombreArchivo, true); //if true -> reset() if false -> rewrite() 
        sw.WriteLine(evento.Id);
        sw.WriteLine(evento.Nombre);
        sw.WriteLine(evento.Descripcion);
        sw.WriteLine(evento.FechaHoraInicio.ToString("o")); // formato ISO 8601
        sw.WriteLine(evento.DuracionHoras);
        sw.WriteLine(evento.CupoMaximo);
        sw.WriteLine(evento.ResposableId);
    }
    
    public List<EventoDeportivo> ListarEventos() { //agrega todos los elementos en el texto a una lista, asi poder trabajar con todos
        var resultado = new List<EventoDeportivo>();                                             //los eventos.
        using var sr = new StreamReader(_nombreArchivo);
        while (!sr.EndOfStream) {
            var evento = new EventoDeportivo();
            evento.Id = int.Parse(sr.ReadLine() ?? "");
            evento.Nombre = sr.ReadLine() ?? "";
            evento.Descripcion = sr.ReadLine() ?? "";
            evento.FechaHoraInicio = DateTime.Parse(sr.ReadLine() ?? "");
            evento.DuracionHoras = Double.Parse(sr.ReadLine() ?? ""); 
            evento.CupoMaximo = int.Parse(sr.ReadLine() ?? "");          
            evento.ResposableId = int.Parse(sr.ReadLine() ?? "");
            resultado.Add(evento);
        }
        return resultado;
    }
}
