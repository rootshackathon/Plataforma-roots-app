using App1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManutencaoPage : ContentPage
    {
        ManutencaoViewModel vm;
        public ManutencaoPage()
        {
            InitializeComponent();
            BindingContext = vm = new ManutencaoViewModel();

            var toolbar = new ToolbarItem();
            toolbar.Text = "Novo";
            toolbar.Order = ToolbarItemOrder.Primary;
            toolbar.Clicked += Toolbar_Clicked;
            this.ToolbarItems.Add(toolbar);
        }
        private async void Toolbar_Clicked(object sender, System.EventArgs e)
        {
            var posicao = await Services.Utils.ObterPosicaoAtual();

            if (posicao == null)
                return;

            await Navigation.PushAsync(new MapsManutencaoPage(posicao.Latitude, posicao.Longitude, 1000), true);

            vm.ManutencaoCommand.Execute(null);
        }

        private bool _IsBusy { get; set; }
        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_IsBusy)
                return;

            _IsBusy = true;

            ((CollectionView)sender).SelectedItem = null;

            _IsBusy = false;
        }

        private async void VisualizarNoMapa_Invoked(object sender, System.EventArgs e)
        {
            if (_IsBusy)
                return;

            _IsBusy = true;

            var value = (Models.Manutencao)((SwipeItem)sender).CommandParameter;

            var arvore = Services.Api.GetArvore(value.codigo_arvore);

            if (arvore == null)
            {
                _IsBusy = false;
                return;
            }

            await Navigation.PushAsync(new MapsPage(arvore.latitude, arvore.longitude, 5), true);

            _IsBusy = false;
        }
    }
}