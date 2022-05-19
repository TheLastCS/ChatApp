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
using Plugin.CloudFirestore;

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
                        Id = FirebaseAuth.Instance.CurrentUser.Uid,
                        Email = FirebaseAuth.Instance.CurrentUser.Email,
                        Username = dataClass.loggedInUser.Username,
                        userType = dataClass.loggedInUser.userType,
                        created_at = dataClass.loggedInUser.created_at
                    };
                    dataClass.isSignedIn = true;
                }
                return response;
            }
            catch (Exception ex)
            {
                FirebaseAuthResponseModel response = new FirebaseAuthResponseModel() { status = false, response = ex.Message };
                dataClass.isSignedIn = false;
                dataClass.loggedInUser = new UserModel();
                return response;
            }
        }

        [Obsolete]
        public async Task<FirebaseAuthResponseModel> LoginWithEmailPassword(string email, string password)
        {
            try
            {
                FirebaseAuthResponseModel response = new FirebaseAuthResponseModel() { status = true, response = "Login successful." };
                IAuthResult result = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email,password);

                if(result.User.IsEmailVerified && email == result.User.Email)
                {
                    var document = await CrossCloudFirestore.Current
                                         .Instance
                                         .GetCollection("users")
                                         .GetDocument(result.User.Uid)
                                         .GetDocumentAsync();
                    var model = document.ToObject<UserModel>();

                    dataClass.loggedInUser = new UserModel()
                    {
                        Id = FirebaseAuth.Instance.CurrentUser.Uid,
                        Email = FirebaseAuth.Instance.CurrentUser.Email,
                        Username = dataClass.loggedInUser.Username,
                        userType = dataClass.loggedInUser.userType,
                        created_at = dataClass.loggedInUser.created_at
                    };
                    dataClass.isSignedIn = true;
                }
                else
                {
                    FirebaseAuth.Instance.CurrentUser.SendEmailVerification();
                    response.status = false;
                    response.response = "Email not verified. Sent another verification email.";
                    dataClass.loggedInUser = new UserModel();
                    dataClass.isSignedIn = false;
                }
                return response;
            }
            catch (Exception ex)
            {
                FirebaseAuthResponseModel response = new FirebaseAuthResponseModel() { status = false, response = ex.Message };
                dataClass.isSignedIn = false;
                dataClass.loggedInUser = new UserModel();
                return response;
            }
            
        }

        public async Task<FirebaseAuthResponseModel> ResetPassword(string email)
        {
            try
            {
                FirebaseAuthResponseModel response = new FirebaseAuthResponseModel() { status = true, response = "Email has been sent to your email address." };
                await FirebaseAuth.Instance.SendPasswordResetEmailAsync(email);
                return response;
            }
            catch (Exception ex)
            {
                FirebaseAuthResponseModel response = new FirebaseAuthResponseModel() { status = false, response = ex.Message };
                return response;
            }
        }

        public FirebaseAuthResponseModel SignOut()
        {
            try
            {
                FirebaseAuthResponseModel response = new FirebaseAuthResponseModel() { status = true, response = "Successfully logged out" };
                FirebaseAuth.Instance.SignOut();
                dataClass.isSignedIn = false;
                dataClass.loggedInUser = new UserModel();
                return response;
            }
            catch (Exception ex)
            {
                FirebaseAuthResponseModel response = new FirebaseAuthResponseModel() { status = false, response = ex.Message };
                dataClass.isSignedIn = true;
                return response;
            }
        }

        public async Task<FirebaseAuthResponseModel> SignUpwithEmailPassword(string name, string email, string password)
        {
            try
            {
                FirebaseAuthResponseModel response = new FirebaseAuthResponseModel() { status = true, response = "Successfully signed in" };
                await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
       
                FirebaseAuth.Instance.CurrentUser.SendEmailVerification();
               
                int ndx = email.IndexOf("@");
                int cnt = email.Length - ndx;
                string defaultName = string.IsNullOrEmpty(name) ? email.Remove(ndx, cnt) : name;
                
                dataClass.loggedInUser = new UserModel()
                {
                    Id = FirebaseAuth.Instance.CurrentUser.Uid,
                    Email = email,
                    Username = name,
                    userType = 0,
                    created_at = DateTime.UtcNow
                };

                return response;
            }
            catch (Exception ex)
            {
                FirebaseAuthResponseModel response = new FirebaseAuthResponseModel() { status = false, response = ex.Message };
                return response;
            }
        }
    }
}