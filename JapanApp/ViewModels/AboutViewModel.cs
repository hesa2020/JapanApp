using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace JapanApp
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://paypal.me/HesaOfficial")));
        }
        public ICommand OpenWebCommand { get; }
    }
}
