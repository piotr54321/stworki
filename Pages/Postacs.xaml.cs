using Projekt.Class;
using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projekt.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Postacs : ContentPage
    {

        public string UserID = Convert.ToString(Application.Current.Properties["UserId"]);
        CreaturesClassLoad creaturesClass = new CreaturesClassLoad();
        //public string CreatureID;
        public Postacs()
        {

            InitializeComponent();

            SetValue(NavigationPage.HasNavigationBarProperty, false);

            
            var UserCreatures = new Creaturesmodel
            {
                users_id = UserID
            };

            List <Creaturesmodel> UserCreaturesList = creaturesClass.GetUserCreatures(UserCreatures).Result;

            Debug.WriteLine("CODE: " + UserCreaturesList[0].code);

            if(UserCreaturesList[0].code == "400")
            {
                //Application.Current.MainPage = new AddCreaturePage();
                this.ChangePage();
            }
            else
            {

                Creaturesmodel creaturesmodels = creaturesClass.GetUserCreatures(new Creaturesmodel { users_id = UserID, current = "1" }).Result[0];
                var creature_id = creaturesmodels.creatures_id;
                CreaturesInfo creaturesInfo = creaturesClass.GetCreature(new CreaturesInfo { id = creature_id }).Result[0];
                //this.CreatureID = creaturesmodels.id;
                //BindingContext = creaturesInfo;
                //var imageSource = creaturesInfo.image;
                imageTest.BindingContext = creaturesInfo;
                statystyki.BindingContext = creaturesmodels;
            }
        }

        private async void ChangePage()
        {
            //await Navigation.PushModalAsync(new AddCreaturePage());
            await DisplayAlert("alert", "test", "ok");
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChooseCreature());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            Creaturesmodel creaturesmodels = creaturesClass.GetUserCreatures(new Creaturesmodel { users_id = UserID, current = "1" }).Result[0];


            var hungryi = Convert.ToInt32(creaturesmodels.hungry);
            if (hungryi >= 10)
            {
                hungryi = hungryi - 5;

                var happyi = Convert.ToInt32(creaturesmodels.happy);
                if (happyi <= 85) happyi = happyi + 5;
                //Console.WriteLine("STWOR ID: " + creaturesmodels.id);

                await creaturesClass.PostCreature(new Creaturesmodel { id = creaturesmodels.id, happy = Convert.ToString(happyi), hungry = Convert.ToString(hungryi) });

                creaturesmodels = creaturesClass.GetUserCreatures(new Creaturesmodel { users_id = UserID, current = "1" }).Result[0];

                statystyki.BindingContext = creaturesmodels;
            }else{

                CreaturesInfo creaturesInfo = creaturesClass.GetCreature(new CreaturesInfo { id = creaturesmodels.creatures_id }).Result[0];
                imageTest.BindingContext = creaturesInfo;
                await DisplayAlert("Uważaj!!!", creaturesInfo.name + " warczy na Ciebie!!", "ok pora na obiadek", ";c");
            }
        }
    }
}