using System;

namespace CentroEventos.Aplicacion.Excepciones;

public class ContrasenaIncorrectaException : Exception
{
    public ContrasenaIncorrectaException(string mensaje): base(mensaje) {}

}
