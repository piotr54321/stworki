using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projekt.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Nointernet : ContentPage
    {
        public Nointernet()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
        }
    }
}