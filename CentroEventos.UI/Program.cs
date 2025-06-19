using CentroEventos.UI.Components;
using CentroEventos.Aplicacion;
using CentroEventos.Repositorios;
using CentroEventos.UI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<UsuarioAltaUseCase>();
builder.Services.AddScoped<HashHelperUseCase>();
builder.Services.AddScoped<IHashService, HashService>();
builder.Services.AddScoped<ValidadorUsuario>();
builder.Services.AddScoped<IServicioAutorizacion, ServicioAutorizacionProvisorio>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioSQL>();
builder.Services.AddScoped<IRepositorioPersona, RepositorioPersonaSQL>(); // faltaba agregar
builder.Services.AddScoped<IRepositorioEvento,  RepositorioEventosSQL>(); // faltaba agregar
builder.Services.AddScoped<IniciarSesionUseCase>();
builder.Services.AddScoped<SesionUsuario>();
// UseCase para listar responsables
builder.Services.AddScoped<ListarResponsablesUseCase>();
builder.Services.AddScoped<ListarUsuariosUseCase>();
builder.Services.AddScoped<ListarPersonaUseCase>();
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
