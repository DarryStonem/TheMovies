using System;
using System.Collections.Generic;

namespace TheMovies.Services
{
	public static class MoviesHelper
	{
        public static Dictionary<int, string> MovieGenres = new Dictionary<int, string>
        {
            { 28, "Action" },
            { 12, "Adventure" },
            { 16, "Animation" },
            { 35, "Comedy" },
            { 80, "Crime" },
            { 99, "Documentary" },
            { 18, "Drama" },
            { 10751, "Family" },
            { 14, "Fantasy" },
            { 36, "History" },
            { 27, "Horror" },
            { 10402, "Music" },
            { 9648, "Mystery" },
            { 10749, "Romance" },
            { 878, "Science Fiction" },
            { 10770, "TV Movie" },
            { 53, "Thriller" },
            { 10752, "War" },
            { 37, "Western" }
        };

        /// <summary>
        /// Map a list of IDs with the Movie Genre
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public static List<string> MapMovieGenres(List<int> ids)
        {
            List<string> genres = new List<string>();
            foreach (int genreId in ids)
            {
                if (MovieGenres.ContainsKey(genreId))
                {
                    genres.Add(MovieGenres[genreId]);
                }
            }

            return genres;
        }
    }
}