using System.Data.Common;

namespace Aplicacion;

public class Persona
{   // ID AUTOINCREMENTAL, REPOSITORIO ASIGNA
    private int _id;
    private string _DNI;
    private string _nombre;
    private string _apellido;
    private string _email;
    private string _telefono;
    public Persona(string dni, string nom, string ape, string em, string tel)
    {
        ValidadorPersona.Validar(dni, nom, ape, em);

        _DNI = dni;
        _nombre = nom;
        _apellido = ape;
        _email = em;
        _telefono = tel;
    }
    public string GetDNI() => _DNI;
    public string GetNombre() => _nombre;
    public string GetApellido() => _apellido;
    public string GetEmail() => _email;
    public string GetTelefono() => _telefono;

    public void AsignarId(int id)
    {
        _id = id;
    }

    public String toString(){
        
        return $"DNI: {_DNI}, nombre: {_nombre}  {_apellido}, email: {_email}, teléfono: {_telefono}"; 
    }
}
