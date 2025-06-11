using CentroEventos.Aplicacion;

namespace Repositorios;

public class RepositorioSqlite
{
    public static void Inicializar()
    {
        using var context = new RepositorioContext();
        if (context.Database.EnsureCreated())
        {
            Console.WriteLine("Se creó base de datos"); // diapo 77
            context.Add(new Persona("4455", "Sol", "PP", "sol.p@gmail.com", "2920"));
            context.SaveChanges();
        }
    }
}