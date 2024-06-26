using Cadastro_de_Postos.Models;

namespace Cadastro_de_Postos.Repositories.Interfaces
{
    public interface IRepository
    {
        Task<List<PostosModel>> GetAllInformation();
        Task CreatePostos(PostosModel posto);
        Task CreateVacinas(VacinasModel vacina);
        Task<bool> DeletePostos(int Id);
    }
}
