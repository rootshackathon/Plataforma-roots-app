using App1.Views;
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

        private bool _IsBusy { get; set; }
        private async void OnLoginClicked(object obj)
        {
            if (_IsBusy)
                return;

            _IsBusy = true;

            bool login = Services.Api.GetLogin(Email, Senha);

            if (!login)
            {
                await App.Current.MainPage.DisplayAlert("Roots", "Usuário ou senha invãlido.", "OK");
            }

            App.Current.MainPage = new NavigationPage(new DashboardPage());

            _IsBusy = false;
        }
    }
}
