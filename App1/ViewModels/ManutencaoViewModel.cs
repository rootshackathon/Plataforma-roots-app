using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class ManutencaoViewModel : BaseViewModel
    {
        public ObservableCollection<Models.Manutencao> Itens { get; set; } = new ObservableCollection<Models.Manutencao>();

        private ObservableCollection<string> tipoManutencao;
        public ObservableCollection<string> TipoManutencao
        {
            get { return tipoManutencao; }
            set
            {
                tipoManutencao = value;
                OnPropertyChanged(nameof(TipoManutencao));
            }
        }
        public Command ManutencaoCommand { get; }
        public ManutencaoViewModel()
        {

            ManutencaoCommand = new Command(OnManutencaoLoad);

            TipoManutencao = new ObservableCollection<string>();
            TipoManutencao.Add("Poda");
            TipoManutencao.Add("Reparo");

            OnManutencaoLoad();
        }

        private void OnManutencaoLoad()
        {
            var value = Services.Api.GetManutencao();

            if (value != null)
                Itens = new ObservableCollection<Models.Manutencao>(value.data);
        }
    }
}
