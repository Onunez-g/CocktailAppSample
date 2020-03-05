using CocktailApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CocktailApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new CocktailPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
