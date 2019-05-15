using Projekt.Class;
using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projekt.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Plecak : ContentPage
    {

        PrzedmiotyClassLoad przedmiotyClassLoad = new PrzedmiotyClassLoad();
        public string UserID = Convert.ToString(Application.Current.Properties["UserId"]);
        public Plecak()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();

            this.Przedmioty();

        }

        public async void Przedmioty()
        {

            List<Plecakmodel> przedmioty = await przedmiotyClassLoad.GetPlecakmodel(new Plecakmodel { user_id = UserID, ilosc = "0"});
            if (przedmioty[0].code == "400")
            {
                bagList.ItemsSource = "";
                iloscPrzedmiotow.Text = "Nic jeszcze nie kupiłeś ;c";
            }else{

                iloscPrzedmiotow.Text = "Ilość przedmiotów" + Convert.ToString(przedmioty.Count());
                bagList.ItemsSource = przedmioty;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var p = sender as Button;
            //Console.WriteLine("RZECZ: " + p.AutomationId);
            //przedmiotyClassLoad.PostPlecakmodel();
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var p = sender as Button;
            //await przedmiotyClassLoad.PostPlecakmodel(new Plecakmodel { user_id = UserID, znak="0", ilosc="1", id_przedmiotu = p.AutomationId});
            Console.WriteLine("PRZEDMI" + p.AutomationId);
            var x = przedmiotyClassLoad.PostPlecakmodel(new Plecakmodel { user_id = UserID, id_przedmiotu = p.AutomationId, ilosc = "1", znak = "0" }).Result;
            await DisplayAlert("Alert", "Poprawnie wyrzucono przedmiot...", "No i fajnie");
            this.Przedmioty();
        }
    }
}