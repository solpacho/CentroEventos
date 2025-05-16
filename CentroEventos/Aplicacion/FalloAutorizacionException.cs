using System;

namespace Aplicacion;

public class FalloAutorizacionException : Exception
{
    public FalloAutorizacionException(string mensaje)  :base(mensaje) {}
}
