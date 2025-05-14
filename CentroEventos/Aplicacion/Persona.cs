using System.Data.Common;

namespace Aplicacion;

public class Persona
{   // ID AUTOINCREMENTAL, REPOSITORIO ASIGNA
    public int _id; // en el repositorio, va public o private?
    public string DNI{get;set;}
    public string Nombre {get;set;}
    public string Apellido{get;set;}
    public string Email{get;set;}
    public string Telefono{get;set;}
    public Persona(string dni, string nom, string ape, string em, string tel)
    {
        ValidadorPersona.Validar(dni, nom, ape, em);

        DNI = dni;
        Nombre = nom;
        Apellido = ape;
        Email = em;
        Telefono = tel;
    }
    public void AsignarId(int id)
    {
        _id = id;
    }

    public String toString(){
        
        return $"DNI: {DNI}, nombre: {Nombre}  {Apellido}, email: {Email}, teléfono: {Telefono}"; 
    }
}
