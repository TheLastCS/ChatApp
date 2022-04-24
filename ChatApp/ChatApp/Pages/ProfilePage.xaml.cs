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
    public partial class ProfilePage : ContentPage
    {
        public static readonly BindableProperty NameProperty = BindableProperty.Create(nameof(Name), typeof(string), typeof(ProfilePage), "");
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public static readonly BindableProperty EmailProperty = BindableProperty.Create(nameof(Email), typeof(string), typeof(ProfilePage), "");
        public string Email
        {
            get { return (string)GetValue(EmailProperty); }
            set { SetValue(EmailProperty, value); }
        }
        public ProfilePage()
        {
            InitializeComponent();
        }
        private async void SignOutBtn_Clicked(object sender, EventArgs e)
        {
            Application.Current.Properties.Clear();
            await Application.Current.SavePropertiesAsync();

            Application.Current.MainPage = new MainPage();
        }
    }
}