using Beautysoft.DTOs;
using Beautysoft.Models;
using Beautysoft.Services.Interfaces;
using BeautySoftAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace Beautysoft.Services
{
    public class MensagemTemporariaService : IMensagemTemporariaService
    {
        private readonly DataContext _context;

        public MensagemTemporariaService(DataContext context)
        {
            _context = context;
        }
        public async Task AdicionarMensagemTemporariaAsync(MensagemTemporariaModel mensagemTemporaria)
        {
            _context.MensagensTemporarias.Add(mensagemTemporaria);
            await _context.SaveChangesAsync();
        }


        public async Task<MensagemTemporariaModel> BuscarMensagemTemporariaPorIdAsync(int mensagemTemporariaId) => await _context.MensagensTemporarias.FindAsync(mensagemTemporariaId);

        public async Task<List<MensagemTemporariaModel>> BuscarTodasMensagensTemporariasAsync()
        {
            return await _context.MensagensTemporarias.ToListAsync();
        }

        public async Task DeletarMensagemTemporariaAsync(int mensagemTemporariaId)
        {
            var mensagemTemporaria = await _context.MensagensTemporarias.FindAsync(mensagemTemporariaId);

            _context.MensagensTemporarias.Remove(mensagemTemporaria);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarMensagemTemporariaAsync(int mensagemTemporariaId, MensagemTemporariaDTO mensagemTemporariaDto)
        {

            var mensagemTemporaria = await _context.MensagensTemporarias.FirstOrDefaultAsync(h => h.Id == mensagemTemporariaId);
            if (mensagemTemporaria != null)
            {
                mensagemTemporaria.Nome = mensagemTemporariaDto.Nome;
                mensagemTemporaria.Descricao = mensagemTemporariaDto.Descricao;
                mensagemTemporaria.Habilitado = mensagemTemporariaDto.Habilitado;
                mensagemTemporaria.TipoMensagemTemporaria = mensagemTemporariaDto.TipoMensagemTemporaria;

                await _context.SaveChangesAsync();
            }
        }

    }
}
