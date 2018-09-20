using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MIMobileApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if (Application.Current.Properties.ContainsKey("User"))
            {
                if (Application.Current.Properties["User"].ToString() == "User")
                {
                    MainPage = new NavigationPage(new HomePage());
                }
                else
                {
                    MainPage = new NavigationPage(new MainPage());
                }
            }
            else
            {
                MainPage = new NavigationPage(new MainPage());
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
