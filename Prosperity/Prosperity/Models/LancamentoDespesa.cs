using SQLite;

namespace Models
{
    public class LancamentoDespesa
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string MesAno { get; set; }
        public string Codigo { get; set; }
        public System.DateTime DataDespesa { get; set; }
        public string Historico { get; set; }
        public decimal Valor { get; set; }
        public int Situacao { get; set; }

        // Campos transientes
        public string DataDespesaCodigo { get { return DataDespesa + " | " + Codigo; } }
        public string CorValor { get { return Situacao == 0 ? "Blue" : "Red"; } }
        public string DescricaoSituacao { get { return Situacao == 0 ? "Pago" : "A Pagar"; } }
    }

    public class LancamentoDespesaAgrupado
    {
        public string MesAno { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string CodigoDescricao { get { return Codigo + " | " + Descricao; } }
    }

}