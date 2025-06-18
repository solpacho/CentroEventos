using CentroEventos.Aplicacion;
using CentroEventos.Repositorios;

//esto lo que hace es controlar el esado de la sesión. Cuando se ejecuta se obtiene el Usuario mediante
// IniciarSesionUseCase (si devuelve null=sesion no iniciada, si es <> null, sesión iniciada). Obtiene el
//Usuario pq precisa ver su id para conocer sus permisos. Cuando se llama a CerrarSesion pone Usario en null
public class SesionUsuario(IniciarSesionUseCase login)
{

    public Usuario? Usuario { get; private set; }

    public event Action? OnChange;

    public bool EstaLogueado => Usuario != null;

    public void IniciarSesion(String email, String contrasenia)
    {
        Usuario = login.Ejecutar(email, contrasenia);
        OnChange?.Invoke();
    }

    public void CerrarSesion()
    {
        Usuario = null;
        OnChange?.Invoke();
    }

    public string Email => Usuario?.Email ?? "";
}
