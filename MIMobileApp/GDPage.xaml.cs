using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MIMobileApp.Classes;
using Xamarin.Forms;


namespace MIMobileApp
{
    //Displays Gameday PDFs
    public partial class GDPage : ContentPage
    {
        public GDPage()
        {
            //Initialize Page
            InitializeComponent();
        }

        //When page has appeared
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            //Declare connection variables
            HttpClient client = new HttpClient();
            string url = "https://melbourneicewebapi.azurewebsites.net/api/Game_Day/GetGame_Day_PDF_Documents";
            var response = await client.GetAsync(url);

            //Test Get String to determine and set the itemsource for list view
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

            //Display Connection error
            else
            {
                await DisplayAlert("Connection Error", "Please Connect to the internet and try again", "Ok");
            }
        }

        //Handle Tap Event
        void Handle_Tapped(object sender, System.EventArgs e)
        {
            //Send User to PDF selected
            StackLayout stkClicked = (StackLayout)sender;
            var item = (TapGestureRecognizer)stkClicked.GestureRecognizers[0];
            var PDFURL = item.CommandParameter;
            Application.Current.Properties["PDFURL"] = PDFURL.ToString();
            Navigation.PushAsync(new PDFViewPage());
        }
    }
}

