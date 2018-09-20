using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MIMobileApp
{
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {
            InitializeComponent();

            var assembly = typeof(HomePage);
            LogoIcon.Source = ImageSource.FromResource("MIMobileApp.Assets.Images.MelbIceLogo.png", assembly);
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            var answer = await DisplayAlert("Sign Out", "Are you sure you want to sign out?", "Yes", "No");
            if (answer.ToString() == "True")
            {
                Application.Current.Properties["User"] = "NotUser";
                await Application.Current.SavePropertiesAsync();
                await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new MainPage()));
            }
        }
    }
}