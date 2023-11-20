using Beautysoft.Models;

namespace Beautysoft.Services.Interfaces
{
    public interface IAgendamentoService
    {
        Task<List<Agendamento>> ObterTodosAgendamentos();
        Task<Agendamento> CadastrarAgendamento(Agendamento agendamento);
    }
}
