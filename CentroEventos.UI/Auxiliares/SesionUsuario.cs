// Servicios/SesionUsuario.cs
namespace CentroEventos.UI;
public class SesionUsuario
{
    public bool EstaLogueado { get; private set; } = false;
    public string Email { get; private set; }

    public event Action OnChange;

    public void IniciarSesion(string email)
    {
        Email = email;
        EstaLogueado = true;
        NotificarCambio();
    }

    public void CerrarSesion()
    {
        Email = null;
        EstaLogueado = false;
        NotificarCambio();
    }

    private void NotificarCambio()
    {
        OnChange?.Invoke();
    }
}