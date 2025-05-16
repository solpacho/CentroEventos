using System;

namespace Aplicacion;

public class ValidacionException : Exception
{
    public ValidacionException(string mensaje) : base(mensaje) {}

}