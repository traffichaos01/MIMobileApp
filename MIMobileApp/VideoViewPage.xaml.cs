using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MIMobileApp
{
    public partial class VideoViewPage : ContentPage
    {
        public VideoViewPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            string URL = Application.Current.Properties["VideoURL"].ToString();
            Browser.Source = URL;
        }
    }
}
