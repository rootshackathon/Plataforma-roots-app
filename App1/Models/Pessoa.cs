namespace App1.Models
{
    public class Pessoa
    {
        public string codigo { get; set; }
        public int sequencia { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string telefone { get; set; }
        public int status { get; set; }
        public object created_at { get; set; }
        public object updated_at { get; set; }
    }
}