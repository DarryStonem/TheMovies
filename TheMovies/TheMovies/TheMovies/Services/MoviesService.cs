using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TheMovies.Models;
using System.Linq;

namespace TheMovies.Services
{
	public class MoviesService : IMoviesService
	{
        private readonly INetworkService _networkService;

        public MoviesService(INetworkService networkService)
		{
            _networkService = networkService;
		}

        #region Public Methods

        /// <summary>
        /// Get the List of Movies
        /// </summary>
        /// <returns>List of Movies</returns>
        public async Task<List<MovieModel>> GetMoviesAsync()
        {
            var url = $"{App.AppConfiguration.ApiBaseUrl}/3/discover/movie?api_key={App.AppConfiguration.ApiKey}&sort_by=popularity.desc";
            var movies = await _networkService.GetApiAsync<MoviesResponseModel>(url, new CancellationToken());

            if (!movies.Results.Any())
            {
                return null;
            }
            else
            {
                return movies.Results;
            }
        }

        /// <summary>
        /// Get the List of Movies
        /// </summary>
        /// <returns>List of Movies</returns>
        public async Task<List<MovieModel>> GetMoviesAsync(string title)
        {
            var url = $"{App.AppConfiguration.ApiBaseUrl}/3/search/movie?api_key={App.AppConfiguration.ApiKey}&sort_by=popularity.desc&language=en-US&include_adult=false&query={title}";
            var movies = await _networkService.GetApiAsync<MoviesResponseModel>(url, new CancellationToken());

            if (!movies.Results.Any())
            {
                return null;
            }
            else
            {
                return movies.Results;
            }
        }

        #endregion
    }
}

