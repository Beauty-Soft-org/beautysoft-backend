
using Beautysoft.Models;
using Beautysoft.Services.Interfaces;
using BeautySoftAPI.Data;

namespace Beautysoft.Services
{
    public class RegistroService : IRegistroService
    {
        private readonly DataContext _context;

        public RegistroService(DataContext context)
        {
            _context = context;
        }
        public async Task RegistrarAsync(RegisterViewModel registro)
        {            
            _context.Registros.Add(registro);
             await _context.SaveChangesAsync();
            
        }
    }
}
