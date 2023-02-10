using System;
using System.IO;
using System.Reflection;
using Autofac;
using Newtonsoft.Json;
using TheMovies.Models;
using TheMovies.ViewModels;
using TheMovies.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheMovies
{
    public partial class App : Application
    {
        public static IContainer Container { get; private set; }

        public static Configuration AppConfiguration;

        public App ()
        {
            InitializeComponent();

            var builder = new ContainerBuilder();
            var dataAccess = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(dataAccess)
                .AsImplementedInterfaces()
                .AsSelf();

            Container = builder.Build();

            GetAppSettings();

            PreLoadViewModels(Container);

            MainPage = new HomeView();
        }

        /// <summary>
        /// PreLoad the ViewModels
        /// </summary>
        /// <param name="container"></param>
        private void PreLoadViewModels(IContainer container)
        {
            HomeViewModel = container.Resolve<HomeViewModel>();
        }

        private void GetAppSettings()
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            using (var stream = assembly.GetManifestResourceStream("TheMovies.config.json"))
            {
                using (var reader = new StreamReader(stream))
                {
                    var configJson = reader.ReadToEnd();
                    AppConfiguration = JsonConvert.DeserializeObject<Configuration>(configJson);
                }
            }
        }

        public static HomeViewModel HomeViewModel { get; private set; }
    }
}

