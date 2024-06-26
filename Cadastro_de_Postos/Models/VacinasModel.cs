namespace Cadastro_de_Postos.Models
{
    public class VacinasModel
    {
        public int Lote { get; set; }
        public string? Nome_Vacina { get; set; }
        public string? Fabricante { get; set; }
        public int Quantidade { get; set; }
        public DateTime Data_Validade { get; set; }
    }
}
