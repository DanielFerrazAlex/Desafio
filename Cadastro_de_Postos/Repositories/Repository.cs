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

        public async Task InserirPostoVacinacao(PostosModel posto)
        {
            try
            {
                using (SqlConnection conn = new(Env.GetConnectionDataBase()))
                {
                    if (posto.Vacinas[0].DataValidade <= DateTime.Now)
                    {
                        _logger.LogInformation("A data de validade da vacina deve ser no futuro.");
                    }

                    int countPosto = await conn.ExecuteScalarAsync<int>(Script.VerifyPosto, new { NomePosto = posto.NomePosto });

                    if (countPosto > 0)
                    {
                        _logger.LogInformation("Não pode haver nome repetido de postos:");
                    }

                    int countLote = await conn.ExecuteScalarAsync<int>(Script.VerifyLote, new { Lote = posto.Vacinas[0].Lote });

                    if (countLote > 0)
                    {
                        _logger.LogInformation("Não pode haver Lotes repetidos de vacina");
                    }

                    int postoId = conn.QueryAsync<int>(Script.CreatePosto, posto).Result.FirstOrDefault();

                    if (posto.Vacinas != null && posto.Vacinas.Any())
                    {
                        foreach (var vacina in posto.Vacinas)
                        {
                            vacina.Id = postoId;
                            await conn.ExecuteAsync(Script.CreateVacinas, vacina);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao criar posto e suas respectivas vacinas: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> DeletePostos(int Id)
        {
            try
            {
                using (SqlConnection conn = new(Env.GetConnectionDataBase()))
                {
                    var QtdVacinas = await conn.ExecuteScalarAsync<int>(Script.VerifyVacina, new { Id = Id });

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
    }
}
