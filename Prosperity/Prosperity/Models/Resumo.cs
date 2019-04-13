using SQLite;

namespace Models
{
    public class Resumo
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string MesAno { get; set; }
        public string ReceitaDespesa { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal ValorOrcado { get; set; }
        public decimal ValorRealizado { get; set; }
        public decimal Diferenca { get; set; }
    }
}