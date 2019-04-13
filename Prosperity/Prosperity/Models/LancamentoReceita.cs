using SQLite;

namespace Models
{
    public class LancamentoReceita
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string MesAno { get; set; }
        public string Codigo { get; set; }
        public System.DateTime DataReceita { get; set; }
        public string Historico { get; set; }
        public decimal Valor { get; set; }
        public int Situacao { get; set; }

        // Campos transientes
        public string DataReceitaCodigo { get { return DataReceita + " | " + Codigo; } }
        public string CorValor { get { return Situacao == 0 ? "Blue" : "Green"; } }
        public string DescricaoSituacao { get { return Situacao == 0 ? "Recebido" : "A Receber"; } }
    }

    public class LancamentoReceitaAgrupado
    {
        public string MesAno { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string CodigoDescricao { get { return Codigo + " | " + Descricao; } }
    }

}