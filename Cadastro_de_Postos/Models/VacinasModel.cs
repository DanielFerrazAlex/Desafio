namespace Cadastro_de_Postos.Models
{
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
