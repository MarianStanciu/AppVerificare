using AppVerificare.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;



namespace AppVerificare.ViewModels
{
    public class EchipamenteCafeaViewModel : ViewModelBase
    {
        public ObservableRangeCollection <Cafea> Cafea { get; set; }
        public ObservableRangeCollection<Grouping<string,Cafea>> GrupCafea { get; }
        public AsyncCommand RefreshCommand { get; }
       public  EchipamenteCafeaViewModel()
        {
            //IncreaseCount = new Command(OnIncrease);
            //CallServerCommand = new AsyncCommand(CallServer);
            //Cafea = new ObservableRangeCollection<Cafea>();
            Title = " Ecchipament Cafea";

            Cafea = new ObservableRangeCollection<Cafea>();
            GrupCafea = new ObservableRangeCollection<Grouping<string, Cafea>>();

            var image = "https://www.yesplz.coffee/app/uploads/2020/11/emptybag-min.png";

            Cafea.Add(new Cafea { Producator = "Jacobs", Nume = "Alintaroma", Imagine = image });
            Cafea.Add(new Cafea { Producator = "Jacobs", Nume = "Alint", Imagine = image });
            Cafea.Add(new Cafea { Producator = "Elita", Nume = "Neagra", Imagine = image });
            Cafea.Add(new Cafea { Producator = "Elita", Nume = "Rosie", Imagine = image });
            

            GrupCafea.Add(new Grouping<string, Cafea>("Jacobs", new[] { Cafea[1] } ));
            GrupCafea.Add(new Grouping<string, Cafea>("Elita",new []  { Cafea [3]} ));


            RefreshCommand = new AsyncCommand(Refresh);
        }
        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);
            IsBusy = false;

        }
        // de ici in jos este codul de test pentru afisare buton si label cu numaratoare
        //int count = 0;
        //string countDisplay = "Eu numar clickurile";

        //public ICommand CallServerCommand { get; }
        //async Task CallServer()
        //{
        //    var items = new List<string> { "Jacobs", "Lavazza", "Solubila" };
        //    //Cafea.Add("Jacobs"); numai daca adaug un singur element, pentru mai multe folosesc range colecction
        //    //Cafea.Add("Lavazza");
        //    //Cafea.Add("Solubila");
        //    Cafea.AddRange(items); // asa primesc 1 motificare pentru toata lista - se fol pt COLLECTIONVIEW, TABLEVIEWS, LISTVIEWS
        //}

        //public ICommand IncreaseCount { get; }
        ////in loc de toata asta voi folosi Title
        ////bool isBusy;
        ////public bool IsBusy() 
        ////{
        ////    get => isBusy;
        ////    set => SetProperty(ref isBusy, value);
        ////}



        //public string CountDisplay
        //{
        //    get => countDisplay;
        //    set => SetProperty(ref countDisplay, value);
        //    //{                                         // aici in loc sa scriu validarea - fol mvvmhelpers care o are implementata
        //    //    if (value == countDisplay)
        //    //        return;
        //    //    countDisplay = value;
        //    //    OnPropertyChanged();
        //    //}
        //}

        //void OnIncrease()
        //{
        //    count++;
        //    CountDisplay = $"Ai dat clic pe buton de {count}  ori ";
        //}
    }
}
