using System;
using System.ComponentModel.DataAnnotations;
using CentroEventos.Aplicacion;
namespace CentroEventos.UI;
public class ReservaAltaModel
{
    [Required(ErrorMessage = "El ID de la persona es obligatorio.")]
    public int PersonaId { get; set; }

    [Required(ErrorMessage = "El ID del evento es obligatorio.")]
    public int EventoDeportivoId { get; set; }

    [Required]
    public EstadoAsistencia Estado { get; set; } = EstadoAsistencia.Pendiente;
}
