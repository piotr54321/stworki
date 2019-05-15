using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projekt.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PreLogin : ContentPage
	{
		public PreLogin ()
		{
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //Application.Current.MainPage = new LoginPage();
            await Navigation.PushAsync(new LoginPage());

        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new Register());

            //Application.Current.MainPage = new Register();
            await Navigation.PushAsync(new Register());
        }

        private async void OnBackButtonPressed()
        {
            //Application.Current.MainPage = new PreLogin();
            await Navigation.PopToRootAsync();
            //return true;
        }
    }
}