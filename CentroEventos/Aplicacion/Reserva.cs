namespace CentroEventos.Aplicacion;

public class Reserva
{
    public int Id {get;set;} 
    public int PersonaId {get;set;} 
    public int EventoDeportivoId {get;set;}
    
    public DateTime FechaAltaReserva {get;set;}
    public EstadoAsistencia Estado { get; set; }
    public enum EstadoAsistencia{
        Pendiente,
        Presente,
        Ausente
    }

    public Reserva(int id, int personaid, int eventodeportivoid, EstadoAsistencia estado){
        Id=id;
        PersonaId=personaid;
        EventoDeportivoId=eventodeportivoid;
        FechaAltaReserva = DateTime.Now;
        Estado = estado; // preguntar si está bien implementado enum

    }

    public String toString(){
        
        return $"ID: {Id}, id de la Persona: {PersonaId}, id evento deportivo: {EventoDeportivoId}"; 
    }
}