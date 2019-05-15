using Projekt.Class;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Projekt.Models;
using System.Collections.Generic;

namespace Projekt.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mapa : ContentPage
    {
        private ObservableCollection<Pin> _pinCollection = new ObservableCollection<Pin>();
        public ObservableCollection<Pin> PinCollection { get { return _pinCollection; } set { _pinCollection = value; OnPropertyChanged(); } }
        public string UserID = Convert.ToString(Application.Current.Properties["UserId"]);
        private UserClassLoad userClass = new UserClassLoad();
        //private readonly UserModel userx;

        public Mapa()
        {

            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
            //LocationClassLoad locationClass = new LocationClassLoad();
            //var position = await Plugin.Geolocator.CrossGeolocator.Current.GetPositionAsync();
            //this.userx = userClass.GetUser(Convert.ToInt32(Application.Current.Properties["UserId"])).Result;
            Console.WriteLine("OTWORZ POZYCJĘ");
            this.Pozycja();
            this.ListenForFight();

            //Plugin.Geolocator.Abstractions.Position positionJson = locationClass.ReadLocation();
            //Console.WriteLine("POZYCJA: " + positionJson.Longitude);
            
           
        }

        public async void Pozycja()
        {
            /*System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;*/
            Console.WriteLine("A:A:A");
            var locator = Plugin.Geolocator.CrossGeolocator.Current;

            while (true)
            {
                var position = await locator.GetPositionAsync();
                Console.WriteLine("POZYCJA :: " + Convert.ToDouble(position.Latitude));
                await userClass.PostUser(new UserModel { id = UserID, latitude = Convert.ToString(position.Latitude), longitude = Convert.ToString(position.Longitude), online = "1" });
                

                List<UserModel> nearUsers = userClass.GetNearUsers(Convert.ToInt32(UserID)).Result;
                PinCollection.Clear();
                foreach (var item in nearUsers)
                {
                    var pin = new Pin() { Position = new Position(Convert.ToDouble(item.latitude), Convert.ToDouble(item.longitude)), Type = PinType.Place, Label = "Pozycja " + item.username };
                    pin.Clicked += Pin_Clicked;
                    pin.BindingContext = item;
                    PinCollection.Add(pin);
                }
                widokMapy.BindingContext = new { MyPositions = new Position(position.Latitude, position.Longitude), PinCollections = PinCollection };
                await Task.Delay(1000);
            }
        }

        async void Pin_Clicked(object sender, EventArgs e)
        {
            var p = sender as Pin;
            var x = p.BindingContext as UserModel;
            var xd = await DisplayAlert("No to co?", "Walka?!", "No walka!", "Nie ;c");
            if (xd)
            {
                if(x.id == UserID)
                {
                    await DisplayAlert("Naprawdę?", "Z samym sobą nie możesz walczyć!", "Ok");
                }
            }
        }

        async void ListenForFight()
        {

            var m15 = 60 * 15; //15 minut
            ServerTime serverTime = new ServerTime();
            while (true)
            {
                var user1 = await userClass.GetUser(Convert.ToInt32(UserID));
                var user2 = await userClass.GetUser(Convert.ToInt32(user1.fightid));
                if(user1.fighttime == user2.fighttime)
                {
                    await Navigation.PushAsync(new FightPage());
                }
                var userFightTime = Convert.ToInt32(user1.fighttime);
                var czasserwera = await serverTime.GetServerTime();
                if(czasserwera < userFightTime + m15)
                {
                    var czywalczymy = await DisplayAlert("Ktoś chce się z Tobą bić", "Walczysz? Czy nie?", "Hahaha", "Nie bo przegram...");
                    if (czywalczymy)
                    {
                        await userClass.PostUser(new UserModel { id = UserID, fighttime = Convert.ToString(czasserwera)});
                        await userClass.PostUser(new UserModel { id = user1.fightid , fighttime = Convert.ToString(czasserwera) });
                        await Navigation.PushAsync(new FightPage());
                    }
                }

                await Task.Delay(5000);
            }
        }
    }
}