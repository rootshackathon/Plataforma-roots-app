using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapsPage : ContentPage
    {
        /// <summary>
        /// 0-todas as arvores, 1-por espécie
        /// </summary>
        public int TipoPesquisa { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public MapsPage(double latitude, double longitude, double metros, int tipoPesquisa = 0)
        {
            InitializeComponent();

            Latitude = latitude;
            Longitude = longitude;
            TipoPesquisa = tipoPesquisa;

            MapView.MapType = MapType.Hybrid;
            MapView.MyLocationEnabled = true;
            MapView.UiSettings.MyLocationButtonEnabled = true;
            MapView.MapClicked += MapView_MapClicked;
            MapView.PinClicked += MapView_PinClicked;
            MapView.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(latitude, longitude), Distance.FromMeters(metros)));
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            var root = Services.Api.GetArvores();

            if (root == null)
                return;

            foreach (var item in root.data)
            {
                try
                {
                    Pin pin = new Pin
                    {
                        Icon = BitmapDescriptorFactory.DefaultMarker(Color.Green),
                        Position = new Position(item.latitude, item.longitude),
                        Label = item.descricao,
                        Address = item.codigo,
                        Type = PinType.Place
                    };
                    MapView.Pins.Add(pin);
                }
                catch { }
            }
        }
        private async void MapView_PinClicked(object sender, PinClickedEventArgs e)
        {
            await Application.Current.MainPage.DisplayAlert("Roots", $"Espécie: {e.Pin.Label} \nLat: {e.Pin.Position.Latitude} \nLon: {e.Pin.Position.Longitude}", "OK");
        }

        private async void MapView_MapClicked(object sender, MapClickedEventArgs e)
        {
            bool task1 = await Application.Current?.MainPage?.DisplayAlert("Roots", "Cadastrar nova árvore na localização selecionada?.", "SIM", "NÃO");
            if (task1)
                await PopupNavigation.Instance.PushAsync(new CadastroArvorePage(ref MapView, e.Point));
        }
    }
}