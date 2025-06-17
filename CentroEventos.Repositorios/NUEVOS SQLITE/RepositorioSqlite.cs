using CentroEventos.Aplicacion;
using Microsoft.EntityFrameworkCore;

namespace CentroEventos.Repositorios;

public class RepositorioSqlite
{
    public static void Inicializar()
    {
        using var context = new RepositorioContext();
        
        context.Database.EnsureCreated();
        var connection = context.Database.GetDbConnection();
        connection.Open();
        using (var command = connection.CreateCommand())
        {
            command.CommandText = "PRAGMA journal_mode=DELETE;";
            command.ExecuteNonQuery();
        }
    }
}