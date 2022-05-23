using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatApp_Leano_Stewart.Droid
{
    [Activity(Label = "Wave", Icon = "@mipmap/ic_launcher_foreground", Theme = "@style/splashscreen", MainLauncher = true, NoHistory = true)]
    class SplashActivity: AppCompatActivity
    {
        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(typeof(MainActivity));
        }
    }
}