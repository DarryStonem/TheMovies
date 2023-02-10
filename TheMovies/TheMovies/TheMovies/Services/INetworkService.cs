using System;
using System.Threading;
using System.Threading.Tasks;

namespace TheMovies.Services
{
	public interface INetworkService
	{
        /// <summary>
        /// GET from REST with HttpClient
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="uri">URL for the Api Call</param>
        /// <param name="token">Cancellation Token</param>
        /// <returns></returns>
        Task<TResult> GetApiAsync<TResult>(string uri, CancellationToken token);
    }
}