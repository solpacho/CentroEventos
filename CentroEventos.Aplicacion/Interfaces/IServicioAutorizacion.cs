using System;

namespace CentroEventos.Aplicacion;

public interface IServicioAutorizacion
{
    bool PoseeElPermiso(int IdUsuario, Permiso permiso);

    void DarPermiso(int idEmisor, int idReceptor, Permiso permiso);

}
