namespace App1.Models
{
    public class Regiao
    {
        public string codigo { get; set; }
        public int sequencia { get; set; }
        public string descricao { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public int distancia_maxima_raio { get; set; }
        public string ponto_referencia { get; set; }
        public int status { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }
}
