using System.Collections.Generic;

namespace App1.Models
{
    public class Arvore
    {
        public string codigo { get; set; }
        public int sequencia { get; set; }
        public string descricao { get; set; }
        public object foto { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string ponto_referencia { get; set; }
        public int status { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string codigo_pessoa { get; set; }
        public string codigo_especie { get; set; }
        public string codigo_regiao { get; set; }
        public Pessoa pessoa { get; set; }
        public Especie especie { get; set; }
        public Regiao regiao { get; set; }
    }

    public class RootArvore
    {
        public int current_page { get; set; }
        public List<Arvore> data { get; set; }
        public string first_page_url { get; set; }
        public int? from { get; set; }
        public int last_page { get; set; }
        public string last_page_url { get; set; }
        public object next_page_url { get; set; }
        public string path { get; set; }
        public int per_page { get; set; }
        public object prev_page_url { get; set; }
        public int? to { get; set; }
        public int total { get; set; }
    }
}
