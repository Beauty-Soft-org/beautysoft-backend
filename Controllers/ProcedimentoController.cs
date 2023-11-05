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
        public static IWebHostEnvironment _webHostEnvironment;

        public ProcedimentoController(IProcedimentoService prodService, IWebHostEnvironment webHostEnvironment)
        {
            _prodService = prodService;
            _webHostEnvironment = webHostEnvironment;

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
            var procedimento = await _prodService.BuscarProcedimentoPorIdAsync(id);
            if (procedimento == null) return NotFound("Id do procedimento não encontrado.");
            return Ok(procedimento);
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

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage([FromForm] UploadImagemDto i)
        {
            if (i.InserirArquivo == null || i.InserirArquivo.Length == 0)
            {
                return BadRequest("Nenhuma imagem enviada.");
            }

            return Ok("Imagem enviada com sucesso.");
        }
        [HttpGet("download/{imageName}")]
        public IActionResult DownloadImage(string imageName)
        {
            var imageUrl = Url.Content($"~/imagens/{imageName}");
            return Ok(new { ImageUrl = imageUrl });
        }


    }
}



