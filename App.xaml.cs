using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Projekt.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Projekt
{
    public partial class App : Application
    {
        

        public App()
        {
            //StartListening();
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
            if (CheckInternetConnection() == false)
                MainPage = new Nointernet();
            else
            {
                //MainPage = new PreLogin();
                MainPage = new NavigationPage(new PreLogin());
                //NavigationPage.SetHasNavigationBar(this, false);
            }
        }



        private bool CheckInternetConnection()
        {
            var CheckUrl = "https://gielda.ga";
            try
            {
                var iNetRequest = (HttpWebRequest) WebRequest.Create(CheckUrl);

                iNetRequest.Timeout = 5000;

                var iNetResponse = iNetRequest.GetResponse();

                // Console.WriteLine ("...connection established..." + iNetRequest.ToString ());
                iNetResponse.Close();

                return true;
            }
            catch (WebException)
            {
                // Console.WriteLine (".....no connection..." + ex.ToString ());

                return false;
            }
        }
    }
}