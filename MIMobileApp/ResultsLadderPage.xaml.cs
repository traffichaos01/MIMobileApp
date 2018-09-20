using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MIMobileApp.Classes;
using Xamarin.Forms;

namespace MIMobileApp
{
    public partial class ResultsLadderPage : ContentPage
    {
        public ResultsLadderPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            HttpClient client = new HttpClient();
            string urlLadder = "https://melbourneicewebapi.azurewebsites.net/api/Ladders/GetLadders";
            string urlResults = "https://melbourneicewebapi.azurewebsites.net/api/Results/GetResults";
            var responseLadder = await client.GetAsync(urlLadder);
            var responseResults = await client.GetAsync(urlResults);

            if (responseLadder.IsSuccessStatusCode)
            {
                string resLadder = "";
                using (HttpContent contentLadder = responseLadder.Content)
                {
                    Task<string> resultLadder = contentLadder.ReadAsStringAsync();
                    resLadder = resultLadder.Result;
                    var LadderList = Ladder.LadderItems.FromJson(resLadder);
                    LadderListView.ItemsSource = LadderList;
                }
                string resResults = "";
                using (HttpContent contentResults = responseResults.Content)
                {
                    Task<string> resultResults = contentResults.ReadAsStringAsync();
                    resResults = resultResults.Result;
                    var ResultsList = Results.ResultsItems.FromJson(resResults);
                    ResultsListView.ItemsSource = ResultsList;
                }
            }
            else
            {
                await DisplayAlert("Connection Error", "Please Connect to the internet and try again", "Ok");
            }
        }
    }
}
