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
	public partial class ChooseCreature : ContentPage
	{
        public string UserID = Convert.ToString(Application.Current.Properties["UserId"]);

        public ChooseCreature ()
		{
			InitializeComponent ();
		}
	}
}