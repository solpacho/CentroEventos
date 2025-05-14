using System.Data.Common;

namespace CentroEventos.Aplicacion;

public class Persona
{   // ID AUTOINCREMENTAL, REPOSITORIO ASIGNA
    public int _id; // en el repositorio, va public o private?
    public string DNI{get;set;}
    public string Nombre {get;set;}
    public string Apellido{get;set;}
    public string Email{get;set;}
    public string Telefono{get;set;}
    public Persona(string dni, string nom, string ape, string em, string tel)
    { // falta validador persona, usarlo en el caso de uso agregar
        DNI = dni;
        Nombre = nom;
        Apellido = ape;
        Email = em;
        Telefono = tel;
    }
    public Persona() {}
    public String toString(){
        
        return $"DNI: {DNI}, nombre: {Nombre}  {Apellido}, email: {Email}, teléfono: {Telefono}"; 
    }
}
