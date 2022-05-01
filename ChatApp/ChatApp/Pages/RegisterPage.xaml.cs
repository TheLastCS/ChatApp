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

            UsernameEntry.Text = "admin";
            EmailEntry.Text = "admin@gmail.com";
            PasswordEntry.Text = "admin";
            ConfirmPasswordEntry.Text = "admin";

            EmailEntry.Focused += (s, a) =>
            {
                UsernameFrame.BorderColor = Color.FromHex("#00529C");
            };
            EmailEntry.Focused += (s, a) =>
            {
                EmailFrame.BorderColor = Color.FromHex("#00529C");
            };

            PasswordEntry.Focused += (s, a) =>
            {
                PasswordFrame.BorderColor = Color.FromHex("#00529C");
            };

            ConfirmPasswordEntry.Focused += (s, a) =>
            {
                ConfirmPasswordFrame.BorderColor = Color.FromHex("#00529C");
            };

            this.BindingContext = this;
            this.IsBusy = false;
            this.SignInBtn.Clicked += SignIn_Clicked;
        }
        private async void Register_Clicked(object sender, EventArgs e)
        {
            IsBusy = true;
            
            if (!string.IsNullOrEmpty(UsernameEntry.Text) &&  !string.IsNullOrEmpty(EmailEntry.Text) && !string.IsNullOrEmpty(PasswordEntry.Text) && !string.IsNullOrEmpty(ConfirmPasswordEntry.Text))
            {
                if(PasswordEntry.Text == ConfirmPasswordEntry.Text)
                {
                    IsBusy = false;
                    await DisplayAlert("Success", "Register Successful! Verification email sent.", "OKAY");

                    await Application.Current.SavePropertiesAsync();
                    Application.Current.MainPage = new MainPage();
                } else
                {
                    IsBusy = false;

                    PasswordFrame.BorderColor = Color.Red;
                    ConfirmPasswordFrame.BorderColor = Color.Red;

                    await DisplayAlert("Error", "Password does not match.", "OKAY");

                    PasswordEntry.Text = string.Empty;
                    ConfirmPasswordEntry.Text = string.Empty;

                }
                
            }
            else
            {
                IsBusy = false;

                UsernameFrame.BorderColor = Color.Red;
                EmailFrame.BorderColor = Color.Red;
                PasswordFrame.BorderColor = Color.Red;
                ConfirmPasswordFrame.BorderColor = Color.Red;

                await DisplayAlert("Error", "Missing Fields. Please Enter Your Information.", "OKAY");
                
                UsernameEntry.Text = string.Empty;
                EmailEntry.Text = string.Empty;
                PasswordEntry.Text = string.Empty;
                ConfirmPasswordEntry.Text = string.Empty;

                //UsernameEntry.Focus();
            }
        }
        private async void SignIn_Clicked(object sender, EventArgs e)
        {
            await Application.Current.SavePropertiesAsync();
           
            Application.Current.MainPage = new MainPage();
        }
    }
}