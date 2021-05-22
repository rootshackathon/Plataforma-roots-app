using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroArvorePage : PopupPage
    {
        private Map MapView { get; set; }
        public Position Point { get; set; }
        public CadastroArvorePage(ref Map mapView, Position point)
        {
            InitializeComponent();
            MapView = mapView;
            Point = point;
        }

        private async void Button_Clicked_1(object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            var roots = Services.Api.PostArvore(
                new Models.Arvore()
                {
                    descricao = EntryDescricao.Text,
                    ponto_referencia = EntryPontoReferencia.Text,
                    latitude = Point.Latitude,
                    longitude = Point.Longitude,
                    codigo_pessoa = "1",
                    codigo_especie = "1",
                    codigo_regiao = "1"
                });

            if (roots)
            {
                Pin pin = new Pin
                {
                    Icon = BitmapDescriptorFactory.DefaultMarker(Color.Green),
                    Position = new Position(Point.Latitude, Point.Longitude),
                    Label = "Roots",
                    Address = EntryDescricao.Text,
                    Type = PinType.Place
                };
                MapView.Pins.Add(pin);
            }

            await PopupNavigation.Instance.PopAsync(true);
        }
    }
}