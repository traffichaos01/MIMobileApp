using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MIMobileApp
{
    //Article Page displays webview for app to load article
    public partial class ArticlePage : ContentPage
    {
        public ArticlePage()
        {
            InitializeComponent();
        }


        protected override void OnAppearing()
        {
            //Declaring source property for webview
            base.OnAppearing();
            string URL = Application.Current.Properties["ArticleURL"].ToString();
            Browser.Source = URL;
        }
    }

}
