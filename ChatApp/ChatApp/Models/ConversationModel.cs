using ChatApp_Leano_Stewart.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp_Leano_Stewart
{
    public class ConversationModel : ObservableObject
    {
        private string _id;
        public string id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("id"); }
        }

        private string _message;
        public string message
        {
            get { return _message; }
            set { _message = value; OnPropertyChanged("message"); }
        }

        private string _converseeID;
        public string converseeID
        {
            get { return _converseeID; }
            set { _converseeID = value; OnPropertyChanged("converseeID"); }
        }

        private DateTime _created_at;
        public DateTime created_at
        {
            get { return _created_at; }
            set { _created_at = value; OnPropertyChanged("created_at"); }
        }
    }
}