using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AI2raportyMobile
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
            var userNameEntry = new Entry { Placeholder = "login" };
            var passwordEntry = new Entry { Placeholder = "password", IsPassword = true };
            var loginButton = new Button { Text = "Log in" };
            loginButton.Clicked += (sender, e) => { Debug.WriteLine(string.Format("Login: {0} - Hasło: {1}", userNameEntry.Text, passwordEntry.Text)); };
            
        }
	}
}
