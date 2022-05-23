using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatApp_Leano_Stewart
{
    public interface iFirebaseAuth
    {
        Task<FirebaseAuthResponseModel> LoginWithEmailPassword(string email, string password);
        Task<FirebaseAuthResponseModel> SignUpwithEmailPassword(string name, string email, string password);
        FirebaseAuthResponseModel SignOut();
        FirebaseAuthResponseModel IsLoggedIn();
        Task<FirebaseAuthResponseModel> ResetPassword(string email);
    }
}
