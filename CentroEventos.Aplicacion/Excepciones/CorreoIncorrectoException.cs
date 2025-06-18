using System;

namespace CentroEventos.Aplicacion.Excepciones;

public class CorreoIncorrectoException : Exception
{
    public CorreoIncorrectoException(string mensaje): base(mensaje) {}

}
