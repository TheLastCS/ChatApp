using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ChatApp.ViewModels;

namespace ChatApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel(this);
            NavigationPage.SetHasNavigationBar(this, false);
            EmailEntry.Text = "admin@gmail";
            PasswordEntry.Text = "admin";
            EmailEntry.Focused += (s, a) =>
            {
                EmailFrame.BorderColor = Color.FromHex("#00529C");
            };

            PasswordEntry.Focused += (s, a) =>
            {
                PasswordFrame.BorderColor = Color.FromHex("#00529C");
            };
        }
        private async void SignIn_Clicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(EmailEntry.Text) && !string.IsNullOrEmpty(PasswordEntry.Text))
            {
                if(EmailEntry.Text == "admin@gmail.com" && PasswordEntry.Text == "admin")
                {
                    Application.Current.Properties["email"] = EmailEntry.Text;
                    Application.Current.Properties["password"] = PasswordEntry.Text;
                    await Application.Current.SavePropertiesAsync();
                    Application.Current.MainPage = new TabbedPage(EmailEntry.Text);
                }
                
            } else
            {
                EmailFrame.BorderColor = Color.Red;
                PasswordFrame.BorderColor = Color.Red;

                await DisplayAlert("Error", "Missing Fields. Please Enter Your Login Information.", "OKAY");
                
                EmailEntry.Text = string.Empty;
                PasswordEntry.Text = string.Empty;
                    

                //EmailEntry.Focus();
            }
        }
        private async void Register_Clicked(object sender, EventArgs e)
        {
           await Application.Current.SavePropertiesAsync();
           Application.Current.MainPage = new RegisterPage();
        }

        private void ForgotPassword_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ForgotPasswordPage());
        }

    }
}
