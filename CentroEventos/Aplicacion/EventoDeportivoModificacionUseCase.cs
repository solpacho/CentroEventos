using System;
namespace Aplicacion;

public class EventoDeportivoModificacionUseCase(IRepositorioEvento repositorio, ValidadorEventos validador, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(EventoDeportivo evento, int IdUsuario)
    {
        if (!validador.Validar(evento)) //preguntar por la excepcion
            throw new Exception(ValidacionException);
        //if (repositorio.ObtenerPorId(evento.Id) == null)
        //   throw new Exception(EntidadNotFoundException);
        if (!autorizacion.PoseeElPermiso(IdUsuario, Permiso.EventoModificacion))
            throw new Exception(FalloAutorizacionException);
        // repositorio.Modificar(evento); falta el metodo modificar en el repo
    }
}