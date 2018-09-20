using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MIMobileApp.UserMan
{
    public partial class TokenVerify : ContentPage
    {
        public TokenVerify()
        {
            InitializeComponent();

            var assembly = typeof(TokenVerify);
            MILogoImage.Source = ImageSource.FromResource("MIMobileApp.Assets.Images.MelbIceLogo.png", assembly);
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            string TokenEntered = TokenEntry.Text;
            string Token = Application.Current.Properties["Token"].ToString().Trim(new Char[] { '"' });
            if (TokenEntered == Token)
            {
                DisplayAlert("Welcome Back", "Now enter your new password for your account", "Ok");
                Navigation.PushAsync(new ResetPassword());
            }
            else
            {
                DisplayAlert("Token Mismatch", TokenEntered + " " + Token, "Ok");
            }
        }
    }
}

