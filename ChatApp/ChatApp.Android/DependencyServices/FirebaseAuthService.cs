using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApp.Droid;
using Xamarin.Forms;
using Firebase.Auth;
using ChatApp.Models;

[assembly: Dependency(typeof(FirebaseAuthService))]
namespace ChatApp.Droid
{
    public class FirebaseAuthService : iFirebaseAuth
    {
        DataClass dataClass = DataClass.GetInstance;

        public FirebaseAuthResponseModel IsLoggedIn()
        {
            try
            {
                FirebaseAuthResponseModel response = new FirebaseAuthResponseModel() { status = true, response = "Currently logged in." };
                if(FirebaseAuth.Instance.CurrentUser.Uid == null)
                {
                    response = new FirebaseAuthResponseModel() { status = false, response = "Currently logged out." };
                    dataClass.isSignedIn = false;
                    dataClass.loggedInUser = new UserModel();
                }
                else
                {
                    dataClass.loggedInUser = new UserModel()
                    {
                        Id = int.Parse(FirebaseAuth.Instance.CurrentUser.Uid),
                        Email = FirebaseAuth.Instance.CurrentUser.Email,
                        Username = FirebaseAuth.Instance.CurrentUser.name,

                    }
                }
            }
            catch
            {

            }
            throw new NotImplementedException();

        }

        public Task<FirebaseAuthResponseModel> LoginWithEmailPassword(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<FirebaseAuthResponseModel> ResetPassword(string email)
        {
            throw new NotImplementedException();
        }

        public FirebaseAuthResponseModel SignOut()
        {
            throw new NotImplementedException();
        }

        public Task<FirebaseAuthResponseModel> SignUpwithEmailPassword(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}