namespace CentroEventos.Aplicacion;

public class Reserva
{
    public int Id {get;set;} 
    public int PersonaId {get;set;} 
    public int EventoDeportivoId {get;set;}

    public DateTime FechaAltaReserva {get;set;};

    public enum EstadoAsistencia{
        Pendiente,
        Presente,
        Ausente
    }

    public Reserva(int id, int personaid, int eventodeportivoid){
        Id=id;
        PersonaId=personaid;
        EventoDeportivoId=eventodeportivoid;
        FechaAltaReserva= DateTime.Now();
        // enum ?? como se usaria?

    }

    public String toString(){
        
        return $"ID: {id}, id de la Persona: {PersonaId}, id evento deportivo: {EventoDeportivoId}"; 
    }
}