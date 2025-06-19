using System;
using System.ComponentModel.DataAnnotations;

namespace CentroEventos.UI;

    public class EventoAltaModel
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
        public DateTime FechaHoraInicio { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "La duración es obligatoria.")]
        [Range(0.1, 240, ErrorMessage = "La duración debe ser mayor a 0.")]
        public double DuracionHoras { get; set; }

        [Required(ErrorMessage = "El cupo máximo es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El cupo debe ser al menos 1.")]
        public int CupoMaximo { get; set; }

        [Required(ErrorMessage = "Debe indicar el ID del responsable.")]
        public int ResponsableId { get; set; }
    }
