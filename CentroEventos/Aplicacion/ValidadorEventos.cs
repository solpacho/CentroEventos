using System;

namespace CentroDeportivo;

public class ValidadorEventos
{
    public bool Validar(EventoDeportivo evento, out string mensajeError) {
        mensajeError="";
        if (string.IsNullOrWhiteSpace(evento.Nombre)) {
            mensajeError = "Nombre inválido. \n";
        }
        if (string.IsNullOrWhiteSpace(evento.Descripcion)) {
            mensajeError = "Descripción inválida. \n";
        }
        if (!int.IsPositive(evento.CupoMaximo)) {
            mensajeError = "El cupo debe ser mayor a 0. \n";
        }
        if (!double.IsPositive(evento.DuracionHoras)) {
            mensajeError = "La duración del evento debe ser mayor a 0. \n";
        }
        if (DateTime.Compare(evento.FechaHoraInicio,DateTime.Now)<0) {
            mensajeError = "La fecha debe ser posterior o igual a la fecha actual. \n";
        }
        return (mensajeError=="");
    }
    
}
