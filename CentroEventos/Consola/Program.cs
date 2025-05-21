using Aplicacion; //duda? 
using CentroEventos.Aplicacion;
using CentroEventos.Repositorios;

// === Configuración inicial ===
var repoPersona = new RepositorioPersona();
var repoEvento = new RepositorioEventosTXT();
var repoReserva = new RepositorioReserva();

var servicioAutorizacion = new ServicioAutorizacionProvisorio();
var validadorPersona = new ValidadorPersona ();
var validadorEvento = new ValidadorEventos(repoPersona); 
var validadorReserva = new ValidadorReserva(repoPersona, repoEvento, repoReserva);

// Personas
var altaPersona = new PersonaAltaUseCase(repoPersona, validadorPersona, servicioAutorizacion);
var bajaPersona = new PersonaBajaUseCase(repoPersona, servicioAutorizacion, repoEvento, repoReserva, validadorPersona);
var modificarPersona = new PersonaModificacionUseCase(repoPersona, validadorPersona, servicioAutorizacion);
var listarPersonas = new ListarPersonaUseCase(repoPersona);

// Eventos
var altaEvento = new EventoDeportivoAltaUseCase(repoEvento, validadorEvento, servicioAutorizacion);
var bajaEvento = new EventoDeportivoBajaUseCase(repoEvento, repoReserva, servicioAutorizacion);
var modificarEvento = new EventoDeportivoModificacionUseCase(repoEvento, validadorEvento, servicioAutorizacion);
var listarEventos = new ListarEventosUseCase(repoEvento);

// Reservas
var altaReserva = new ReservaAltaUseCase(repoReserva, repoEvento, repoPersona, servicioAutorizacion);
var bajaReserva = new ReservaBajaUseCase(repoReserva, servicioAutorizacion);
var modificarReserva = new ReservaModificacionUseCase(repoReserva, servicioAutorizacion);
var listarReservas = new ListarReservasUseCase(repoReserva);

Console.WriteLine("======================= Sistema de Gestión del Centro Deportivo Universitario ========================");
Console.Write("Ingrese su ID de usuario (1 usuario autorizado, !1 no autorizado): ");
int idUsuario = int.Parse(Console.ReadLine()!);

// === Menú Principal ===
bool salir = false;
while (!salir)
{
    Console.WriteLine("\nSeleccione una categoría:");
    Console.WriteLine("1. Personas");
    Console.WriteLine("2. Eventos Deportivos");
    Console.WriteLine("3. Reservas");
    Console.WriteLine("4. Salir");

    Console.Write("Opción: ");
    int opcion = int.Parse(Console.ReadLine()!);

    switch (opcion)
    {
        case 1:
            MenuPersonas(altaPersona, bajaPersona, modificarPersona, listarPersonas, idUsuario);
            break;
        case 2:
            MenuEventos(altaEvento, bajaEvento, modificarEvento, listarEventos, idUsuario);
            break;
        case 3:
            MenuReservas(altaReserva, bajaReserva, modificarReserva, listarReservas, idUsuario);
            break;
        case 4:
            salir = true;
            Console.WriteLine(" Hasta luego ");
            break;
        default:
            Console.WriteLine(" Opción no válida. ");
            break;
    }
}

// === SUBMENÚS ===

