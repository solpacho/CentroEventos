using System.Data.Common;

namespace CentroEventos.Aplicacion;

public class Persona
{   // ID AUTOINCREMENTAL, REPOSITORIO ASIGNA
    public int Id{get;set;}
    public string DNI{get;set;}
    public string Nombre {get;set;}
    public string Apellido{get;set;}
    public string Email{get;set;}
    public string Telefono{get;set;}


    public Persona(string dni, string nom, string ape, string em, string tel)
    {  
        DNI = dni;
        Nombre = nom;
        Apellido = ape;
        Email = em;
        Telefono = tel;
    }
    
    public Persona() {}

    public override String ToString(){
        
        return $"DNI: {DNI}, nombre: {Nombre}  {Apellido}, email: {Email}, teléfono: {Telefono}"; 
    }
}
