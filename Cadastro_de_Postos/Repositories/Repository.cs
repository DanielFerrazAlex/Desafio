using Cadastro_de_Postos.Data;
using Cadastro_de_Postos.Models;
using Cadastro_de_Postos.Repositories.Interfaces;
using Cadastro_de_Postos.Repositories.Scripts;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Cadastro_de_Postos.Repositories
{
    public class Repository : IRepository
    {
        private readonly ILogger<Repository> _logger;
        public Repository(ILogger<Repository> logger)
        {
            _logger = logger;
        }
        public async Task<List<PostosModel>> GetAllInformation()
        {
            try
            {
                using (SqlConnection conn = new(Env.GetConnectionDataBase()))
                {
                    var result = await conn.QueryAsync<PostosModel>(Script.GetAll);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao retornar lista com todas informações: {ex.Message}");
                throw;
            }
        }

        public async Task CreatePostos(PostosModel posto)
        {
            try
            {
                if (await VerifyPostoExistAsync(posto.NomePosto))
                {
                    _logger.LogInformation($"Já existe uma vacina com o lote '{posto.NomePosto}'.");
                }

                using (SqlConnection conn = new(Env.GetConnectionDataBase()))
                {
                    await conn.ExecuteAsync(Script.CreatePosto, posto);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao tentar criar Posto de Vacinação: {ex.Message}");
                throw;
            }
        }

        public async Task CreateVacinas(VacinasModel vacina)
        {
            try
            {
                if (await VerifyLoteExistAsync(vacina.Lote))
                {
                    _logger.LogInformation($"Já existe uma vacina com o lote: {vacina.Lote}.");
                }

                if (vacina.DataValidade <= DateTime.Now)
                {
                    _logger.LogInformation("A data de validade da vacina deve ser no futuro.");
                }

                using (SqlConnection conn = new(Env.GetConnectionDataBase()))
                {
                    await conn.ExecuteAsync(Script.CreateVacinas, vacina);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao tentar criar Vacinas: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> DeletePostos(int Id)
        {
            try
            {
                using (SqlConnection conn = new(Env.GetConnectionDataBase()))
                {
                    var QtdVacinas = await conn.ExecuteScalarAsync<int>(Script.VerifyEstoque, new { Id = Id });

                    if (QtdVacinas == 0)
                    {
                        var linhasAfetadas = await conn.ExecuteAsync(Script.DeletePosto, new { Id = Id });
                        return linhasAfetadas > 0;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao deletar posto de vacinação: {ex.Message}");
                throw;
            }
        }

        private async Task<bool> VerifyLoteExistAsync(int lote)
        {
            using (SqlConnection conn = new(Env.GetConnectionDataBase()))
            {
                var count = await conn.ExecuteScalarAsync<int>(Script.VerifyLote, new { Lote = lote });
                return count > 0;
            }
        }

        private async Task<bool> VerifyPostoExistAsync(string? posto)
        {
            using (SqlConnection conn = new(Env.GetConnectionDataBase()))
            {
                var count = await conn.ExecuteScalarAsync<int>(Script.VerifyPosto, new { Nome_Posto = posto });
                return count > 0;
            }
        }
    }
}
