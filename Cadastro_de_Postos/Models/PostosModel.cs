namespace Cadastro_de_Postos.Models
{
    public class PostosModel
    {
        public int Id { get; set; }
        public string? NomePosto { get; set; }
        public List<VacinasModel> Vacinas { get; set; }
    }

    public class VacinasModel
    {
        public int Id { get; set; }
        public int Lote { get; set; }
        public string NomeVacina { get; set; }
        public string Fabricante { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataValidade { get; set; }
    }
}
