using App1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();
            BindingContext = new DashboardViewModel();
        }

        private bool _IsBusy { get; set; }
        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_IsBusy)
                return;

            _IsBusy = true;

            Models.Menu current = ((SelectableItemsView)sender).SelectedItem as Models.Menu;

            ((CollectionView)sender).SelectedItem = null;

            switch (current.Id)
            {
                case 1:
                    var posicao = await Services.Utils.ObterPosicaoAtual();

                    if (posicao == null)
                        return;

                    await Navigation.PushAsync(new MapsPage(posicao.Latitude, posicao.Longitude, 5000), true);
                    break;
                case 3:
                    await Navigation.PushAsync(new ArvorePage());
                    break;
                case 4:
                    await Navigation.PushAsync(new EspeciePage());
                    break;
                case 2:
                    await Navigation.PushAsync(new ManutencaoPage());
                    break;
            }

            _IsBusy = false;
        }
    }
}