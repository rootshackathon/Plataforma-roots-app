using App1.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EspeciePage : ContentPage
    {
        public EspeciePage()
        {
            InitializeComponent();
            BindingContext = new EspecieViewModel();
        }
        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((CollectionView)sender).SelectedItem = null;
        }

        private bool _IsBusy { get; set; }
        private async void VisualizarNoMapa_Invoked(object sender, EventArgs e)
        {
            if (_IsBusy)
                return;

            _IsBusy = true;

            var value = (Models.Especie)((SwipeItem)sender).CommandParameter;

            var posicao = await Services.Utils.ObterPosicaoAtual();

            if (posicao == null)
                return;

            await Navigation.PushAsync(new MapsPage(posicao.Latitude, posicao.Longitude, 5000), true);

            _IsBusy = false;
        }

    }
}