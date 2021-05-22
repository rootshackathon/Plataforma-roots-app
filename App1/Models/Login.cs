namespace App1.Models
{
    public class Login
    {
        public int codigo { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string codigo_pessoa { get; set; }
        public string codigo_tipo_usuario { get; set; }
        public Pessoa pessoa { get; set; }
        public TipoUsuario tipo_usuario { get; set; }
    }

    public class RootLogin
    {
        public bool status { get; set; }
        public Login body { get; set; }
        public string mensagem { get; set; }
    }
}
