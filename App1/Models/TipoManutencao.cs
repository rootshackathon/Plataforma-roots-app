namespace App1.Models
{
    public class TipoManutencao
    {
        public string codigo { get; set; }
        public int sequencia { get; set; }
        public string descricao { get; set; }
        public int status { get; set; }
        public object created_at { get; set; }
        public object updated_at { get; set; }
    }
}
