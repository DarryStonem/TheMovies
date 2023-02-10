using System;
using System.Collections.Generic;
using Autofac;
using TheMovies.ViewModels;
using Xamarin.Forms;

namespace TheMovies.Views
{
    public partial class HomeView : ContentPage
    {
        public HomeView()
        {
            InitializeComponent();

            var viewModelLocator = App.Container;
            var homeViewModel = viewModelLocator.Resolve<HomeViewModel>();
            BindingContext = homeViewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await (BindingContext as HomeViewModel).InitializeAsync();
        }
    }
}