using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheMovies.Models;

namespace TheMovies.Services
{
	public interface IMoviesService
	{
        Task<List<MovieModel>> GetMoviesAsync();
    }
}