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
            await Application.Current.SavePropertiesAsync();

            Application.Current.MainPage = new MainPage();
        }
        private async void Register_Clicked(object sender, EventArgs e)
        {
            await Application.Current.SavePropertiesAsync();

            Application.Current.MainPage = new MainPage();
        }
    }
}