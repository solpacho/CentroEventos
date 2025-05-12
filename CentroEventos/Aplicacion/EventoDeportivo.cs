using System;

namespace CentroDeportivo;

public class EventoDeportivo
{
    public int Id {get; set;}
    public string Nombre {get; set;}
    public int CupoMaximo{get; set;}
    public int ResposableId{get;set;}
    public DateTime FechaHoraInicio {get;set;}
    public double DuracionHoras {get;set;}
    public string Descripcion{get;set;}

    
}
