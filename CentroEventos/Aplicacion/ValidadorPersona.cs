using System;

namespace CentroEventos.Aplicacion;
public class ValidadorPersona
{

    public bool Validar(Persona p){
        if (string.IsNullOrEmpty(p.DNI)){
            throw new Exception("El dni no puede estar vacío.");
        } else if (p.DniRepetido(p.DNI)){ // corregir
            throw new Exception("El dni ya existe.");
        }

        if (string.IsNullOrEmpty(p.Nombre)){
            throw new Exception("El nombre no puede estar vacío.");
        }
        if (string.IsNullOrEmpty(p.Apellido)){
            throw new Exception("El apellido no puede estar vacío.");
        }
        if (string.IsNullOrEmpty(p.Email)){
            throw new Exception("El email no puede estar vacío.");
        }else if (EmailRepetido(p.Email)){ // corregir
            throw new Exception("Email repetido.");
        }
    }
}