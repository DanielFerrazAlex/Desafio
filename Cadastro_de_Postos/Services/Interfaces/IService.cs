using Cadastro_de_Postos.Models;

namespace Cadastro_de_Postos.Services.Interfaces
{
    public interface IService
    {
        Task InserirPostoVacinacao(PostosModel posto);
        Task<bool> DeletePostos(int Id);
    }
}
