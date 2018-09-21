using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MIMobileApp.Classes;
using Xamarin.Forms;


namespace MIMobileApp
{
    //Player Page
    public partial class PlayerPage : ContentPage
    {
        public PlayerPage()
        {
            //Initialize Page
            InitializeComponent();
        }

        //When Appearing
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            //Declare Connection Variables
            HttpClient client = new HttpClient();
            string urlGoals = "https://melbourneicewebapi.azurewebsites.net/api/Player_Info/GetPlayer_Info?playerInfo=goals";
            string urlPoints = "https://melbourneicewebapi.azurewebsites.net/api/Player_Info/GetPlayer_Info?playerInfo=points";
            var responseGoals = await client.GetAsync(urlGoals);
            var responsePoints = await client.GetAsync(urlPoints);

            //Test Get Strings and set itemsources to appropriate listviews
            if (responsePoints.IsSuccessStatusCode)
            {
                string resGoals = "";
                using (HttpContent contentGoals = responseGoals.Content)
                {
                    Task<string> resultGoals = contentGoals.ReadAsStringAsync();
                    resGoals = resultGoals.Result;
                    var GoalsList = Players.PlayersItems.FromJson(resGoals);
                    GoalListView.ItemsSource = GoalsList;
                }
                string resPoints = "";
                using (HttpContent contentPoints = responsePoints.Content)
                {
                    Task<string> resultPoints = contentPoints.ReadAsStringAsync();
                    resPoints = resultPoints.Result;
                    var PointsList = Players.PlayersItems.FromJson(resPoints);
                    PointListView.ItemsSource = PointsList;
                }
            }
            //Display Connection Error
            else
            {
                await DisplayAlert("Connection Error", "Please Connect to the internet and try again", "Ok");
            }
        }
    }
}