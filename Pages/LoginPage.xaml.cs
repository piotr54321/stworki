using System;
using System.Diagnostics;
using System.Security.Cryptography;
using Projekt.Api;
using Projekt.Class;
using Projekt.Models;
using Refit;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projekt.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();

            //LocationClassLoad locationClass = new LocationClassLoad();
            
            //locationClass.StartListening();
        }

        private void OnLoginButtonClicked(object sender, EventArgs e)
        {
            
            LoginClassLoad pLogin = new LoginClassLoad();
            //UserClass pUser = new UserClass();
            
            var CheckPass = pLogin.CheckPass(UsernameEntry.Text, PasswordEntry.Text).Result;
            if(Convert.ToInt32(CheckPass.code) == 200)
            {
                Debug.WriteLine("Zalogowano: " + UsernameEntry.Text + " " + PasswordEntry.Text);

                UserClassLoad userClassLoad = new UserClassLoad();
                userClassLoad.PostUser(new UserModel { id = CheckPass.id, online="1"});
                Application.Current.Properties["UserId"] = Convert.ToInt32(CheckPass.id);

                //Application.Current.MainPage = new MainMenu(2);

                CreaturesClassLoad creaturesClassLoad = new CreaturesClassLoad();
                if(creaturesClassLoad.GetUserCreatures(new Creaturesmodel { users_id = CheckPass.id}).Result[0].code == "400")
                {
                    //Debug.WriteLine("USRID: " + creaturesClassLoad.GetUserCreatures(new Creaturesmodel { users_id = CheckPass.id }).Result[0].code);
                    Application.Current.MainPage = new NavigationPage(new AddCreaturePage());
                }
                else
                {
                    Application.Current.MainPage = new NavigationPage(new MainMenu(2));
                }


            }
            else if(Convert.ToInt32(CheckPass.code) == 400)
            {
                DisplayAlert("Alert", "Wprowadzona nazwa użytkownika lub hasło są niepoprawne", "OK");
            }
                        
        }

        private async void OnBackButtonPressed()
        {
            //Application.Current.MainPage = new PreLogin();
            //return true;
            await Navigation.PopAsync();
        }
    }
}