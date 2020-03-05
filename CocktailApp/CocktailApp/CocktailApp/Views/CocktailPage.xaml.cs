﻿using CocktailApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CocktailApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CocktailPage : ContentPage
    {
        public CocktailPage()
        {
            InitializeComponent();
            BindingContext = new CocktailViewModel();
        }
    }
}