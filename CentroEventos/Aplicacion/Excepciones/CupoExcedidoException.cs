using System;

namespace CentroEventos.Aplicacion;

public class CupoExcedidoException : Exception
{
    public CupoExcedidoException(string mensaje): base(mensaje) {}
}
