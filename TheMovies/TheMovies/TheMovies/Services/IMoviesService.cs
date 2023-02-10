using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheMovies.Models;

namespace TheMovies.Services
{
	public interface IMoviesService
	{
        /// <summary>
        /// Get the List of Movies
        /// </summary>
        /// <returns>List of Movies</returns>
        Task<List<MovieModel>> GetMoviesAsync();
    }
}