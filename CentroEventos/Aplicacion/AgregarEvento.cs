using System;

namespace CentroDeportivo;

public class AgregarEvento(IRepositorioEvento repositorio, ValidadorEventos validador)
{
    public void Ejecutar(EventoDeportivo evento) {
        if (!validador.Validar(evento, out string mensajeError)) {
            throw new Exception(mensajeError);
        }
        repositorio.AgregarEvento(evento);
    }
}
