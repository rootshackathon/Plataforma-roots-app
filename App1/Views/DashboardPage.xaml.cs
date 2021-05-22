using App1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();
            BindingContext = new DashboardViewModel();
        }

        private bool _IsBusy { get; set; }
        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}