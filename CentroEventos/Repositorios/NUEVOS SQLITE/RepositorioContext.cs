using Microsoft.EntityFrameworkCore;
using CentroEventos.Aplicacion;

namespace Repositorios
{
    public class RepositorioContext : DbContext
    {
        #nullable disable
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<EventoDeportivo> Eventos { get; set; }
        
        public DbSet<Usuario> Usuarios { get; set; }
        #nullable restore

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=RepositorioProyecto.sqlite");
        }
    }
}
