using Microsoft.EntityFrameworkCore;
using CentroEventos.Aplicacion;

namespace Repositorios
{
    public class RepositorioContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<EventoDeportivo> Eventos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Repositorio.sqlite");
        }
    }
}
