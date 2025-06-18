using CentroEventos.Aplicacion;

public class SesionUsuario
{
    public Usuario? Usuario { get; private set; }

    public event Action? OnChange;

    public bool EstaLogueado => Usuario != null;

    public void IniciarSesion(Usuario u)
    {
        Usuario = u;
        OnChange?.Invoke();
    }

    public void CerrarSesion()
    {
        Usuario = null;
        OnChange?.Invoke();
    }

    public string Email => Usuario?.Email ?? "";
}
