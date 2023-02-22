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
	public class HomeViewModel : BaseViewModel
    {
        private readonly IMoviesService _moviesService;
        private readonly ICrashService _crashService;

        private ObservableCollection<Grouping<string, MovieModel>> _moviesCollection;

        public ObservableCollection<Grouping<string, MovieModel>> MoviesCollection
        {
            get => _moviesCollection;
            set => SetProperty(ref _moviesCollection, value);
        }

        public HomeViewModel(IMoviesService moviesService, ICrashService crashService)
		{
			_moviesService = moviesService;
            _crashService = crashService;
		}

        public ICommand MovieDetailsCommand => new Command<MovieModel>(OpenDetails, (movie) => IsNotBusy);

        public ICommand RefreshCommand => new Command(() => GetMovies());

        public ICommand NavigateToSearchCommand => new Command(() => App.Current.MainPage.Navigation.PushAsync(new SearchPage()));

        public override async Task InitializeAsync(object parameter = null)
        {
            await base.InitializeAsync(parameter);

            GetMovies();
        }

        #region Private Methods

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
        /// Get Movies async
        /// </summary>
        private async void GetMovies()
        {
            IsBusy = true;
            try
            {
                var movies = await _moviesService.GetMoviesAsync();

                var groupedMovies = from movie in movies
                                    group movie by movie.Genres.FirstOrDefault() into g
                                    orderby g.Key
                                    select new Grouping<string, MovieModel>(g.Key, g);

                MoviesCollection = new ObservableCollection<Grouping<string, MovieModel>>(groupedMovies);
            }
            catch (Exception ex)
            {
                // Handle the Exception
                _crashService.TrackError(ex, nameof(HomeViewModel));
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion
    }
}