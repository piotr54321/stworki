using Projekt.Class;
using Projekt.Models;
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
    public partial class Register : ContentPage
    {
        public Register()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            UserClassLoad userClass = new UserClassLoad();

            if(Password.Text != Passwordrep.Text)
            {
                DisplayAlert("Alert", "Hasło powinno być w obu polach takie samo", "OK");
            }
            else if (string.IsNullOrEmpty(NazwaU.Text) || string.IsNullOrWhiteSpace(NazwaU.Text) || string.IsNullOrEmpty(Password.Text) || string.IsNullOrWhiteSpace(Password.Text) || string.IsNullOrEmpty(Email.Text) || string.IsNullOrWhiteSpace(Email.Text))
            {
                DisplayAlert("Alert", "Nie wszystkie pola zostały wypełnione", "OK");
            }
            else
            {
                PasswordHash passwordHash = new PasswordHash();

                UserModel userModel = new UserModel();
                userModel.username = NazwaU.Text;
                userModel.password = passwordHash.GetHash(Password.Text);
                userModel.email = Email.Text;

                var checkRegister = userClass.PutUser(userModel).Result;
                if(Convert.ToInt32(checkRegister.code) == 200)
                {
                    DisplayAlert("Alert", "Zostałeś zarejestrowany, zaloguj się", "OK");
                    Application.Current.MainPage = new LoginPage();
                }
                else if (Convert.ToInt32(checkRegister.code) == 400)
                {
                    DisplayAlert("Alert", "Nazwa użytkowika lub adres email już istnieje", "OK");
                }
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