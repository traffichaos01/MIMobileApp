using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MIMobileApp
{
    public partial class PDFViewPage : ContentPage
    {
        public PDFViewPage()
        {
            InitializeComponent();
            string URL = Application.Current.Properties["PDFURL"].ToString();
            Browser.Source = URL;
        }
    }
}
