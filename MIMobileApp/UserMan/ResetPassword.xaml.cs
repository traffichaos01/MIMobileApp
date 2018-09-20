using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using MIMobileApp.Classes;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MIMobileApp.UserMan
{
    public partial class ResetPassword : ContentPage
    {
        public ResetPassword()
        {
            InitializeComponent();

            var assembly = typeof(ResetPassword);
            MILogoImage.Source = ImageSource.FromResource("MIMobileApp.Assets.Images.MelbIceLogo.png", assembly);
        }

        async void Handle_ClickedAsync(object sender, System.EventArgs e)
        {
            string Password = PasswordEntry.Text;
            string ConfirmPassword = ConfirmPasswordEntry.Text;

            if (Password != ConfirmPassword)
            {
                await DisplayAlert("Warning", "Passwords do not match, please try again", "Ok");
            }
            else
            {
                LoadingSymbol.IsRunning = true;
                LoadingLayout.IsVisible = true;

                UpdatedUser updateUser = new UpdatedUser();
                updateUser.strEmail = Application.Current.Properties["UserEmail"].ToString();
                updateUser.strPassword = Password;

                try
                {
                    HttpClient client = new HttpClient();
                    string url = "https://melbourneicewebapi.azurewebsites.net/api/UserRequests/Update_User";
                    var uri = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var json = JsonConvert.SerializeObject(updateUser);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(uri, content);
                    if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                    {
                        await DisplayAlert("Welcome", "Your password has been reset! Please now try and login with your new password!", "Ok");
                        await Navigation.PushAsync(new MainPage());
                    }
                    else
                    {
                        await DisplayAlert("Warning", "Connection with the server has been stopped, please try again later", "Ok");
                        //"Your email seems to already be in use, try using a different email, or retrieve the password for your other account associated with that email address.  "
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                LoadingSymbol.IsRunning = false;
                LoadingLayout.IsVisible = false;
            }
        }
    }
}
