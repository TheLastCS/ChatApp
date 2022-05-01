using ChatApp.Helpers;
using ChatApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<UserModel> allContactList = new ObservableCollection<UserModel>()
        {
            new UserModel()
            {
                Id = 1,
                Username = "Jomar M. Leano",
                Email = "jomarLeano@gmail.com",
                Password = "jomar"
            },
            new UserModel()
            {
                Id = 2,
                Username = "Christian Stewart",
                Email = "christianStewart@gmail.com",
                Password = "christian",
            }
        };

        //Temporary
        //private ObservableCollection<UserModel> ContactList;
        //public ObservableCollection<UserModel> getContacts
        //{
        //    get { return ContactList; }
        //    set { ContactList = value; }
        //}

        public ChatPage()
        {
            InitializeComponent();
            this.BindingContext = this;
            if (allContactList is null)
            {
                Console.WriteLine("Null list");
                ContactLabel.IsVisible = true;
                ContactsListView.IsVisible = false;
            }
            else
            {
                ContactLabel.IsVisible = false;
                ContactsListView.IsVisible = true;
            }
            ViewContactList();
        }

        private void ViewContactList()
        {
            ContactsListView.ItemsSource = allContactList;
        }

        private void SearchEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
            if (!string.IsNullOrEmpty(searchBar.Text))
            {
                SearchedListView.ItemsSource = allContactList.Where(u => u.Email.ToLower().Contains(SearchEntry.Text.ToLower())).ToList();
                ContactLabel.IsVisible = false;
                ContactsListView.IsVisible = false;
                SearchedListView.IsVisible = true;
            }
            else
            {
                if(allContactList.Count <= 0)
                {
                    ContactLabel.IsVisible = true;
                    SearchedListView.IsVisible = false;
                }
                else
                {
                    ContactLabel.IsVisible = false;
                    ContactsListView.IsVisible = true;
                    SearchedListView.IsVisible = false;
                }
            }
            
        }

     

    }
}