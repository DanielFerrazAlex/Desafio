using Cadastro_de_Postos.Models;

namespace Cadastro_de_Postos.Services.Interfaces
{
    public interface IService
    {
        Task CreatePostos(PostosModel posto);
        Task CreateVacinas(VacinasModel vacina);
        Task<bool> DeletePostos(int Id);
    }
}
