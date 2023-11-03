using Beautysoft.DTOs;
using Beautysoft.Models;

namespace Beautysoft.Services.Interfaces
{
    public interface IMensagemTemporariaService
    {
        Task<List<MensagemTemporariaModel>> BuscarTodasMensagensTemporariasAsync();
        Task<MensagemTemporariaModel> BuscarMensagemTemporariaPorIdAsync(int mensagemTemporariaId);
        Task AdicionarMensagemTemporariaAsync(MensagemTemporariaModel mensagemTemporaria);
        Task AtualizarMensagemTemporariaAsync(int mensagemTemporariaId, MensagemTemporariaDTO mensagemTemporariaDto);
        Task DeletarMensagemTemporariaAsync(int mensagemTemporariaId);
    }
}
