using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projekt.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class About : ContentPage
    {
        public About()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();

            //Debug.WriteLine("User Id: " + Application.Current.Properties["UserId"]);
        }

        private async void OnBackButtonPressed()
        {
            //Application.Current.MainPage = new MainMenu(4);
            //return true;
            //
            await Navigation.PopAsync();
        }
    }
}