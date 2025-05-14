using System;

namespace CentroEventos.Aplicacion;

public class EventoDeportivo
{
    public int Id {get; set;}
    public string Nombre {get; set;}
    public int CupoMaximo{get; set;}
    public int ResponsableId{get;set;}
    public DateTime FechaHoraInicio {get;set;}
    public double DuracionHoras {get;set;}
    public string Descripcion{get;set;}

    public EventoDeportivo(){}

    public EventoDeportivo(int id, string nom, int cupo, int resp,double dur, DateTime fecha,string desc) {
        Id = id;
        Nombre = nom;
        CupoMaximo = cupo;
        ResponsableId = resp;
        FechaHoraInicio = fecha;
        DuracionHoras = dur;
        Descripcion = desc;
    }
    
}
