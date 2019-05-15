using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Projekt.Class;
using System;
using Projekt.Models;
using System.Collections.Generic;

namespace Projekt.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Sklep : ContentPage
    {
        public string UserID = Convert.ToString(Application.Current.Properties["UserId"]);
        readonly UserClassLoad pUser = new UserClassLoad();
        public Sklep()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();

            PrzedmiotyClassLoad przedmiotyClassLoad = new PrzedmiotyClassLoad();
            List<Przedmiotymodel> przedmiotySklep = przedmiotyClassLoad.GetPrzedmiotymodel(new Przedmiotymodel { }).Result;
            //Console.WriteLine("CENA 1: " + przedmiotySklep[0].cena);
            iloscMonet.Text = "Forsa: " + UserCoins(UserID);
            shopListView.ItemsSource = przedmiotySklep;
            shopListView.ItemTapped += (sender, e) => {
                var przedmiot = e.Item as Przedmiotymodel;
                //SysShoptem.Diagnostics.Debug.WriteLine(xd.name);
                this.ShopAlert(przedmiot);
            };
        }

        private async void ShopAlert(Przedmiotymodel przedmiotymodel)
        {

            if (UserCoins(UserID) < Convert.ToInt32(przedmiotymodel.cena))
            {
                await DisplayAlert("Alert", "Nie możesz kupić przedmiotu: " + przedmiotymodel.nazwa + " ponieważ nie posiadasz wystarczających środków", "Ok");
            }
            else
            {

                bool x = await DisplayAlert("Alert", "Czy na pewno chcesz kupić przedmiot: " + przedmiotymodel.nazwa + "?", "Tak", "Anuluj");
                //Debug.WriteLine("Akcja: " + x);
                if (x)
                {
                    UserClassLoad userClassLoad = new UserClassLoad();
                    //var username = userClassLoad.GetUser(Convert.ToInt32(UserID)).Result.username;
                    PrzedmiotyClassLoad przedmiotyClassLoad = new PrzedmiotyClassLoad();
                    CheckStatus check = przedmiotyClassLoad.PostPlecakmodel(new Plecakmodel { user_id=UserID, id_przedmiotu = (przedmiotymodel.id_przedmiotu), ilosc="1" , znak="1"}).Result;
                    if(check.code == "200")
                    {
                        await DisplayAlert("Alert", "Pomyślnie kupiłeś przedmiot: " + przedmiotymodel.nazwa + ", przejdź do postaci, lub plecaka by go użyć ;)", "Tak", "Anuluj");
                    }
                    else
                    {
                        await DisplayAlert("Alert", "Błąd przy zakupie przedmiotu: " + przedmiotymodel.nazwa + "...", "Tak", "Anuluj");
                    }

                    App.Current.MainPage = new NavigationPage(new MainMenu(2));
                }
            }
        }

        public int UserCoins(string UserID)
        {
            return Convert.ToInt32(pUser.GetUser(Convert.ToInt32(UserID)).Result.coins);
        }
    }
}