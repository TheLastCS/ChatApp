using ChatApp.Pages;
using ChatApp.ViewModels;
using Plugin.CloudFirestore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConversationPage : ContentPage
    {
        DataClass dataclass = DataClass.GetInstance;
        ContactModel userFriend;
        ObservableCollection<ConversationModel> conversation = new ObservableCollection<ConversationModel>();

        [Obsolete]
        public ConversationPage(ContactModel contact)
        {
            InitializeComponent();
            userFriend = contact;

            chatName.Text = (userFriend.contactID[0]== dataclass.loggedInUser.Id) ? userFriend.contactName[1] : userFriend.contactName[0];
            getMessage();

        }

        [Obsolete]
        private async void getMessage()
        {
            conversationsListView.ItemsSource = conversation;
            var documents = await CrossCloudFirestore.Current
                                    .Instance
                                    .GetCollection("contacts")
                                    .GetDocument(userFriend.id)
                                    .GetCollection("conversations")
                                    .OrderBy("created_at", false)
                                    .GetDocumentsAsync();
            var model = documents.ToObjects<ConversationModel>();

            foreach(var data in model)
            {
                conversation.Add(new ConversationModel { converseeID = data.converseeID, message = data.message, created_at = data.created_at });
            }
            var convo = conversationsListView.ItemsSource.Cast<object>().LastOrDefault();
            conversationsListView.ScrollTo(convo, ScrollToPosition.End, false);

            noChatLabel.IsVisible = conversation.Count == 0;
            conversationsListView.IsVisible = !(conversation.Count == 0);
        }

        [Obsolete]
        private void ButtonBack_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new TabbedPage();
        }

        [Obsolete]
        private async void SendButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(entryMessage.Text)) {
                if(entryMessage.Text.Length <= 240)
                {
                    noChatLabel.IsVisible = false;
                    conversationsListView.IsVisible = true;

                    ConversationModel convoSave = new ConversationModel()
                    {
                    id = Randomizer.generateID(),
                    converseeID = dataclass.loggedInUser.Id,
                    message = entryMessage.Text,
                    created_at = DateTime.UtcNow
                    };

                    await CrossCloudFirestore.Current
                        .Instance
                        .GetCollection("contacts")
                        .GetDocument(userFriend.id)
                        .GetCollection("conversations")
                        .GetDocument(convoSave.id)
                        .SetDataAsync(convoSave);

                    conversationsListView.ItemsSource = conversation;
                    conversation.Add(new ConversationModel() { converseeID = dataclass.loggedInUser.Id, message = entryMessage.Text });
                    entryMessage.Text = "";
                }
                else
                {
                    await DisplayAlert("Error", "Maximum of 240 words only", "Okay");
                    entryMessage.Text = "";
                }
         
            }
            else
            {
                return;
            }
        }

        private void DataTrigger_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }
    }
}