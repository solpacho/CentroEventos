using CentroEventos.UI.Components;
using CentroEventos.Aplicacion;
using CentroEventos.Repositorios;
using CentroEventos.UI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Repositorios.
builder.Services.AddScoped<IServicioAutorizacion, ServicioAutorizacionProvisorio>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioSQL>();
builder.Services.AddScoped<IRepositorioPersona, RepositorioPersonaSQL>(); 
builder.Services.AddScoped<IRepositorioEvento,  RepositorioEventosSQL>();
builder.Services.AddScoped<IRepositorioReserva, RepositorioReservaSQL>();
//Validadores
builder.Services.AddScoped<ValidadorUsuario>();
builder.Services.AddScoped<ValidadorPersona>();
builder.Services.AddScoped<ValidadorEventos>();
builder.Services.AddScoped<ValidadorReserva>();
//Casos de uso Usuario
builder.Services.AddScoped<UsuarioAltaUseCase>();
builder.Services.AddScoped<SesionUsuario>();
builder.Services.AddScoped<UsuarioModificacionUseCase>();
builder.Services.AddScoped<HashHelperUseCase>();
builder.Services.AddScoped<IHashService, HashService>();
builder.Services.AddScoped<IniciarSesionUseCase>();
builder.Services.AddScoped<DarPermisoUseCase>();
//Casos de uso persona
builder.Services.AddScoped<PersonaModificacionUseCase>();
builder.Services.AddScoped<PersonaBajaUseCase>();
builder.Services.AddScoped<PersonaAltaUseCase>();
//Casos de uso Reserva
builder.Services.AddScoped<ReservaAltaUseCase>();
builder.Services.AddScoped<ReservaBajaUseCase>();
builder.Services.AddScoped<ReservaModificacionUseCase>();
// UseCase para listar responsables
builder.Services.AddScoped<ListarAsistenciaAEventoUseCase>();
builder.Services.AddScoped<ListarEventosConCupoDisponibleUseCase>();
builder.Services.AddScoped<ListarResponsablesUseCase>();
builder.Services.AddScoped<ListarUsuariosUseCase>();
builder.Services.AddScoped<ListarPersonaUseCase>();
builder.Services.AddScoped<ListarReservasUseCase>();
builder.Services.AddScoped<ListarEventosUseCase>();

var app = builder.Build();
RepositorioSqlite.Inicializar();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

