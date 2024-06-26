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
        public async Task CreatePostos(PostosModel posto)
        {
            try
            {
                await _repository.CreatePostos(posto);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task CreateVacinas(VacinasModel vacina)
        {
            try
            {
                await _repository.CreateVacinas(vacina);
            }
            catch (Exception ex)
            {

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

                throw;
            }
        }
    }
}
