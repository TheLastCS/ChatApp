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
        }
        private async void SignIn_Clicked(object sender, EventArgs e)
        {
            await Application.Current.SavePropertiesAsync();

            Application.Current.MainPage = new TabbedPage();
        }
        private async void Register_Clicked(object sender, EventArgs e)
        {
           await Application.Current.SavePropertiesAsync(); 

           Application.Current.MainPage = new RegisterPage();
        }
    }
}
