using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MIMobileApp.UserMan
{
    public partial class TokenVerify : ContentPage
    {
        //Token Verify Page
        public TokenVerify()
        {
            //Initialize Page
            InitializeComponent();

            var assembly = typeof(TokenVerify);
            MILogoImage.Source = ImageSource.FromResource("MIMobileApp.Assets.Images.MelbIceLogo.png", assembly);
        }

        //Handle Button Click
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            //Declare Token Variables
            string TokenEntered = TokenEntry.Text;
            string Token = Application.Current.Properties["Token"].ToString().Trim(new Char[] { '"' });
            //Check if tokens match
            if (TokenEntered == Token)
            {
                //Push user to password reset page
                DisplayAlert("Welcome Back", "Now enter your new password for your account", "Ok");
                Navigation.PushAsync(new ResetPassword());
            }
            else
            {
                //Display Token Mismatch error
                DisplayAlert("Token Mismatch", "The token you have entered is wrong, please try again", "Ok");
            }
        }
    }
}

