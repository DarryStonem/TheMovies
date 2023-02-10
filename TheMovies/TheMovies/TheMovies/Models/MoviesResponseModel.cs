using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace TheMovies.Models
{
	public class MoviesResponseModel
	{
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("results")]
        public List<MovieModel> Results { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("total_results")]
        public int TotalResults { get; set; }
    }
}