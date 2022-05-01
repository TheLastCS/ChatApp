using ChatApp.Helpers;
using ChatApp.Models;
using ChatApp.Pages;
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
        ObservableCollection<UserModel> friendContactList = new ObservableCollection<UserModel>();
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
            //this.BindingContext = this;
            
            ViewContactList();
            ContactsListView.ItemTapped += async (object sender, ItemTappedEventArgs e) =>
            {
                var user = (UserModel)e.Item;
                var userChat = new ConvoPage();
                userChat.BindingContext = user;
                await Navigation.PushModalAsync(userChat);
            };
            SearchedListView.ItemTapped += async (object sender, ItemTappedEventArgs e) =>
            {
                var user = (UserModel)e.Item;
                UserModel userModel = friendContactList.FirstOrDefault(u => u.Id.Equals(user.Id));
                if (userModel is null)
                {
                    friendContactList.Add(allContactList.FirstOrDefault(u => u.Id.Equals(user.Id)));
                    await DisplayAlert("Sucess", "Added user to contacts", "Confirm");
                }
                else
                {
                    await DisplayAlert("Error", "User already in contacts", "Confirm");
                }
            };


        }

        private void ViewContactList()
        {
           ContactsListView.ItemsSource = friendContactList;
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