using Projekt.Class;
using Projekt.Models;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projekt.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ustawienia : ContentPage
    {
        public Ustawienia()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();

            UserClassLoad userClass = new UserClassLoad();
            var userx = userClass.GetUser(Convert.ToInt32(Application.Current.Properties["UserId"])).Result;
            //Debug.WriteLine("USERNAME: "+userClass.GetUser(1).Result.username);
            //Debug.WriteLine("LOGINID: " + Convert.ToInt32(Application.Current.Properties["UserId"]));
            Twojanazwa.Text = "Twoja nazwa: " + userx.username;

            buttonAutorzyPage.Clicked += ButtonAutorzyPage_Clicked;
        }

        

        private async void ButtonAutorzyPage_Clicked(object sender, EventArgs e)
        {
            //Application.Current.MainPage = new About();
            //throw new NotImplementedException();
            await Navigation.PushAsync(new About());
        }

        private void ButtonNickname_Clicked(object sender, EventArgs e)
        {
            UserClassLoad userClass = new UserClassLoad();
            //var userx = userClass.GetUser(Convert.ToInt32(Application.Current.Properties["UserId"])).Result;


            if (!string.IsNullOrEmpty(Nickname.Text) && !string.IsNullOrWhiteSpace(Nickname.Text))
            {

                Debug.WriteLine("USERID: " + Convert.ToString(Application.Current.Properties["UserId"]));
                Debug.WriteLine("NEWUSERNAME: " + Nickname.Text);
                UserModel userModel = new UserModel
                {
                    newusername = Nickname.Text,
                    id = Convert.ToString(Application.Current.Properties["UserId"])
                };
                var check = userClass.PostUser(userModel).Result;
                if (Convert.ToInt32(check.code) == 400)
                {
                    DisplayAlert("Alert", "Podana nazwa użytkownika jest już zajęta", "OK");
                }
                else if(Convert.ToInt32(check.code) == 200)
                {
                    DisplayAlert("Alert", "Pomyślnie zmieniłeś swoją nazwę na: " + Nickname.Text, "OK");
                    Twojanazwa.Text = "Twoja nazwa: " + Nickname.Text;
                }
            }
            else
            {
                DisplayAlert("Alert", "Wprowadzone dane są nieprawidłowe", "OK");
            }

        }
    }
}