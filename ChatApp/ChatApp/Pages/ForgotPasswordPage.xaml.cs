using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPasswordPage : ContentPage
    {
        public ForgotPasswordPage()
        {
            InitializeComponent();

            EmailEntry.Focused += (s, a) =>
            {
                EmailFrame.BorderColor = Color.FromHex("#00529C");
            };
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private async void ResetPassword_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(EmailEntry.Text))
            {
                await DisplayAlert("Success", "Email has been sent to your Email Address.", "OKAY");
                Application.Current.MainPage = new MainPage();

            }
            else
            {
                EmailFrame.BorderColor = Color.Red;

                await DisplayAlert("Error", "Missing Field. Please Enter Your Email.", "OKAY");

                EmailEntry.Text = string.Empty;


                //EmailEntry.Focus();
            }
        }
    }
}