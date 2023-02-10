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

        private ObservableCollection<Grouping<string, MovieModel>> _moviesCollection;

        public ObservableCollection<Grouping<string, MovieModel>> MoviesCollection
        {
            get => _moviesCollection;
            set => SetProperty(ref _moviesCollection, value);
        }

        public HomeViewModel(IMoviesService moviesService)
		{
			_moviesService = moviesService;
		}

        public ICommand MovieDetailsCommand => new Xamarin.Forms.Command<MovieModel>(OpenDetails, (movie) => IsNotBusy);

        public ICommand RefreshCommand => new Command(() => GetMovies());

        private void OpenDetails(MovieModel movie)
        {
            var popup = new MovieDetailPopup(movie);
            App.Current.MainPage.Navigation.ShowPopup(popup);
        }

        public override async Task InitializeAsync(object parameter = null)
        {
            await base.InitializeAsync(parameter);

            GetMovies();
        }

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

            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}