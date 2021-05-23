using System.Collections.ObjectModel;

namespace App1.ViewModels
{
    public class ArvoreViewModel : BaseViewModel
    {
        public ObservableCollection<Models.Arvore> Itens { get; set; } = new ObservableCollection<Models.Arvore>();

        public ArvoreViewModel()
        {
            var value = Services.Api.GetArvore();

            if (value != null)
                Itens = new ObservableCollection<Models.Arvore>(value.data);
        }
    }
}