static void MenuPersonas(PersonaAltaUseCase alta, PersonaBajaUseCase baja, PersonaModificacionUseCase modificar, ListarPersonaUseCase listar, int idUsuario)
{
    bool volver = false;
    while (!volver)
    {
        Console.WriteLine("\nGestión de Personas:");
        Console.WriteLine("1. Alta");
        Console.WriteLine("2. Baja");
        Console.WriteLine("3. Modificación");
        Console.WriteLine("4. Listado");
        Console.WriteLine("5. Volver");

        Console.Write("Opción: ");
        int opcion = int.Parse(Console.ReadLine()!);

        switch (opcion)
        {
            case 1:
                Console.WriteLine(" Persona: ");
                Console.Write("DNI: ");
                string dni = Console.ReadLine()!;
                Console.Write("Nombre: ");
                string nombre = Console.ReadLine()!;
                Console.Write("Apellido: ");
                string apellido = Console.ReadLine()!;
                Console.Write("Email: ");
                string email = Console.ReadLine()!;
                Console.Write("Teléfono: ");
                string tel = Console.ReadLine()!;
                var persona = new Persona(dni, nombre, apellido, email, tel);
                try {alta.Ejecutar(persona, idUsuario); Console.WriteLine("Persona agregada.");}
                catch (Exception ex) {Console.WriteLine($"Error: {ex.Message}"); }
                break;

            case 2:
                Console.Write("ID Persona a eliminar: ");
                int idBaja = int.Parse(Console.ReadLine()!);
                try { baja.Ejecutar(idBaja, idUsuario); Console.WriteLine("Persona eliminada.");}
                catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
                break;

            case 3:
                Console.Write("ID Persona a modificar: ");
                int idMod = int.Parse(Console.ReadLine()!);
                Console.Write("Nuevo DNI: ");
                string dniMod = Console.ReadLine()!;
                Console.Write("Nuevo Nombre: ");
                string nomMod = Console.ReadLine()!;
                Console.Write("Nuevo Apellido: ");
                string apeMod = Console.ReadLine()!;
                Console.Write("Nuevo Email: ");
                string mailMod = Console.ReadLine()!;
                Console.Write("Nuevo Teléfono: ");
                string telMod = Console.ReadLine()!;
                var personaMod = new Persona(dniMod, nomMod, apeMod, mailMod, telMod) { Id = idMod };
                try { modificar.Ejecutar(personaMod, idUsuario); Console.WriteLine("Persona modificada."); }
                catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
                break;

            case 4:
                var lista = listar.Ejecutar(); //preguntar manana con los chicos cambie de void a list
                Console.WriteLine("--- Personas ---");
                foreach (var p in lista) Console.WriteLine(p);
                break;

            case 5:
                volver = true;
                break;

            default:
                Console.WriteLine(" Opción no válida.");
                break;
        }
    }
}

static void MenuEventos(EventoDeportivoAltaUseCase alta, EventoDeportivoBajaUseCase baja, EventoDeportivoModificacionUseCase modificar, ListarEventosUseCase listar, int idUsuario)
{
    bool volver = false;
    while (!volver)
    {
        Console.WriteLine("\nGestión de Eventos Deportivos:");
        Console.WriteLine("1. Alta");
        Console.WriteLine("2. Baja");
        Console.WriteLine("3. Modificación");
        Console.WriteLine("4. Listado");
        Console.WriteLine("5. Volver");

        Console.Write("Opción: ");
        int opcion = int.Parse (Console.ReadLine()!);

        switch (opcion)
        {
            case 1:
                Console.WriteLine(" Evento Deportivo: ");
                Console.Write("Nombre: ");
                string nombre = Console.ReadLine()!;
                Console.Write("Cupo máximo: ");
                int cupo = int.Parse(Console.ReadLine()!);
                Console.Write("ID Responsable: ");
                var idResp = int.Parse(Console.ReadLine()!);
                Console.Write("Fecha y hora (yyyy-MM-dd HH:mm): ");
                DateTime fecha = DateTime.Parse(Console.ReadLine()!);
                Console.Write("Duración (horas): ");
                double duracion = double.Parse(Console.ReadLine()!);
                Console.Write("Descripción: ");
                string descripcion = Console.ReadLine()!;
                var evento = new EventoDeportivo(nombre, cupo, idResp, fecha, duracion, descripcion);
                try { alta.Ejecutar(evento, idUsuario); Console.WriteLine("Evento creado."); }
                catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
                break;

            case 2:
                Console.Write("ID del Evento a eliminar: ");
                int idEliminar = int.Parse(Console.ReadLine()!);
                try { baja.Ejecutar(idEliminar, idUsuario); Console.WriteLine("Evento eliminado."); }
                catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
                break;

            case 3:
                Console.Write("ID del Evento a modificar: ");
                int idMod = int.Parse(Console.ReadLine()!);
                Console.Write("Nuevo Nombre: ");
                string n = Console.ReadLine()!;
                Console.Write("Nuevo Cupo: ");
                int c = int.Parse(Console.ReadLine()!);
                Console.Write("Nuevo ID Responsable: ");
                var idR = int.Parse(Console.ReadLine()!);
                Console.Write("Nueva Fecha y hora: ");
                DateTime f = DateTime.Parse(Console.ReadLine()!);
                Console.Write("Nueva Duración: ");
                var d = double.Parse(Console.ReadLine()!);
                Console.Write("Nueva Descripción: ");
                string desc = Console.ReadLine()!;
                var ev = new EventoDeportivo(n, c, idR, f, d, desc) { Id = idMod }; //necesario????
                try { modificar.Ejecutar(ev, idUsuario); Console.WriteLine("Evento modificado."); }
                catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
                break;

            case 4:
                var eventos = listar.Ejecutar();
                Console.WriteLine("--- Eventos Deportivos ---");
                foreach (var e in eventos) Console.WriteLine(e);
                break;

            case 5:
                volver = true;
                break;

            default:
                Console.WriteLine(" Opción no válida.");
                break;
        }
    }
}

