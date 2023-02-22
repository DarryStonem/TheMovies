using Xamarin.Essentials;
using Xamarin.Forms;

namespace TheMovies.Views
{
	public static class PopupHelper
	{
        public static Size Large => new Size(0.9 * (DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density), 0.95 * (DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density));
    }
}