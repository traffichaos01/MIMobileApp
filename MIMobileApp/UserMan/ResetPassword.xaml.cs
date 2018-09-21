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
        //Reset Password Page
        public ResetPassword()
        {
            //Initialize page
            InitializeComponent();

            var assembly = typeof(ResetPassword);
            MILogoImage.Source = ImageSource.FromResource("MIMobileApp.Assets.Images.MelbIceLogo.png", assembly);
        }

        //Handle Button Click
        async void Handle_ClickedAsync(object sender, System.EventArgs e)
        {
            //Set Password variables
            string Password = PasswordEntry.Text;
            string ConfirmPassword = ConfirmPasswordEntry.Text;

            //If they dont match tell user
            if (Password != ConfirmPassword)
            {
                await DisplayAlert("Warning", "Passwords do not match, please try again", "Ok");
            }
            else
            {
                //Set Loading Symbol
                LoadingSymbol.IsRunning = true;
                LoadingLayout.IsVisible = true;

                //Set User Object
                UpdatedUser updateUser = new UpdatedUser();
                updateUser.strEmail = Application.Current.Properties["UserEmail"].ToString();
                updateUser.strPassword = Password;

                try
                {
                    //Declare Connection Settings
                    HttpClient client = new HttpClient();
                    string url = "https://melbourneicewebapi.azurewebsites.net/api/UserRequests/Update_User";
                    var uri = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var json = JsonConvert.SerializeObject(updateUser);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(uri, content);
                    //Test POST Request to Server, if accepted, display message and push to news page
                    if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                    {
                        await DisplayAlert("Welcome", "Your password has been reset! Please now try and login with your new password!", "Ok");
                        await Navigation.PushAsync(new MainPage());
                    }
                    //Display Connection Error
                    else
                    {

                        await DisplayAlert("Warning", "Connection with the server has been stopped, please try again later", "Ok");
                        
                    }
                }
                //Handle Exception
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                //Turn off Loading Symbols
                LoadingSymbol.IsRunning = false;
                LoadingLayout.IsVisible = false;
            }
        }
    }
}
