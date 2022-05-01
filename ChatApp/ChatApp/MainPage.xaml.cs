using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ChatApp.ViewModels;
using ChatApp.Helpers;

namespace ChatApp
{
    public partial class MainPage : ContentPage
    {
        Contacts contacts = new Contacts();
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

            this.BindingContext = this;
            this.IsBusy = false;
            this.SignInBtn.Clicked += SignIn_Clicked;
        }
        private async void SignIn_Clicked(object sender, EventArgs e)
        {
            IsBusy = true;

            if(!string.IsNullOrEmpty(EmailEntry.Text) && !string.IsNullOrEmpty(PasswordEntry.Text))
            {
                // search for the the user based on email
                // once email has been found, search is stopped - otherwise display alert
                // if email and password match, user info is saved to current application properties
                // if email and password do not match, display alert

                //for(int i = 0; i < contacts.tempdata.Count; i++) {
                //    if (contacts.Email.Equals(EmailEntry.Text) && contacts.Password.Equals(PasswordEntry.Text))
                //    {
                //    }
                //}
                
                if(EmailEntry.Text == "admin@gmail.com" && PasswordEntry.Text == "admin")
                {
                    Application.Current.Properties["email"] = EmailEntry.Text;
                    Application.Current.Properties["password"] = PasswordEntry.Text;
                    IsBusy = false;

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
