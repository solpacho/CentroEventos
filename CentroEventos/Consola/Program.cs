using system;
using CentroEventos.Aplicacion;
using CentroEventos.Repositorios;


//Configuro dependencias.
IRepositorioEvento repoev = new RepositorioEventosTXT();
IRepositorioPersona repope = new RepositorioPersonaTXT();
IRepositorioReserva repore = new RepositorioReservaTXT();

//se crean los casos de uso

var agregarEvento = new AgregarEventoUseCase(repoeventos);
var listarEvento = new ListarEventosUseCase(repoeventos);
var 
var
var
var
var
var
var
var
var
var
var
var


//ejecuto casos de uso
EventoDeportivo evento1 = new EventoDeportivo() {/*atributos y sus valores*/};

