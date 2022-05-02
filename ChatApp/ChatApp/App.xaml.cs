using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatApp
{
    public partial class App : Application
    {
        //UI SCALE
        public static float screenWidth { get; set; }
        public static float screenHeight { get; set; }
        public static float appScale { get; set; }

        public static string User = "Rendy";

        public App()
        {
            InitializeComponent();

            bool isLoggedIn = Current.Properties.ContainsKey("isLoggedIn") ? Convert.ToBoolean(Current.Properties["isLoggedIn"]) : false;
            string email = Current.Properties.ContainsKey("email") ? Convert.ToString(Current.Properties["email"]) : null;
            if (!isLoggedIn)
            {
                MainPage = new MainPage();
            }
            else
            {
                MainPage = new TabbedPage(email);
            }
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
