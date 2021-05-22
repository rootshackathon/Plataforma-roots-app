using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroArvorePage : PopupPage
    {
        public CadastroArvorePage(ref Map mapView, Position point)
        {
            InitializeComponent();
        }
    }
}