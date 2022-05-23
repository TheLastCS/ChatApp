using System;
using System.Collections.Generic;
using System.Text;
using ChatApp_Leano_Stewart.Views;
using ChatApp_Leano_Stewart.Models;
using Xamarin.Forms;

namespace ChatApp_Leano_Stewart.Helpers
{
    class ChatSelectorHelper : DataTemplateSelector
    {
        readonly DataTemplate incomingDataTemplate;
        readonly DataTemplate outgoingDataTemplate;

        public ChatSelectorHelper()
        {
            this.incomingDataTemplate = new DataTemplate(typeof(IncomingViewCell));
            this.outgoingDataTemplate = new DataTemplate(typeof(OutgoingViewCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (!(item is MessageModel messageVm))
                return null;


            return (messageVm.User == App.User) ? outgoingDataTemplate : incomingDataTemplate;
        }

    }
}
