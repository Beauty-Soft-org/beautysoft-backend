using Beautysoft.DTOs;
using Beautysoft.Models;
using Beautysoft.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Beautysoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedimentoController : ControllerBase
    {
        private readonly IProcedimentoService _prodService;

        public ProcedimentoController(IProcedimentoService prodService)
        {
            this._prodService = prodService;

        }


        [HttpGet]
        public async Task<ActionResult<List<Procedimento>>> BuscarProcedimentos()
        {
            var procedimentos = await _prodService.BuscarTodosProcedimentosAsync();
            return Ok(procedimentos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Procedimento>> BuscarProcedimentoPorId(int id)
        {
            var usuario = await _prodService.BuscarProcedimentoPorIdAsync(id);
            if (usuario == null) return NotFound("Id não encontrado.");
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<Procedimento>> AdicionarProcedimento([FromBody] Procedimento procedimento)
        {
            await _prodService.AdicionarProcedimentoAsync(procedimento);
            return CreatedAtAction(nameof(BuscarProcedimentoPorId), new { id = procedimento.Id }, procedimento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarProcedimento(int id, [FromBody] ProcedimentoDto procedimentoDto)
        {
            if (procedimentoDto == null) return BadRequest("Dados inválidos para o procedimento.");

            await _prodService.AtualizarProcedimentoAsync(id, procedimentoDto);

            return Ok(new { message = "O Procedimento foi atualizado com sucesso." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarProcedimento(int id)
        {
            if (id == null) return BadRequest("Id não encontrado.");
            await _prodService.DeletarProcedimentoAsync(id);

            return Ok("Procedimento deletado com Sucesso!");
        }
    }
}
