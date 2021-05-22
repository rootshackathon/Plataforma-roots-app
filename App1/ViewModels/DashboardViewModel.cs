using App1.Models;
using System.Collections.ObjectModel;

namespace App1.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        public ObservableCollection<Menu> Menu { get; set; }

        public DashboardViewModel()
        {
            Menu = new ObservableCollection<Menu>();
            Menu.Add(new Menu() { Id = 4, Title = "Espécie", Image = "icon_especie.svg" });
            Menu.Add(new Menu() { Id = 3, Title = "Árvore", Image = "icon_arvore.svg" });
            Menu.Add(new Menu() { Id = 1, Title = "Monitor", Image = "icon_monitor.svg" });
            Menu.Add(new Menu() { Id = 2, Title = "Manutenção", Image = "icon_manutencao.svg" });

        }
    }
}
