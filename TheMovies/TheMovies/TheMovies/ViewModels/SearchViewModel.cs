using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TheMovies.Models;
using TheMovies.Services;
using TheMovies.Views;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace TheMovies.ViewModels
{
	public class SearchViewModel : BaseViewModel
    {
        private readonly IMoviesService _moviesService;
        private readonly ICrashService _crashService;

        public ICommand SearchQueryCommand => new Command<string>(SearchMovieAsync);
        public ICommand MovieDetailsCommand => new Command<MovieModel>(OpenDetails, (movie) => IsNotBusy);

        private ObservableCollection<MovieModel> _moviesCollection;

        public ObservableCollection<MovieModel> MoviesCollection
        {
            get => _moviesCollection;
            set => SetProperty(ref _moviesCollection, value);
        }

        public SearchViewModel(IMoviesService moviesService, ICrashService crashService)
        {
            _moviesService = moviesService;
            _crashService = crashService;
        }

        public override async Task InitializeAsync(object parameter = null)
        {
            await base.InitializeAsync(parameter);
        }

        /// <summary>
        /// Open Details Popup 
        /// </summary>
        /// <param name="movie"></param>
        private void OpenDetails(MovieModel movie)
        {
            var popup = new MovieDetailPopup(movie);
            App.Current.MainPage.Navigation.ShowPopup(popup);
        }

        /// <summary>
        /// Search Movies with the parameter
        /// </summary>
        /// <param name="title"></param>
        private async void SearchMovieAsync(string title)
        {
            IsBusy = true;

            try
            {
                var movies = await _moviesService.GetMoviesAsync(title);

                MoviesCollection = new ObservableCollection<MovieModel>(movies);
            }
            catch (Exception ex)
            {
                _crashService.TrackError(ex, nameof(SearchViewModel));
            }
            finally
            {
                IsBusy = false;
            }

            IsBusy = false;
        }
    }
}

