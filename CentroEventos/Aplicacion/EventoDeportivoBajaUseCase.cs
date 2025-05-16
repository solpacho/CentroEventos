using System;

namespace Aplicacion;

public class EventoDeportivoBajaUseCase(IRepositorioEvento repositorio, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(int idEvento, int IdUsuario)
    {
        if (!autorizacion.PoseeElPermiso(IdUsuario, Permiso.EventoBaja)) {
            throw new FalloAutorizacionException("No posee permisos para realizar esta acción. \n");
        }

        if (!repositorio.existeEvento(idEvento)) {
            throw new EntidadNotFound("No se ha encontrado el evento. \n")
        }
        //reglas!!
        repositorio.EliminarEvento(idEvento);
    }
}