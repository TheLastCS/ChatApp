using ChatApp_Leano_Stewart.Helpers;
using ChatApp_Leano_Stewart.Models;
using ChatApp_Leano_Stewart.Pages;
using ChatApp_Leano_Stewart.Views;
using Plugin.CloudFirestore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatApp_Leano_Stewart
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        DataClass dataclass = DataClass.GetInstance;
        ObservableCollection<UserModel> allUsers = new ObservableCollection<UserModel>();

        [Obsolete]
        public ChatPage()
        {
            InitializeComponent();
            collectAllUsers();
            retrieveContactList();
        }

        //This method collects all the contacts of the user logged in

        [Obsolete]
        private async void collectAllUsers()
        {
            var documents = await CrossCloudFirestore.Current
                          .Instance
                          .GetCollection("users")
                          .GetDocumentsAsync();

            var model = documents.ToObjects<UserModel>();
            foreach (var data in model)
            {
                allUsers.Add(new UserModel() { Id = data.Id, Username = data.Username, Email = data.Email, userType = data.userType });
            }
        }
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
            Entry searchbar = (Entry)sender;
            if (!string.IsNullOrEmpty(SearchEntry.Text))
            {
                ContactsListView.IsVisible = false;
                ContactLabel.IsVisible = false;
                SearchedListView.IsVisible = true;
                SearchedListView.ItemsSource = allUsers.Where(u => u.Email.ToLower().Contains(SearchEntry.Text.ToLower())).ToList();
            }
            if (SearchEntry.Text == "")
            {
                SearchedListView.IsVisible = false;
                retrieveContactList();
            }
            else
            {
                ContactLabel.IsVisible = false;
                SearchedListView.IsVisible = true;
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

        [Obsolete]
        private async void SearchedListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var flag = 0;
            if (e.SelectedItem == null)
                return;

            var user = (UserModel)e.SelectedItem;
          
            var documents = await CrossCloudFirestore.Current.Instance
                                    .GetCollection("users")
                                    .WhereEqualsTo("Id", dataclass.loggedInUser.Id)
                                    .GetDocumentsAsync();
            var model = documents.ToObjects<UserModel>();
            //Double forloop for searching the entire contacts and flag if user found
            foreach (var data in model)
            {
                for (int x = 0; x < data.contacts.Count; x++)
                {
                    if (data.contacts[x] == user.Id)
                    {
                        flag++;
                        break;
                    }
                }
            }

            if (flag == 0)
            {
                bool choice = await DisplayAlert("Add Contact", "Would you like to add " + user.Username, "Yes", "No");
                //Bool for adding the person searched
                if (choice)
                {
                    //Check if user is not the owner so that he can't add himself
                    if (user.Email != dataclass.loggedInUser.Email)
                    {
                        ContactModel contact = new ContactModel()
                        {
                            id = Randomizer.generateID(),
                            contactID = new string[] { dataclass.loggedInUser.Id, user.Id },
                            contactEmail = new string[] { dataclass.loggedInUser.Email, user.Email },
                            contactName = new string[] { dataclass.loggedInUser.Username, user.Username },
                            created_at = DateTime.UtcNow
                        };

                        await CrossCloudFirestore.Current
                            .Instance
                            .GetCollection("contacts")
                            .GetDocument(contact.id)
                            .SetDataAsync(contact);
                        if (dataclass.loggedInUser.contacts == null)
                            dataclass.loggedInUser.contacts = new List<string>();
                        //update contacts of the owner
                        dataclass.loggedInUser.contacts.Add(user.Id);
                        await CrossCloudFirestore.Current
                            .Instance
                            .GetCollection("users")
                            .GetDocument(dataclass.loggedInUser.Id)
                            .UpdateAsync(new { contacts = dataclass.loggedInUser.contacts });
                        //update contact view to the friend added by the owner
                        if (user.contacts == null)
                            user.contacts = new List<string>();

                        user.contacts.Add(dataclass.loggedInUser.Id);
                        await CrossCloudFirestore.Current
                            .Instance
                            .GetCollection("users")
                            .GetDocument(user.Id)
                            .UpdateAsync(new { contacts = user.contacts });
                        await DisplayAlert("Sucess", "You and " + user.Username + " are now Friends", "Okay");
                    }
                    else
                    {
                        await DisplayAlert("", "You can't add yourself", "Okay");
                    }
                    SearchEntry.Text = "";
                }
            }
            else
            {
                await DisplayAlert("", "You and " + user.Username + " are already friends", "Okay");
            }
            ((ListView)sender).SelectedItem = null;

        }

        [Obsolete]
        private void ContactsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            var contact = (ContactModel)e.SelectedItem;

            Application.Current.MainPage = new ConversationPage(contact);

            ((ListView)sender).SelectedItem = null;
        }
    }
}