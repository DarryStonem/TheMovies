using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using Newtonsoft.Json.Linq;
using TheMovies.CustomControls;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TheMovies.CustomControls
{
    public class RatingControl : ContentView
    {
        private readonly List<Image> starImages;

        // Research: If you try to add the following, whenever you add any item
        // to the StackLayout, will only add one of each one.
        // The solution is to create the new Image each time and not adding the readonly.
        // private readonly Image fullStarImage = new Image { Source = ImageSource.FromResource("TheMovies.Resources.Icons.star-rating.png", typeof(RatingControl).GetTypeInfo().Assembly) };
        // private readonly Image halfStarImage = new Image { Source = ImageSource.FromResource("TheMovies.Resources.Icons.star-half.png", typeof(RatingControl).GetTypeInfo().Assembly) };
        // private readonly Image emptyStarImage = new Image { Source = ImageSource.FromResource("TheMovies.Resources.Icons.star-empty.png", typeof(RatingControl).GetTypeInfo().Assembly) };

        public RatingControl()
        {
            var stack = GetMainControl();
            stack.Orientation = StackOrientation.Horizontal;
            stack.Spacing = 10;

            Content = stack;

            PropertyChanged += RatingControl_PropertyChanged;
        }

        private void RatingControl_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(Rating) && Rating != 0)
            {
                var ratingControl = (RatingControl)sender;
                ratingControl.UpdateStars();
            }
        }

        public static readonly BindableProperty RatingProperty =
            BindableProperty.Create(nameof(Rating), typeof(double), typeof(RatingControl), 0.0, BindingMode.TwoWay);

        /// <summary>
        /// Rating 0 to 10
        /// </summary>
        public double Rating
        {
            get => (double)GetValue(RatingProperty);
            set => SetValue(RatingProperty, value);
        }

        /// <summary>
        /// Create a new StackLayout with the measures
        /// </summary>
        /// <returns>A new StackLayout</returns>
        private StackLayout GetMainControl()
        {
            var stack = new StackLayout();
            stack.Orientation = StackOrientation.Horizontal;
            stack.Spacing = 10;
            return stack;
        }

        /// <summary>
        /// Update the stars and the values
        /// </summary>
        private void UpdateStars()
        {
            var stack = GetMainControl();
            double newMinValue = 1;
            double newMaxValue = 5;

            double scaledValue = Rating / 10 * (newMaxValue - newMinValue) + newMinValue;

            double rating = Math.Round(scaledValue * 2, MidpointRounding.AwayFromZero) / 2;

            for (var i = 1; i <= 5; i++)
            {
                if (rating >= i)
                {
                    stack.Children.Add(new Image { Source = ImageSource.FromResource("TheMovies.Resources.Icons.star-rating.png", typeof(RatingControl).GetTypeInfo().Assembly) });
                }
                else if (rating > i - 1)
                {
                    stack.Children.Add(new Image { Source = ImageSource.FromResource("TheMovies.Resources.Icons.star-half.png", typeof(RatingControl).GetTypeInfo().Assembly) });
                }
                else
                {
                    stack.Children.Add(new Image { Source = ImageSource.FromResource("TheMovies.Resources.Icons.star-empty.png", typeof(RatingControl).GetTypeInfo().Assembly) });
                }
            }

            Content = stack;
        }
    }
}

