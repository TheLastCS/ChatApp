using System;
using System.Collections.Generic;
using System.Text;
using ChatApp_Leano_Stewart.Models;
using ChatApp_Leano_Stewart.Helpers;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace ChatApp_Leano_Stewart.ViewModels
{
    public class MainPageViewModel
    {
        public LoginModel LoginModel { get; set; } = new LoginModel();
        public System.Windows.Input.ICommand LoginCommand { get; }
        private readonly Page _page;
        public MainPageViewModel(Page page)
        {
            _page = page;
            LoginCommand = new Command(async () => await LoginAsync());
        }

        private async Task LoginAsync()
        {
            if (!ValidationHelper.IsFormValid(LoginModel, _page)) { return; }
            
        }
    }
}
