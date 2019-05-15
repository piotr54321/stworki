using Projekt.Class;
using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projekt.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCreaturePage : ContentPage
    {
        public string UserID = Convert.ToString(Application.Current.Properties["UserId"]);

        public AddCreaturePage()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
            CreaturesClassLoad creaturesClassLoad = new CreaturesClassLoad();
            var items = creaturesClassLoad.GetCreature(new CreaturesInfo { code = "200" }).Result;
            //Debug.WriteLine("ITEM0: " + items[0].name);
            CreatureslistView.ItemsSource = items;

            CreatureslistView.ItemTapped += (sender, e) => {
                var xd = e.Item as CreaturesInfo;
                //System.Diagnostics.Debug.WriteLine(xd.name);
                this.CreatureAlert(xd);
            };
        }

        private async void CreatureAlert(CreaturesInfo creatures)
        {
            bool x = await DisplayAlert("Alert", "Czy na pewno chcesz wybrać stworka: " + creatures.name + "?", "Tak", "Anuluj");
            //Debug.WriteLine("Akcja: " + x);
            if (x)
            {
                UserClassLoad userClassLoad = new UserClassLoad();
                var username = userClassLoad.GetUser(Convert.ToInt32(UserID)).Result.username;

                CreaturesClassLoad creaturesClassLoad = new CreaturesClassLoad();
                var result = creaturesClassLoad.PutCreature(new Creaturesmodel { users_id = UserID, creatures_id = creatures.id, name = username});

                App.Current.MainPage = new NavigationPage(new MainMenu(2));
            }
        }

        private async void OnBackButtonPress()
        {
            await DisplayAlert("Alert", "Musisz wybrać swoją postać", "OK");
        }
    }
}