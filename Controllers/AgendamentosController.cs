using Beautysoft.Models;
using Beautysoft.Services;
using Beautysoft.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beautysoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentosController : ControllerBase
    {
        private readonly IAgendamentoService _agendamentoService;

        public AgendamentosController(IAgendamentoService agendamentoService)
        {
            _agendamentoService = agendamentoService;
        }
        [HttpPost]
        public async Task<ActionResult<Agendamento>> CadastrarAgendamento([FromBody] Agendamento agendamento)
        {
            return await _agendamentoService.CadastrarAgendamento(agendamento);
        }
        [HttpGet]
        public async Task<ActionResult<List<Agendamento>>> ObterTodosAgendamentos()
        {
            try
            {
                var agendamento = await _agendamentoService.ObterTodosAgendamentos();

                return Ok(agendamento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> CancelarAgendamento(int id)
        {
            try
            {
                var result = await _agendamentoService.CancelarAgendamento(id);

                if (result)return Ok(true);
                else return NotFound(false); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
