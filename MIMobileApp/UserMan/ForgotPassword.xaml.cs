using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace MIMobileApp.UserMan
{
    public partial class ForgotPassword : ContentPage
    {
        public ForgotPassword()
        {
            InitializeComponent();
            var assembly = typeof(ForgotPassword);
            MILogoImage.Source = ImageSource.FromResource("MIMobileApp.Assets.Images.MelbIceLogo.png", assembly);
        }



        async void Handle_ClickedAsync(object sender, System.EventArgs e)
        {
            if (EmailEntry.Text == null)
            {
                await DisplayAlert("Warning", "An email address must be entered", "Ok");
            }
            else
            {
                LoadingSymbol.IsRunning = true;
                LoadingLayout.IsVisible = true;
                try
                {
                    string strEmail = EmailEntry.Text;

                    HttpClient client = new HttpClient();
                    string url = "https://melbourneicewebapi.azurewebsites.net/api/UserRequests/EmailAsync?strEmail=" + strEmail;

                    var response = await client.GetAsync(url);
                    if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                    {
                        string Token = await response.Content.ReadAsStringAsync();
                        Application.Current.Properties["Token"] = Token;
                        Application.Current.Properties["UserEmail"] = strEmail;
                        await Application.Current.SavePropertiesAsync();
                        await DisplayAlert("Welcome", "An email has been sent to you containing a token which you must enter in order to continue the Account Recovery", "Ok");
                        await Navigation.PushAsync(new TokenVerify());
                    }
                    else
                    {
                        await DisplayAlert("Warning", "The email entered doesn't match our records, please try again", "Ok");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    await DisplayAlert("Warning", "Connection to the server is not currently available, please try again later", "Ok");
                }
                LoadingSymbol.IsRunning = false;
                LoadingLayout.IsVisible = false;
            }
        }
    }
}