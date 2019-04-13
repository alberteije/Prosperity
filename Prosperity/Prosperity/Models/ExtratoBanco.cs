using SQLite;

namespace Models
{
    public class ExtratoBanco
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string MesAno { get; set; }
        public System.DateTime DataTransacao { get; set; }
        public decimal Valor { get; set; }
        public string IdTransacao { get; set; }
        public string CheckNum { get; set; }
        public string NumeroReferencia { get; set; }
        public string Historico { get; set; }
        public string Conciliado { get; set; }

        // Campos transientes
        public string CorValor { get { return Conciliado == "-" ? "Red" : "Blue"; } }
    }
}