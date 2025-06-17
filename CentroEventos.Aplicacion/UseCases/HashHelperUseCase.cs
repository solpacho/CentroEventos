

namespace CentroEventos.Aplicacion;

public class HashHelperUseCase
{
    private readonly IHashService _hashService;

    public HashHelperUseCase(IHashService hashService)
    {
        _hashService = hashService;
    }

    public string GenerarHash(string passwordPlano)
    {
        return _hashService.Hash(passwordPlano);
    }
}
