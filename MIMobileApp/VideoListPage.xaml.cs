using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MIMobileApp.Classes;
using Xamarin.Forms;

namespace MIMobileApp
{
    //Video List Page
    public partial class VideoListPage : ContentPage
    {
        public VideoListPage()
        {
            //Initialize page
            InitializeComponent();
        }

        //On Appearing
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            //Declare connection variables
            HttpClient client = new HttpClient();
            string url = "https://melbourneicewebapi.azurewebsites.net/api/Videos/GetVideos";
            var response = await client.GetAsync(url);

            //Test Get String
            if (response.IsSuccessStatusCode)
            {
                string res = "";
                using (HttpContent content = response.Content)
                {
                    Task<string> result = content.ReadAsStringAsync();
                    res = result.Result;
                    var VideosList = Videos.VideosItems.FromJson(res);
                    VideosListView.ItemsSource = VideosList;
                }
            }
            //Display Connection Error
            else
            {
                await DisplayAlert("Connection Error", "Please Connect to the internet and try again", "Ok");
            }
        }

        //Handle item selection
        void Handle_Tapped(object sender, System.EventArgs e)
        {
            //Set video url and change page to video page
            StackLayout stkClicked = (StackLayout)sender;
            var item = (TapGestureRecognizer)stkClicked.GestureRecognizers[0];
            var VideoURL = item.CommandParameter;
            Application.Current.Properties["VideoURL"] = VideoURL.ToString();
            Navigation.PushAsync(new VideoViewPage());
        }
    }
}

