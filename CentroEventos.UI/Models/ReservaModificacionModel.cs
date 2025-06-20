using System.ComponentModel.DataAnnotations;
using CentroEventos.Aplicacion;

namespace CentroEventos.UI;

public class ReservaModificacionModel
{
    public int Id { get; set; }
    
    // PersonaId se mantiene pero no se permite modificar
    public int PersonaId { get; set; }
    
    [Required(ErrorMessage = "El ID del evento es requerido")]
    public int EventoDeportivoId { get; set; }
    
    public DateTime FechaAltaReserva { get; set; }
    
    [Required(ErrorMessage = "El estado es requerido")]
    public EstadoAsistencia Estado { get; set; }
}
