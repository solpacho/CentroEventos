
namespace CentroEventos.Aplicacion;
public class ValidadorReserva(IRepositorioPersona repoper, IRepositorioEvento repoeve,IRepositorioReserva repores)
{

    public bool Validar(Persona persona, EventoDeportivo evento, out string mensajeError){
        mensajeError="";

        if (!repoper.ExistePersona(persona.Id)) {
            mensajeError="El ID de persona no existe. \n";
        }
        if (!repoeve.ExisteEvento(evento.Id)) {
            mensajeError="No se encuentran eventos con ese ID. \n";
        }
        if (repores.ReservaExistente(persona.Id,evento.Id)) {
            mensajeError="Esta persona ya ha reservado para este evento. \n";
        }
        if (repores.CantidadReservasEvento(evento.Id) == evento.CupoMaximo) {
            mensajeError = "No hay cupo disponible para este evento. \n";
        }
        return (mensajeError=="");    
    }
}