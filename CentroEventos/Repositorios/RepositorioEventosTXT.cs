using System;
using CentroDeportivo.Aplicacion;

namespace CentroEventos.Repositorios;

public class RepositorioEventosTXT : IRepositorioEvento(RepositorioReserva reporeserva)
{
    readonly string _nombreArchivo = "Eventos.txt";

    public void AgregarEvento(EventoDeportivo evento) {
        using var sw = new StreamWriter(_nombreArchivo, true); //if true -> reset() if false -> rewrite() 
        sw.WriteLine(evento.Id);
        sw.WriteLine(evento.Nombre);
        sw.WriteLine(evento.Descripcion);
        sw.WriteLine(evento.FechaHoraInicio.ToString("o")); // formato ISO 8601
        sw.WriteLine(evento.DuracionHoras);
        sw.WriteLine(evento.CupoMaximo);
        sw.WriteLine(evento.ResponsableId);
    }

    public List<EventoDeportivo> ListarEventos() {
        var resultado = new List<EventoDeportivo>();
        using var sr = new StreamReader(_nombreArchivo);
        while (!sr.EndOfStream) {
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

    public void EliminarEvento(int id) {
        List<EventoDeportivo> eventos = ListarEventos(); //listo eventos actuales
        eventos = eventos.Where(e => e.Id != id).ToList(); //saco de la lista actual el evento con id "id" preguntar si esta bien.
        using StreamWriter sw = new StreamWriter(_nombreArchivo, false); //hago UN REWRITE DEL TEXTO

        foreach (var evento in eventos) {
            sw.WriteLine(evento.Id);
            sw.WriteLine(evento.Nombre);
            sw.WriteLine(evento.Descripcion);
            sw.WriteLine(evento.FechaHoraInicio.ToString("o")); // formato ISO 8601
            sw.WriteLine(evento.DuracionHoras);
            sw.WriteLine(evento.CupoMaximo);
            sw.WriteLine(evento.ResponsableId);
        }
    }

    public int ObtenerNuevoId() {
        var lista = ListarEventos();
        return lista.Any() ? lista.Max(p => p._id) + 1 : 1;
    }

    public bool existeEvento(int id)
    {
        var lista = ListarEventos();
        return lista.Any(e => e.Id == id);
    }

    public EventoDeportivo? ObtenerPorId(int id)
    {
        return ListarEventos().FirstOrDefault(e => e.Id == id);
    }
    public bool esResponsable(int id) {
        var lista = ListarEventos();

        return lista.Any(e => e.ResponsableId == id);

    }

    public bool controlReserva(EventoDeportivo evento)
    {
        var reservas = _repo.CantidadReservasEvento(evento.Id);
        return reservas < evento.CupoMaximo;
    }


}
