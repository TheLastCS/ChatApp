using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatApp_Leano_Stewart
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
                FirebaseAuthResponseModel response = new FirebaseAuthResponseModel() { };
                response = await DependencyService.Get<iFirebaseAuth>().ResetPassword(EmailEntry.Text);

                if (response.status)
                {
                    await DisplayAlert("Sucess", response.response, "Okay");
                    await Navigation.PopModalAsync();
                }
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