using System;
namespace TheMovies.Models
{
    /// <summary>
    /// Configuration Model
    /// This will match with the config.json file
    /// </summary>
	public class Configuration
	{
        public string ApiBaseUrl { get; set; }
        public string ApiKey { get; set; }
    }
}