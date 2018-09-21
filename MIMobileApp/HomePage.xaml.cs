using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MIMobileApp
{
    //Homepage where login occurs
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {
            //Initialize page and load images
            InitializeComponent();
            var assembly = typeof(HomePage);
            LogoIcon.Source = ImageSource.FromResource("MIMobileApp.Assets.Images.MelbIceLogo.png", assembly);
        }

        //Handle Click Event
        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            //Ask user if they want to sign out
            var answer = await DisplayAlert("Sign Out", "Are you sure you want to sign out?", "Yes", "No");
            if (answer.ToString() == "True")
            {
                //Application setings declared and page change
                Application.Current.Properties["User"] = "NotUser";
                await Application.Current.SavePropertiesAsync();
                await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new MainPage()));
            }
        }
    }
}