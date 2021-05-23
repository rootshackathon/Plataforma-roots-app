using System.Collections.Generic;

namespace App1.Models
{
    public class Manutencao
    {
        public string codigo { get; set; }
        public int sequencia { get; set; }
        public string descricao { get; set; }
        public string data { get; set; }
        public string observacao { get; set; }
        public int status_manutencao { get; set; }
        public int status { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string codigo_pessoa { get; set; }
        public string codigo_pessoa_manutencao { get; set; }
        public string codigo_tipo_manutencao { get; set; }
        public string codigo_arvore { get; set; }
        public TipoManutencao tipo_manutencao { get; set; }
        public Arvore arvore { get; set; }
    }

    public class RootManutencao
    {
        public int current_page { get; set; }
        public List<Manutencao> data { get; set; }
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
