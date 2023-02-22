using System;
namespace TheMovies.Services
{
	public interface ICrashService
	{
		void TrackError(Exception ex, string viewModel);
	}
}