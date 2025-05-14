namespace Aplicacion;

public class Reserva
{
    public int id {get;set;} // Autoincremental en repositorio Reserva
    public int PersonaId {get;set;} // id de la persona
    public int EventoDeportivoId {get;set;}

    public DateTime FechaAltaReserva;

    public enum EstadoAsistencia{
        Pendiente,
        Presente,
        Ausente
    }

    public Reserva(){


    }

    public String toString(){
        
        return $"ID: {id}, id de la Persona: {PersonaId}, id evento deportivo: {EventoDeportivoId}"; 
    }
}