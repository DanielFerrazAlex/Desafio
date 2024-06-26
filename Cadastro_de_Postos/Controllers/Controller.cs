using Cadastro_de_Postos.Models;
using Cadastro_de_Postos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro_de_Postos.Controllers
{
    public class Controller : ControllerBase
    {
        private readonly ILogger<Controller> _logger;
        private readonly IService _service;
        public Controller(ILogger<Controller> logger, IService service)
        {
            _logger = logger;
            _service = service;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreatePostos([FromBody] PostosModel posto)
        {
            try
            {
                await _service.CreatePostos(posto);
                return NoContent();
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
                _logger.LogError("Algo de errado aconteceu: ");
                throw;
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateVacina([FromBody] VacinasModel vacina)
        {
            try
            {
                await _service.CreateVacinas(vacina);
                return NoContent();
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
                _logger.LogError("Algo de errado aconteceu: ");
                throw;
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeletePosto(int Id)
        {
            try
            {
                await _service.DeletePostos(Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
                _logger.LogError("Algo de errado aconteceu: ");
                throw;
            }
        }
    }
}
