using Aplicacion;

public static class ValidadorPersona{

    public static void Validar(string dni, string nom, string ape, string em){
        if (string.IsNullOrEmpty(dni)){
            throw new Exception("El dni no puede estar vacío.");
        }
        if (string.IsNullOrEmpty(nom)){
            throw new Exception("El nombre no puede estar vacío.");
        }
        if (string.IsNullOrEmpty(ape)){
            throw new Exception("El apellido no puede estar vacío.");
        }
        if (string.IsNullOrEmpty(em)){
            throw new Exception("El email no puede estar vacío.");
        }
    }
}