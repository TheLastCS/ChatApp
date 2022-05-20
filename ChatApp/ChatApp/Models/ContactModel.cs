using ChatApp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp
{
    public class ContactModel : ObservableObject
    {
        private string _id;
        public string id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("Id"); }
        }

        private string[] _contactID;
        public string[] contactID
        {
            get { return _contactID; }
            set { _contactID = value; OnPropertyChanged("contactID"); }
        }

        private string[] _contactName;
        public string[] contactName
        {
            get { return _contactName; }
            set { _contactName = value; OnPropertyChanged("contactName"); }
        }

        private string[] _contactEmail;
        public string[] contactEmail
        {
            get { return _contactEmail; }
            set { _contactEmail = value; OnPropertyChanged("contactEmail"); }
        }

        private DateTime _created_at;
        public DateTime created_at
        {
            get { return _created_at; }
            set { _created_at = value; OnPropertyChanged("created_at"); }
        }
    }
}