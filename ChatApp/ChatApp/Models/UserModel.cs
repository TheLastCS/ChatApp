using ChatApp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Models
{
    public class UserModel : ObservableObject
    {
        private int _id;
        public int Id
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

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged("Password"); }
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
    }
}
