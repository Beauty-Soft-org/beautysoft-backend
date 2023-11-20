using Beautysoft.Models;
using Beautysoft.Services.Interfaces;
using BeautySoftAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace Beautysoft.Services
{
    public class AgendamentoService : IAgendamentoService
    {
        private readonly DataContext _context;

        public AgendamentoService(DataContext context)
        {
            _context = context;
        }

        public async Task<Agendamento> CadastrarAgendamento(Agendamento agendamento)
        {
            _context.Agendamentos.Add(agendamento);
            await _context.SaveChangesAsync();
            return agendamento;
        }

        public async Task<List<Agendamento>> ObterTodosAgendamentos()
        {
            return await _context.Agendamentos.ToListAsync();

        }
    }
}
