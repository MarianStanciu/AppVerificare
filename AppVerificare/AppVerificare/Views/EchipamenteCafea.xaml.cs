using AppVerificare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppVerificare.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EchipamenteCafea : ContentPage
    {
        public EchipamenteCafea()
        {
            InitializeComponent();

          
        }

     

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            var cafea = ((MenuItem)sender).BindingContext as Models.Cafea;
            if (cafea == null)
                return;
            DisplayAlert("Cafeaua Favorita", cafea.Nume, "ok");
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var cafea = ((ListView)sender).SelectedItem as Models.Cafea;
            if (cafea == null)
                return;
            DisplayAlert("Cafeaua selectata", cafea.Nume, "ok");
        }
    }
}