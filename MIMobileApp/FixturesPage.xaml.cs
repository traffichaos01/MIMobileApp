using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MIMobileApp.Classes;
using Xamarin.Forms;


namespace MIMobileApp
{
    //Displays Fixtures Page
    public partial class FixturesPage : ContentPage
    {
        public FixturesPage()
        {
            //Initializes Page
            InitializeComponent();
        }

        //When Appearing
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            //Declare Connection Variables
            HttpClient client = new HttpClient();
            string url = "https://melbourneicewebapi.azurewebsites.net/api/Fixtures/GetFixtures";
            var response = await client.GetAsync(url);

            //Test Get String to determine and set the itemsource for list view
            if (response.IsSuccessStatusCode)
            {
                string res = "";
                using (HttpContent content = response.Content)
                {
                    Task<string> result = content.ReadAsStringAsync();
                    res = result.Result;
                    var FixturesList = Fixtures.FixturesItems.FromJson(res);
                    FixturesListView.ItemsSource = FixturesList;
                }
            }
            //Displays connection alert
            else
            {
                await DisplayAlert("Connection Error", "Please Connect to the internet and try again", "Ok");
            }
        }
    }
}

