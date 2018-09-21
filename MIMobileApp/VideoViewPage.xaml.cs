using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MIMobileApp
{
    public partial class VideoViewPage : ContentPage
    {
        //Video View Page
        public VideoViewPage()
        {
            //Initialize View
            InitializeComponent();
        }

        //On Appearing
        protected override void OnAppearing()
        {
            //Show Video on Webview
            base.OnAppearing();
            string URL = Application.Current.Properties["VideoURL"].ToString();
            Browser.Source = URL;
        }
    }
}
