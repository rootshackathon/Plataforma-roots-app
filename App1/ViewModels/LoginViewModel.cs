using Xamarin.Forms;

namespace App1.ViewModels
{
    public class LoginViewModel
    {
        public Command LoginCommand { get; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public LoginViewModel()
        {
            Email = "admin@roots.com";
            Senha = "123456";

            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            //ir para o dashboard
        }
    }
}
