using System;
using System.Collections.Generic;
using Autofac;
using TheMovies.ViewModels;
using Xamarin.Forms;

namespace TheMovies.Views
{	
	public partial class SearchPage : ContentPage
	{	
		public SearchPage ()
		{
			InitializeComponent ();
            var viewModelLocator = App.Container;
            var searchViewModel = viewModelLocator.Resolve<SearchViewModel>();
            BindingContext = searchViewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await (BindingContext as SearchViewModel).InitializeAsync();
        }
    }
}

