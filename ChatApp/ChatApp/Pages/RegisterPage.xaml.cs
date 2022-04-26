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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }
        private async void SignIn_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(UsernameEntry.Text) &&  !string.IsNullOrEmpty(EmailEntry.Text) && !string.IsNullOrEmpty(PasswordEntry.Text) && !string.IsNullOrEmpty(ConfirmPasswordEntry.Text))
            {
                if(PasswordEntry.Text == ConfirmPasswordEntry.Text)
                {
                    await DisplayAlert("Success", "Register Successful! Verification email sent.", "OKAY");
                    await Application.Current.SavePropertiesAsync();

                    Application.Current.MainPage = new MainPage();
                }
                
            }
            else
            {
                bool retryBool = await DisplayAlert("Error", "Missing Fields. Please Enter Your Login Information.", "Okay", null);
                if (retryBool)
                {
                    UsernameEntry.Text = string.Empty;
                    EmailEntry.Text = string.Empty;
                    PasswordEntry.Text = string.Empty;
                    ConfirmPasswordEntry.Text = string.Empty;
                    UsernameEntry.Focus();
                }
            }
        }
        private async void Register_Clicked(object sender, EventArgs e)
        {
            await Application.Current.SavePropertiesAsync();

            Application.Current.MainPage = new MainPage();
        }
    }
}