using System;
using System.Threading;
using System.Threading.Tasks;

namespace TheMovies.Services
{
	public interface INetworkService
	{
        Task<TResult> GetApiAsync<TResult>(string uri, CancellationToken token);
    }
}