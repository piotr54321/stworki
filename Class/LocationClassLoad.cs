using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms;

namespace Projekt.Class
{
    internal class LocationClassLoad
    {
        public Position lastPosition;

        public async Task StartListening()
        {
            if (CrossGeolocator.Current.IsListening)
                return;

            await CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromSeconds(5), 5, true);

            App.Current.Properties.Add("position", 0);
            //App.Current.Properties.Add("position.IsFromMockProvider", 0);

            CrossGeolocator.Current.PositionChanged += PositionChanged;
            CrossGeolocator.Current.PositionError += PositionError;
        }

        public void PositionChanged(object sender, PositionEventArgs e)
        {
            var position = e.Position;
            Console.WriteLine("Pozycja3: ", e.Position.Latitude);
            var jsonString = JsonConvert.SerializeObject(e.Position);
            lastPosition = e.Position;
            App.Current.Properties["position"] = jsonString;
            Console.WriteLine("Pozycja2: " + jsonString);
            //return lastPosition;
        }

        private void PositionError(object sender, PositionErrorEventArgs e)
        {
            Debug.WriteLine(e.Error);
        }

        public async Task StopListening()
        {
            if (!CrossGeolocator.Current.IsListening)
                return;

            await CrossGeolocator.Current.StopListeningAsync();

            CrossGeolocator.Current.PositionChanged -= PositionChanged;
            CrossGeolocator.Current.PositionError -= PositionError;
        }

        public Position ReadLocation()
        {
            var position = JsonConvert.DeserializeObject<Position>(Convert.ToString(Application.Current.Properties["position"]));
            return position;
        }
    }
}