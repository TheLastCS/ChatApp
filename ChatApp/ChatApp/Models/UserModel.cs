using ChatApp_Leano_Stewart.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp_Leano_Stewart.Models
{
    public class UserModel : ObservableObject
    {
        private string _id;
        public string Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("Id"); }
        }

        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged("Username"); }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged("Email"); }
        }
        
        private int _userType;
        public int userType
        {
            get { return _userType; }
            set { _userType = value; OnPropertyChanged("UserType"); }
        }
        /// <summary>
        /// User Type
        /// 0 - Email
        /// 1 - Google Sign in
        /// 2 - Facebook Sign in
        /// </summary>

        private DateTime _created_at;

        public DateTime created_at
        {
            get { return _created_at; }
            set { _created_at = value; OnPropertyChanged("CreateAt"); }
        }

        private List<string> _contacts;
        public List<string> contacts
        {
            get { return _contacts; }
            set { _contacts = value; OnPropertyChanged("contacts"); }
        }
    }
}
