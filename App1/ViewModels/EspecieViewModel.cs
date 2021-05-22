using System.Collections.ObjectModel;

namespace App1.ViewModels
{
    public class EspecieViewModel
    {
        public ObservableCollection<Models.Especie> Itens { get; set; } = new ObservableCollection<Models.Especie>();

        public EspecieViewModel()
        {
            var value = Services.Api.GetEspecies();

            if (value == null)
                return;

            Itens = new ObservableCollection<Models.Especie>(value.data);
        }
    }
}
