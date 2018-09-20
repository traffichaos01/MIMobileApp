﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MIMobileApp.Classes;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Acr.UserDialogs;

namespace MIMobileApp.UserMan
{
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();

            var assembly = typeof(SignupPage);
            MILogoImage.Source = ImageSource.FromResource("MIMobileApp.Assets.Images.MelbIceLogo.png", assembly);
        }

        private async Task Submit_ClickedAsync(object sender, EventArgs e)
        {
            if (FirstNameEntry.Text == null || SurnameEntry.Text == null || EmailEntry.Text == null || PasswordEntry.Text == null || ConfirmPasswordEntry.Text == null)
            {
                await DisplayAlert("Warning", "You must fill out all the details above", "Ok");
            }
            else if (FIeldValidationCheck.HasSpecialChars(FirstNameEntry.Text).ToString() == "False" || FIeldValidationCheck.HasSpecialChars(SurnameEntry.Text).ToString() == "False" || FIeldValidationCheck.HasSpecialChars(PasswordEntry.Text).ToString() == "False" || FIeldValidationCheck.HasSpecialChars(ConfirmPasswordEntry.Text).ToString() == "False")
            {
                await DisplayAlert("Warning", "Sign up details must not include special characters, please fill out the details entered again without special characters", "Ok");
            }
            else
            {
                try
                {

                    LoadingLayout.IsVisible = true;
                    LoadingSymbol.IsRunning = true;

                    if (ConfirmPasswordEntry.Text == PasswordEntry.Text)
                    {

                        SignUpUser newUser = new SignUpUser();
                        newUser.strFirstName = FirstNameEntry.Text;
                        newUser.strSurname = SurnameEntry.Text;
                        newUser.strEmail = EmailEntry.Text;
                        newUser.dtDOB = DateOfBirthEntry.Date;
                        newUser.strPassword = PasswordEntry.Text;

                        try
                        {
                            HttpClient client = new HttpClient();
                            string url = "https://melbourneicewebapi.azurewebsites.net/api/UserRequests/Add_User";
                            var uri = new Uri(url);
                            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            var json = JsonConvert.SerializeObject(newUser);
                            var content = new StringContent(json, Encoding.UTF8, "application/json");
                            var response = await client.PostAsync(uri, content);
                            if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                            {
                                LoadingSymbol.IsRunning = false;
                                LoadingLayout.IsVisible = false;
                                string alert = "Welcome " + newUser.strFirstName;
                                await DisplayAlert(alert, "You details have been registered and you are now logged in", "Continue");
                                Application.Current.Properties["User"] = "User";
                                await Application.Current.SavePropertiesAsync();
                                await Navigation.PushModalAsync(new NavigationPage(new HomePage()));
                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                            {
                                LoadingSymbol.IsRunning = false;
                                LoadingLayout.IsVisible = false;
                                await DisplayAlert("Warning", "The Email entered is already associated with an account, if you cannot remember your password for this email, try accessing the 'Forgotten your password' button on the login screen to recover your account", "Ok");
                            }
                            else
                            {
                                LoadingSymbol.IsRunning = false;
                                LoadingLayout.IsVisible = false;
                                await DisplayAlert("Warning", "There was an error establishing a connection with the server, please try again later", "Ok");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            await DisplayAlert("Warning", "Please connect to the internet and try again", "ok");
                        }

                    }
                    else
                    {
                        await DisplayAlert("Warning", "Your passwords do not match", "Ok");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    await DisplayAlert("Warning", "Please connect to the internet and try again", "Ok");
                }
            }
        }
    }
}
