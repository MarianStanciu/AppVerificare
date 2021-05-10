using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppVerificare.ViewModels
{
    public class EchipamenteCafeaViewModel : BindableObject
    {
       public  EchipamenteCafeaViewModel()
        {
            IncreaseCount = new Command(OnIncrease);
        }

        int count = 0;
        string countDisplay = "Eu numar clickurile";

        public ICommand IncreaseCount { get; }

        public string CountDisplay
        {
            get => countDisplay;
            set
            {
                if (value == countDisplay)
                    return;
                countDisplay = value;
                OnPropertyChanged();
            }
        }

        void OnIncrease()
        {
            count++;
            CountDisplay = $"Ai dat clic pe buton de {count}  ori ";
        }
    }
}
