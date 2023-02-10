using System;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TheMovies.Services
{
	public class NetworkService : INetworkService
	{
        /// <summary>
        /// GET from REST with HttpClient
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="uri">URL for the Api Call</param>
        /// <param name="token">Cancellation Token</param>
        /// <returns></returns>
        public async Task<TResult> GetApiAsync<TResult>(string uri, CancellationToken token = new CancellationToken())
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(uri, token);

            // Throw error if not success
            response.EnsureSuccessStatusCode();

            var serialized = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<TResult>(serialized ?? string.Empty);
            return result;
        }
    }
}