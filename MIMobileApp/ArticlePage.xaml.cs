using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MIMobileApp
{
    public partial class ArticlePage : ContentPage
    {
        public ArticlePage()
        {
            InitializeComponent();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            string URL = Application.Current.Properties["ArticleURL"].ToString();
            Browser.Source = URL;
        }
    }

}
