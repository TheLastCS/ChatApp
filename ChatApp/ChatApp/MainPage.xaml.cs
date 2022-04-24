using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChatApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
            EmailEntry.Text = "admin@gmail.com";
            PasswordEntry.Text = "admin";
        }
        private async void SignIn_Clicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(EmailEntry.Text) && !string.IsNullOrEmpty(PasswordEntry.Text))
            {
                Application.Current.Properties["email"] = EmailEntry.Text;
                Application.Current.Properties["password"] = PasswordEntry.Text;
                await Application.Current.SavePropertiesAsync();

                Application.Current.MainPage = new TabbedPage(EmailEntry.Text);
            } else
            {
                bool retryBool = await DisplayAlert("Error", "Missing Fields. Please Enter Your Login Information.", "Okay", null);
                if (retryBool)
                {
                    EmailEntry.Text = string.Empty;
                    PasswordEntry.Text = string.Empty;
                    EmailEntry.Focus();
                }
            }
            
        }
        private async void Register_Clicked(object sender, EventArgs e)
        {
           await Application.Current.SavePropertiesAsync(); 

           Application.Current.MainPage = new RegisterPage();
        }
    }
}
