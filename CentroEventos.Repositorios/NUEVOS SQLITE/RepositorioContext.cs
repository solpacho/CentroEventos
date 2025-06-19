using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;
using CentroEventos.Aplicacion;

namespace CentroEventos.Repositorios
{
    public static class PermisoJsonHelper
    {
        public static string Serialize(List<Permiso> permisos)
            => JsonSerializer.Serialize(permisos);

        public static List<Permiso> Deserialize(string json)
            => JsonSerializer.Deserialize<List<Permiso>>(json) ?? new List<Permiso>();
    }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var permisosConverter = new ValueConverter<List<Permiso>, string>(
                v => PermisoJsonHelper.Serialize(v),
                v => PermisoJsonHelper.Deserialize(v)
            );

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Permisos)
                .HasConversion(permisosConverter);

            base.OnModelCreating(modelBuilder);
        }
    }
}
