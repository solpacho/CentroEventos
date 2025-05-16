using System;

namespace Aplicacion;

public class DuplicadoException : Exception
{
    public DuplicadoException(string mensaje) : base(mensaje) {}
}
