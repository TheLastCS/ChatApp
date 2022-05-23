using Plugin.CloudFirestore;
using System;
using System.Collections.Generic;
using System.Linq;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatApp_Leano_Stewart
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        DataClass dataClass = DataClass.GetInstance;
        public RegisterPage()
        {
            InitializeComponent();
            Activity.IsVisible = false;
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

            BindingContext = this;
            IsBusy = false;
       
        }

        [Obsolete]
        private async void Register_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(UsernameEntry.Text) &&  !string.IsNullOrEmpty(EmailEntry.Text) && !string.IsNullOrEmpty(PasswordEntry.Text) && !string.IsNullOrEmpty(ConfirmPasswordEntry.Text))
            {
                if (PasswordEntry.Text == ConfirmPasswordEntry.Text)
                {
                    Activity.IsVisible = true;
                    FirebaseAuthResponseModel response = new FirebaseAuthResponseModel() { };
                    response = await DependencyService.Get<iFirebaseAuth>().SignUpwithEmailPassword(UsernameEntry.Text, EmailEntry.Text, PasswordEntry.Text);

                    if (response.status)
                    {
                        try
                        {
                            await CrossCloudFirestore.Current
                                .Instance
                                .GetCollection("users")
                                .GetDocument(dataClass.loggedInUser.Id)
                                .SetDataAsync(dataClass.loggedInUser);
                            await DisplayAlert("Success", response.response, "Okay");
                            //await Application.Current.SavePropertiesAsync(); 
                            Application.Current.MainPage = new MainPage();
                        }
                        catch
                        {

                            await DisplayAlert("Error CrossCloudFirestore", response.response, "Okay");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Error responseStatus ", response.response, "Okay");
                    }
                }
                else
                {
                    IsBusy = false;
                    PasswordFrame.BorderColor = Color.Red;
                    ConfirmPasswordFrame.BorderColor = Color.Red;
                    await DisplayAlert("Error", "Password does not match.", "OKAY");
                    PasswordEntry.Text = string.Empty;
                    ConfirmPasswordEntry.Text = string.Empty;
                    PasswordEntry.Focus();
                    Activity.IsVisible = false;
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
                Activity.IsVisible = false;
            }
        }
        private async void SignIn_Clicked(object sender, EventArgs e)
        {
            await Application.Current.SavePropertiesAsync();
           
            Application.Current.MainPage = new MainPage();
        }
    }
}