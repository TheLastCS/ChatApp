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
        public TabbedPage()
        {
            InitializeComponent();
            this.On<Xamarin.Forms.PlatformConfiguration.Android>().SetIsSwipePagingEnabled(true);
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
        }

        public TabbedPage(string email)
        {
            InitializeComponent();
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
            email = email.Trim();
            this.On<Xamarin.Forms.PlatformConfiguration.Android>().SetIsSwipePagingEnabled(true);

        }
    }
}