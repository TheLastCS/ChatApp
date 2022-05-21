using ChatApp.ViewModels;
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

        public ConversationPage(ContactModel contact)
        {
            InitializeComponent();
            userFriend = contact;

            chatName.Text = (userFriend.contactID[0]== dataclass.loggedInUser.Id) ? userFriend.contactName[1] : userFriend.contactName[0];
            BindingContext = new ChatPageViewModel();

        }

        public void ScrollTap(object sender, System.EventArgs e)
        {
            lock (new object())
            {
                if (BindingContext != null)
                {
                    var vm = BindingContext as ChatPageViewModel; //returns null because bindingcontext refers to usermodel not chatpageviewmodel
                   
                    if(vm is null)
                    {
                        Console.WriteLine("Hello"+vm+ "Hahah");
                    }

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        while (vm.DelayedMessages.Count > 0)
                        {
                            vm.Messages.Insert(0, vm.DelayedMessages.Dequeue());
                        }
                        vm.ShowScrollTap = false;
                        vm.LastMessageVisible = true;
                        vm.PendingMessageCount = 0;
                        ChatList?.ScrollToFirst();
                    });


                }

            }
        }
        public void OnListTapped(object sender, ItemTappedEventArgs e)
        {
            chatInput.UnFocusEntry();
        }
    }
}