using System;

namespace Aplicacion;

public class OperacionInvalidaException : Exception
{
    public OperacionInvalidaException(string mensaje): base(mensaje) {}
}
