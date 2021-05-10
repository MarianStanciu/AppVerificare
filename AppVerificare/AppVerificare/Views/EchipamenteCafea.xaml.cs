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

            //  BindingContext = this; // daca setarea este pentru pagina asta
            //BindingContext = new EchipamenteCafeaViewModel();// sau nu pun asta aici si ma duc in view unde trec bindingul
            // folosit in xaml paginii - in view -   x:DataType="viewmodels:EchipamenteCafeaViewModel" - ne ofera BINDING PRECOMPILAT
        }

    }
}