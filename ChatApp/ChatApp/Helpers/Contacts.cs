using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Helpers
{
    public class Contacts
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool isValidated { get; set; }
        public DateTime CreatedOn { get; set; }

        public List<Contacts> tempdata;

        public void data()
        {
            // all the temp data  
            tempdata = new List<Contacts> {
                new Contacts(){ ID = 18103262, Username = "John Doe", Email = "johndoe@gmail.com", Password = "johndoe", isValidated = true, CreatedOn = DateTime.Now},
                new Contacts(){ ID = 18103263, Username = "Jane Doe", Email = "janedoe@gmail.com", Password = "janedoe", isValidated = false, CreatedOn = DateTime.Now},
                new Contacts(){ ID = 18103264, Username = "Christian Stewart", Email = "christianstewart5111@gmail.com", Password = "thelast", isValidated = false, CreatedOn = DateTime.Now},
                new Contacts(){ ID = 18103265, Username = "Admin God", Email = "admin@gmail.com", Password = "admin", isValidated = true, CreatedOn = DateTime.Now},
            };
        }

    }
}