static void MenuReservas(ReservaAltaUseCase alta, ReservaBajaUseCase baja, ReservaModificacionUseCase modificar, ListarReservasUseCase listar, int idUsuario)
{
    bool volver = false;
    while (!volver)
    {
        Console.WriteLine("\nGestión de Reservas:");
        Console.WriteLine("1. Alta");
        Console.WriteLine("2. Baja");
        Console.WriteLine("3. Modificación");
        Console.WriteLine("4. Listado");
        Console.WriteLine("5. Volver");

        Console.Write("Opción: ");
        int opcion = int.Parse(Console.ReadLine()!);

        switch (opcion)
        {
            case 1:
                Console.WriteLine(" Reserva: ");
                Console.Write("ID Persona: ");
                int idPersona = int.Parse(Console.ReadLine()!);
                Console.Write("ID Evento: ");
                int idEvento = int.Parse(Console.ReadLine()!);
                var estado = EstadoAsistencia.Pendiente; //esta bien? o con numeros?
                var reserva = new Reserva(idPersona, idEvento, estado);
                try { alta.Ejecutar(reserva, idUsuario); Console.WriteLine(" Reserva creada."); }
                catch (Exception ex) { Console.WriteLine($" Error: {ex.Message}"); }
                break;

            case 2:
                Console.Write("ID de Reserva a eliminar: ");
                var idEliminar = int.Parse(Console.ReadLine()!);
                try { baja.Ejecutar(idEliminar, idUsuario); Console.WriteLine(" Reserva eliminada."); }
                catch (Exception ex) { Console.WriteLine($" Error: {ex.Message}"); }
                break;

            case 3:
                Console.Write("ID Persona: "); //preguntar aca si reserva recibe id de persona y evento o id de reserva
                int idMod = int.Parse(Console.ReadLine()!);
                Console.Write("ID Evento: ");
                int idEvMod = int.Parse(Console.ReadLine()!);
                Console.Write("Nuevo estado (0=Pendiente, 1=Presente, 2=Ausente): "); //preguntar si el estado se asigna asi
                var nuevoEstado = (EstadoAsistencia)int.Parse(Console.ReadLine()!);
                var nuevaReserva = new Reserva(idMod,idEvMod,nuevoEstado) { Id = idMod };
                try { modificar.Ejecutar(nuevaReserva, idUsuario); Console.WriteLine("Reserva modificada."); }
                catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
                break;

            case 4:
                var reservas = listar.Ejecutar();
                Console.WriteLine("--- Reservas ---");
                foreach (var r in reservas) Console.WriteLine(r);
                break;

            case 5:
                volver = true;
                break;

            default:
                Console.WriteLine(" Opción no válida.");
                break;
        }
    }
}
