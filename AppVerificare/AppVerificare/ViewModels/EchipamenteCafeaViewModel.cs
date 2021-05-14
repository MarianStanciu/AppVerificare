using AppVerificare.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin;
using Xamarin.Forms;
using System.Linq;
using MvvmHelpers.Commands;
using Command = MvvmHelpers.Commands.Command;


namespace AppVerificare.ViewModels
{
    public class EchipamenteCafeaViewModel : ViewModelBase
    {
        public ObservableRangeCollection <Cafea> Cafea { get; set; }
        public ObservableRangeCollection<Grouping<string,Cafea>> GrupCafea { get; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand<object> SelectedCommand { get; }
        public AsyncCommand<Cafea> FavoriteCommand { get; }
        public Command ClearCommand { get; }
        public Command DelayLoadMoreCommand { get; }
        public Command LoadMoreCommand { get; }

        public  EchipamenteCafeaViewModel()
        {
            Title = " Ecchipament Cafea";

            Cafea = new ObservableRangeCollection<Cafea>();
            GrupCafea = new ObservableRangeCollection<Grouping<string, Cafea>>();

            
            LoadMore();

            RefreshCommand = new AsyncCommand(Refresh);
            SelectedCommand = new AsyncCommand<object>(Selected);
            FavoriteCommand = new AsyncCommand<Cafea>(Favorite);
            ClearCommand = new Command(Clear);
            DelayLoadMoreCommand = new Command(DelayLoadMore);
            LoadMoreCommand = new Command(LoadMore);
        }
        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);
            IsBusy = false;

        }
        async Task Favorite(Cafea cafea)
        {
            if (cafea == null)
                return;

            await Application.Current.MainPage.DisplayAlert("Favorite", cafea.Nume, "OK");

        }
        Cafea previouslySelected;
        Cafea cafeaSelectata;
        public Cafea CafeaSelectata
        {
            get => cafeaSelectata;
            set => SetProperty(ref cafeaSelectata, value);
        }
        async Task Selected(object args)
        {
            var cafea = args as Cafea;
            if (cafea == null)
                return;

            CafeaSelectata = null;

            await Application.Current.MainPage.DisplayAlert("Selected", cafea.Nume, "OK");

        }
        void LoadMore()
        {
            if (Cafea.Count >= 20)
                return;

          
            var image = "https://www.yesplz.coffee/app/uploads/2020/11/emptybag-min.png";

            Cafea.Add(new Cafea { Producator = "Jacobs", Nume = "Alintaroma", Imagine = image });
            Cafea.Add(new Cafea { Producator = "Jacobs", Nume = "Alint", Imagine = image });
            Cafea.Add(new Cafea { Producator = "Elita", Nume = "Neagra", Imagine = image });
            Cafea.Add(new Cafea { Producator = "Elita", Nume = "Rosie", Imagine = image });
            GrupCafea.Clear();

            GrupCafea.Add(new Grouping<string, Cafea>("Jacobs", Cafea.Where(c => c.Producator == "Jacobs")));
            GrupCafea.Add(new Grouping<string, Cafea>("Elita", Cafea.Where(c => c.Producator == "Elita")));
        }
        void DelayLoadMore()
        {
            if (Cafea.Count <= 10)
                return;

            LoadMore();
        }

        void Clear()
        {
            Cafea.Clear();
            GrupCafea.Clear();
        }

    }
}
