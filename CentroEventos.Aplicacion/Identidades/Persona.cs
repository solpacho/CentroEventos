using System.Data.Common;

namespace CentroEventos.Aplicacion;

public class Persona
{  
    public int Id{get;set;}
    public string DNI{get;set;} = string.Empty;
    public string Nombre {get;set;} = string.Empty;
    public string Apellido{get;set;} = string.Empty;
    public string Email{get;set;} = string.Empty;
    public string Telefono{get;set;} = string.Empty;


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
