using ChatApp.Helpers;
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
    public partial class ChatPage : ContentPage
    {
        

        public ChatPage()
        {
            InitializeComponent();
            Contacts contacts = new Contacts();

            ContactsListView.ItemsSource = contacts.tempdata;
        }

        

        private void SearchEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Contacts contacts = new Contacts();
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                ContactsListView.ItemsSource = contacts.tempdata;
            }

            else
            {
                ContactsListView.ItemsSource = contacts.tempdata.Where(x => x.Username.StartsWith(e.NewTextValue));
            }
        }
    }