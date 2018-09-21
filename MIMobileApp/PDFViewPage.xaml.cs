using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MIMobileApp
{
    //PDF View Page
    public partial class PDFViewPage : ContentPage
    {
        public PDFViewPage()
        {
            //Initialize Webview
            InitializeComponent();
            string URL = Application.Current.Properties["PDFURL"].ToString();
            Browser.Source = URL;
        }
    }
}
