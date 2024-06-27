using Cadastro_de_Postos.Models;
using Cadastro_de_Postos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro_de_Postos.Controllers
{
    public class Controller : ControllerBase
    {
        private readonly IService _service;
        public Controller(ILogger<Controller> logger, IService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllInformation()
        {
            try
            {
                return Ok(await _service.GetAllInformation());
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> InserirPostoVacinacao([FromBody] PostosModel posto)
        {
            try
            {
                await _service.InserirPostoVacinacao(posto);
                return NoContent();
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
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
                throw;
            }
        }
    }
}
