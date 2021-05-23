using App1.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArvorePage : ContentPage
    {
        public ArvorePage()
        {
            InitializeComponent();
            BindingContext = new ArvoreViewModel();
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

            var value = (Models.Arvore)((SwipeItem)sender).CommandParameter;

            await Navigation.PushAsync(new MapsPage(value.latitude, value.longitude, 5000), true);

            _IsBusy = false;
        }
    }
}