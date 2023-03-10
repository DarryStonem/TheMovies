using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using TheMovies.Services;

namespace TheMovies.Models
{
	public class MovieModel
	{
        [JsonProperty("adult")]
        public bool Adult { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty("genre_ids")]
        public List<int> GenreIds { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("video")]
        public bool Video { get; set; }

        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }

        [JsonIgnore]
        public string PosterImage => $"https://image.tmdb.org/t/p/w342{PosterPath}";

        [JsonIgnore]
        public string PosterImageLarge => $"https://image.tmdb.org/t/p/w780{PosterPath}";

        [JsonIgnore]
        public string ReleaseDateShort => DateTime.Parse(ReleaseDate).ToString("MM/dd/yy");

        [JsonIgnore]
        public List<string> Genres => MoviesHelper.MapMovieGenres(GenreIds);

        [JsonIgnore]
        public string GenresString => MoviesHelper.MapMovieGenresToString(GenreIds);
    }
}