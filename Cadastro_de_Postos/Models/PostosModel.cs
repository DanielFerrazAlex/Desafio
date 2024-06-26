namespace Cadastro_de_Postos.Models
{
    public class PostosModel
    {
        public int Id { get; set; }
        public string? NomePosto { get; set; }
        public VacinasModel Vacinas { get; set; }
    }
}
