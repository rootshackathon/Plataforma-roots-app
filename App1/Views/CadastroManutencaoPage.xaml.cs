using App1.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroManutencaoPage : ContentPage
    {
        public string IdArvore { get; set; }
        public CadastroManutencaoPage(string idArvore)
        {
            InitializeComponent();
            BindingContext = new ManutencaoViewModel();
            IdArvore = idArvore;
        }
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EntryDescricao.Text))
            {
                await DisplayAlert("Root", "Informe a Descrição", "OK");
                return;
            }

            if (string.IsNullOrEmpty(DropDownTipoManutencao.Text))
            {
                await DisplayAlert("Root", "Informe o Tipo Manutenção", "OK");
                return;
            }

            string tipoManutencao = DropDownTipoManutencao.Text == "Poda" ? "1" : "2";
            var rest = Services.Api.PostManutencao(new Models.Manutencao() { descricao = EntryDescricao.Text, data = DateTime.Now.ToString("yyyy/MM/dd"), codigo_arvore = IdArvore, status_manutencao = 1, observacao = EntryObservacao.Text, codigo_pessoa = "1", codigo_tipo_manutencao = tipoManutencao, });

            await Navigation.PopModalAsync();
        }
    }
}