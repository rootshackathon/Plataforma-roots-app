using System.Collections.Generic;

namespace App1.Models
{
    public class Especie
    {
        public string codigo { get; set; }
        public int sequencia { get; set; }
        public string descricao { get; set; }
        public string nome_cientifico { get; set; }
        public int dias_intervalo_poda { get; set; }
        public int status { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }

    public class RootEspecie
    {
        public int current_page { get; set; }
        public List<Especie> data { get; set; }
        public string first_page_url { get; set; }
        public int from { get; set; }
        public int last_page { get; set; }
        public string last_page_url { get; set; }
        public string next_page_url { get; set; }
        public string path { get; set; }
        public int per_page { get; set; }
        public object prev_page_url { get; set; }
        public int to { get; set; }
        public int total { get; set; }
    }
}
