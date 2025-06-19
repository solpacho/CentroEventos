using System.ComponentModel.DataAnnotations;
using CentroEventos.Aplicacion;
namespace CentroEventos.UI;

public class EventoModificacionModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es requerido")]
    [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
    public string Nombre { get; set; } = "";

    [StringLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "La fecha y hora de inicio es requerida")]
    public DateTime FechaHoraInicio { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "La duración es requerida")]
    [Range(1, 24, ErrorMessage = "La duración debe estar entre 1 y 24 horas")]
    public double DuracionHoras { get; set; }

    [Required(ErrorMessage = "El cupo máximo es requerido")]
    [Range(1, 1000, ErrorMessage = "El cupo máximo debe estar entre 1 y 1000 personas")]
    public int CupoMaximo { get; set; }

    [Required(ErrorMessage = "El ID del responsable es requerido")]
    [Range(1, int.MaxValue, ErrorMessage = "El ID del responsable debe ser un número positivo")]
    public int ResponsableId { get; set; }

    public EventoModificacionModel() { }

    public EventoModificacionModel(EventoDeportivo evento)
    {
        Id = evento.Id;
        Nombre = evento.Nombre;
        Descripcion = evento.Descripcion;
        FechaHoraInicio = evento.FechaHoraInicio;
        DuracionHoras = evento.DuracionHoras;
        CupoMaximo = evento.CupoMaximo;
        ResponsableId = evento.ResponsableId;
    }
}
