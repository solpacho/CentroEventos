
public class ServicioAutorizacionProvisorio : IServicioAutorizacion{
    public bool PoseeElPermiso(int idUsuario, Permiso permiso){
        return idUsuario==1;
    }
}