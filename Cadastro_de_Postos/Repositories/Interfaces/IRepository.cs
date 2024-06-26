using Cadastro_de_Postos.Models;

namespace Cadastro_de_Postos.Repositories.Interfaces
{
    public interface IRepository
    {
        Task<List<PostosModel>> GetAllInformation();
        Task<int> CreatePostos(PostosModel posto);
        Task<int> CreateVacinas(VacinasModel vacina);
        Task<bool> DeletePostos(int Id);
    }
}
