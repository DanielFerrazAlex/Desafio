using Cadastro_de_Postos.Models;
using Cadastro_de_Postos.Repositories.Interfaces;
using Cadastro_de_Postos.Services.Interfaces;
using Microsoft.Extensions.Hosting;

namespace Cadastro_de_Postos.Services
{
    public class Service : IService
    {
        private readonly IRepository _repository;
        private readonly ILogger<Service> _logger;
        public Service(ILogger<Service> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<List<PostosModel>> GetAllInformation()
        {
            try
            {
                return await _repository.GetAllInformation();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao buscar informações: {ex.Message}");
                throw;
            }
        }

        public async Task InserirPostoVacinacao(PostosModel posto)
        {
            try
            {
                await _repository.InserirPostoVacinacao(posto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao inserir informações: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> DeletePostos(int Id)
        {
            try
            {
                var result = await _repository.DeletePostos(Id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao deletar informações: {ex.Message}");
                throw;
            }
        }
    }
}
