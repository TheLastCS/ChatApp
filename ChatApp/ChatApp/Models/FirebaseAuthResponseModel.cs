using System;
using System.Collections.Generic;
using System.ComponentModel;
using ChatApp_Leano_Stewart.Core;
using System.Text;

namespace ChatApp_Leano_Stewart
{
    public class FirebaseAuthResponseModel : ObservableObject
    {
        private bool _status;
        public bool status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("Status"); }
        }

        private string _response;
        public string response
        {
            get { return _response; }
            set { _response = value; OnPropertyChanged("Response"); }
        }

      

        
    }
}
