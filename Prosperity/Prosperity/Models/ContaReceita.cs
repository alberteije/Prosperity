using SQLite;

namespace Models
{
    public class ContaReceita
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }

        // Campos transientes
        public string CodigoDescricao { get { return Codigo + " | " + Descricao; } }
    }
}