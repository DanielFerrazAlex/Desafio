using Cadastro_de_Postos.Models;

namespace Cadastro_de_Postos.Repositories.Interfaces
{
    public interface IRepository
    {
        Task<List<PostosModel>> GetAllInformation();
        Task InserirPostoVacinacao(PostosModel posto);
        Task<bool> DeletePostos(int Id);
    }
}
