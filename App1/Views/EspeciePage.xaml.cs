using App1.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EspeciePage : ContentPage
    {
        public EspeciePage()
        {
            InitializeComponent();
            BindingContext = new EspecieViewModel();
        }
        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((CollectionView)sender).SelectedItem = null;
        }

        private void VisualizarNoMapa_Invoked(object sender, EventArgs e)
        {

        }

    }
}