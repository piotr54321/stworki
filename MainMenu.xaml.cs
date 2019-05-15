using Projekt.Class;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projekt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenu : TabbedPage
    {
        public MainMenu(int x)
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);

            InitializeComponent();
            //LocationClass locationClass = new LocationClass();
            CurrentPage = Children[x];
        }
    }
}