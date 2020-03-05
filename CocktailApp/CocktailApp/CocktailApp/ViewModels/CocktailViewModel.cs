using CocktailApp.Models;
using CocktailApp.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CocktailApp.ViewModels
{
    public class CocktailViewModel : INotifyPropertyChanged
    {
        const string ErrorConnection = "Connection error";
        const string ErrorMessage = "Please check you have internet connection";
        const string ApiURL = "https://www.thecocktaildb.com/api/json/v1/1";
        const string SelectedColor = "#FADC9C";
        const string DefaultColor = "#DEDAD1";
        readonly ICocktailServices _cocktailServices = new CocktailServices();
        readonly NetworkAccess networkAccess = Connectivity.NetworkAccess;
        public IEnumerable<string> Glasses { get; set; }
        public ObservableCollection<Drink> Drinks { get; set; } = new ObservableCollection<Drink>();
        public string CocktailGlass { get; set; } = "Cocktail glass";
        public ICommand GetDrinksWithAPICommand { get; set; }
        public ICommand GetDrinksWithRefitCommand { get; set; }
        public bool IsApiService { get; set; }
        public bool IsRefitService { get; set; }
        public string ApiColor { get; set; } = DefaultColor;
        public string RefitColor { get; set; } = DefaultColor;
        public CocktailViewModel()
        {
            GetGlasses();
            GetDrinksWithAPICommand = new Command(async () =>
            {
                if (networkAccess == NetworkAccess.Internet)
                    Drinks = new ObservableCollection<Drink>(await _cocktailServices.GetDrinksByCocktailGlass(CocktailGlass));
                else
                    await App.Current.MainPage.DisplayAlert(ErrorConnection, ErrorMessage, "Cancel");
                IsApiService = true;
                IsRefitService = false;
                ApiColor = SelectedColor;
                RefitColor = DefaultColor;
            });
            GetDrinksWithRefitCommand = new Command(async () =>
            {
                if (networkAccess == NetworkAccess.Internet)
                    GetDrinksWithRefit();
                else
                    await App.Current.MainPage.DisplayAlert(ErrorConnection, ErrorMessage, "Cancel");
                
                IsApiService = false;
                IsRefitService = true;
                ApiColor = DefaultColor;
                RefitColor = SelectedColor;
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        async void GetGlasses()
        {
            if (networkAccess == NetworkAccess.Internet)
            {
                var glasses = await _cocktailServices.GetGlasses();
                Glasses = glasses.Select(x => x.StrGlass).ToList();
            }
            else
                await App.Current.MainPage.DisplayAlert(ErrorConnection, ErrorMessage, "Cancel");
        }
        async void GetDrinksWithRefit()
        {
            var apiResponse = RestService.For<ICocktailRefitServices>(ApiURL);
            var drinks = await apiResponse.GetDrinksByGlassAsync(CocktailGlass);
            Drinks = new ObservableCollection<Drink>(drinks.Drinks);
        }
    }
}
