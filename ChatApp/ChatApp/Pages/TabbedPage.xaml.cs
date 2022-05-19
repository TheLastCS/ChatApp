using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;


namespace ChatApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class TabbedPage : Xamarin.Forms.TabbedPage
    {
        DataClass dataClass = DataClass.GetInstance;
        public TabbedPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            profilePage.Email = dataClass.loggedInUser.Email;
            profilePage.Username = dataClass.loggedInUser.Username;
            this.On<Xamarin.Forms.PlatformConfiguration.Android>().SetIsSwipePagingEnabled(true);
        }
        //public TabbedPage(string email)
        //{
        //    InitializeComponent();
        //    Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
        //    profilePage.Email = email;
        //    this.On<Xamarin.Forms.PlatformConfiguration.Android>().SetIsSwipePagingEnabled(true);

        //}
    }
}