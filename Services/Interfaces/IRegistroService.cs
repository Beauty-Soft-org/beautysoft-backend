using Beautysoft.Models;

namespace Beautysoft.Services.Interfaces
{
    public interface IRegistroService
    {
        Task RegistrarAsync(RegisterViewModel registro);
    }
}
