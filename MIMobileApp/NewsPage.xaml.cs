using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MIMobileApp.Classes;
using Xamarin.Forms;

namespace MIMobileApp
{
    public partial class NewsPage : ContentPage
    {
        public NewsPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            HttpClient client = new HttpClient();
            string url = "https://melbourneicewebapi.azurewebsites.net/api/News_Articles/GetNews_Articles";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string res = "";
                using (HttpContent content = response.Content)
                {
                    Task<string> result = content.ReadAsStringAsync();
                    res = result.Result;
                    var ArticlesList = Articles.ArticlesItems.FromJson(res);
                    GetListView.ItemsSource = ArticlesList;
                }
            }
            else
            {
                await DisplayAlert("Connection Error", "Please Connect to the internet and try again", "Ok");
            }
        }


        void Handle_Tapped(object sender, System.EventArgs e)
        {
            StackLayout stkClicked = (StackLayout)sender;
            var item = (TapGestureRecognizer)stkClicked.GestureRecognizers[0];
            var ArticleURL = item.CommandParameter;
            Application.Current.Properties["ArticleURL"] = ArticleURL.ToString();
            Navigation.PushAsync(new ArticlePage());

        }
    }
}

