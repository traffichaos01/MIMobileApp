using MIMobileApp.Classes;
using MIMobileApp.UserMan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Acr.UserDialogs;

namespace MIMobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            var assembly = typeof(MainPage);
            MILogoImage.Source = ImageSource.FromResource("MIMobileApp.Assets.Images.MelbIceLogo.png", assembly);
        }

        private async void LoginSubmit_Clicked(object sender, EventArgs e)
        {
            if (EmailEntry.Text == null || PasswordEntry.Text == null)
            {
                await DisplayAlert("Warning", "An email and password must be entered in order to continue", "Ok");
            }
            else
            {
                try
                {
                    //Show Loading Symbol
                    UserDialogs.Instance.ShowLoading("Processing");

                    //Declare Login Object
                    LoginUser currentUser = new LoginUser();
                    currentUser.strEmail = EmailEntry.Text.Trim();


                    currentUser.strPassword = PasswordEntry.Text.Trim();

                    //Establish connection with database and check whether the the login matches
                    HttpClient client = new HttpClient();
                    string url = "https://melbourneicewebapi.azurewebsites.net/api/UserRequests/Check_Login";
                    var uri = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var json = JsonConvert.SerializeObject(currentUser);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(uri, content);
                    if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                    {
                        Application.Current.Properties["User"] = "User";
                        await Application.Current.SavePropertiesAsync();
                        UserDialogs.Instance.HideLoading();
                        await DisplayAlert("Welcome", "Welcome User", "Ok");
                        await Navigation.PushModalAsync(new NavigationPage(new HomePage()));

                    }
                    else
                    {
                        UserDialogs.Instance.HideLoading();
                        await DisplayAlert("Warning", "The Email and Password entered do not match, please try again", "Ok");
                    }
                }
                catch (Exception ex)
                {
                    UserDialogs.Instance.HideLoading();
                    Console.WriteLine(ex);
                    await DisplayAlert("Connection Error", "Please try connect to the internet and try again", "Ok");
                }
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ForgotPassword());
        }

        private void SignupButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignupPage());
        }


    }
}
