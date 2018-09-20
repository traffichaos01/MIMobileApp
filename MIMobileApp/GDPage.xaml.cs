using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MIMobileApp.Classes;
using Xamarin.Forms;


namespace MIMobileApp
{
    public partial class GDPage : ContentPage
    {
        public GDPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            HttpClient client = new HttpClient();
            string url = "https://melbourneicewebapi.azurewebsites.net/api/Game_Day/GetGame_Day_PDF_Documents";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string res = "";
                using (HttpContent content = response.Content)
                {
                    Task<string> result = content.ReadAsStringAsync();
                    res = result.Result;
                    var GDList = PDFs.PDFItems.FromJson(res);
                    GDListView.ItemsSource = GDList;
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
            var PDFURL = item.CommandParameter;
            Application.Current.Properties["PDFURL"] = PDFURL.ToString();
            Navigation.PushAsync(new PDFViewPage());
        }
    }
}

