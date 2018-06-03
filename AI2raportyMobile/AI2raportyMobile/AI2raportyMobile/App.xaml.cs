using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace AI2raportyMobile
{
	public partial class App : Application
	{
		public App ()
		{
            
            //MainPage = new ContentPage { Content = new StackLayout { VerticalOptions = LayoutOptions.Center, Children = { Content } } };
            MainPage = new ListViewPage1();
            
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
