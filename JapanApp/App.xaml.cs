using System;
using Xamarin.Forms;

namespace JapanApp
{
    public partial class App : Application
    {
        public static string BackendUrl = "https://localhost:5000";

        public App()
        {
            InitializeComponent();

            Settings.LoadSettings();

            DependencyService.Register<MockDataStore>();

            if (Device.RuntimePlatform == Device.iOS)
                MainPage = new MainPage();
            else
                MainPage = new NavigationPage(new MainPage());
        }
    }
}
