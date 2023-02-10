using System;
using System.Collections.Generic;
using TheMovies.Models;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace TheMovies.Views
{
    public partial class MovieDetailPopup : Popup
    {
        public MovieDetailPopup(MovieModel movie)
        {
            InitializeComponent();
            BindingContext = movie;
        }

        private void BackButtonEvent(Object sender, System.EventArgs e)
        {
            Dismiss(null);
        }
    }
}