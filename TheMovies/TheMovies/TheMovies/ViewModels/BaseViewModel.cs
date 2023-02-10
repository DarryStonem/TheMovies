using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TheMovies.ViewModels
{
	public class BaseViewModel : ExtendedBindableObject
    {
        private bool _isBusy;
        private bool _isNotBusy = true;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                MainThread.InvokeOnMainThreadAsync(() =>
                {
                    if (SetProperty(ref _isBusy, value)) IsNotBusy = !_isBusy;
                });
            }
        }

        public bool IsNotBusy
        {
            get => _isNotBusy;
            set
            {
                if (SetProperty(ref _isNotBusy, value)) IsBusy = !_isNotBusy;
            }
        }

        public BaseViewModel()
		{

		}

        public virtual Task InitializeAsync(object parameter)
        {
            return Task.CompletedTask;
        }
    }

    public abstract class ExtendedBindableObject : BindableObject
    {
        protected bool SetProperty<T>(ref T backingStore, T value,
            Action onChanged = null, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value)) return false;
            backingStore = value;
            onChanged?.Invoke();

            OnPropertyChanged(propertyName);
            return true;
        }
    }
}

