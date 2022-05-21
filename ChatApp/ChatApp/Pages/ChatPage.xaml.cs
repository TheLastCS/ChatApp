using ChatApp.Helpers;
using ChatApp.Models;
using ChatApp.Views;
using Plugin.CloudFirestore;
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
        DataClass dataclass = DataClass.GetInstance;

        [Obsolete]
        public ChatPage()
        {
            InitializeComponent();
            retrieveContactList();
        }
        //This method collects all the contacts of the user logged in
        [Obsolete]
        private async void retrieveContactList()
        {
            ObservableCollection<ContactModel> contacts = new ObservableCollection<ContactModel>();
            ContactsListView.ItemsSource = contacts;

            var document = await CrossCloudFirestore.Current.Instance
                                    .GetCollection("contacts")
                                    .WhereArrayContains("contactID", dataclass.loggedInUser.Id)
                                    .GetDocumentsAsync();
            var model = document.ToObjects<ContactModel>();
            foreach(var data in model)
            {
                contacts.Add(new ContactModel() { id= data.id, contactID = data.contactID, contactEmail = data.contactEmail, contactName = data.contactName, created_at = data.created_at });
            }
            ContactLabel.IsVisible = contacts.Count == 0;
            ContactsListView.IsVisible = !(contacts.Count == 0);
        }

        [Obsolete]
        private void SearchEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchEntry.Text == "")
            {
                SearchedListView.IsVisible = false;
                retrieveContactList();
            }
           
        }

        [Obsolete]
        private async void SearchEntry_Completed(object sender, EventArgs e)
        {
            ObservableCollection<UserModel> data = new ObservableCollection<UserModel>();

            ContactsListView.IsVisible = false;
            ContactLabel.IsVisible = false;
            SearchedListView.IsVisible = true;

            var documents = await CrossCloudFirestore.Current
                            .Instance
                            .GetCollection("users")
                            .WhereEqualsTo("Email", SearchEntry.Text)
                            .GetDocumentsAsync();

            var model = documents.ToObjects<UserModel>();

            SearchedListView.ItemsSource = data;

            foreach (var mod in model)
            {
                data.Add(new UserModel() { Id = mod.Id, Username = mod.Username, Email = mod.Email, userType = mod.userType });
            }

            if (data.Count == 0)
            {
                await DisplayAlert("", "User not Found.", "Okay");
                SearchEntry.Text = "";
            }
        }

        private void SearchedListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}