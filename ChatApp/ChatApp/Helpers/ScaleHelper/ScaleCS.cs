using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChatApp_Leano_Stewart.Helpers
{
    public static class ScaleCS
    {
        public static float ScaleHeight(this int number, int ? iOS = null)
        {
            if (iOS.HasValue && Device.RuntimePlatform == Device.iOS)
                number = iOS.Value;

            return (float)(number * (App.screenHeight / 568.0));
        }

        public static float ScaleHeight(this float number, int? iOS = null)
        {
            if (iOS.HasValue && Device.RuntimePlatform == Device.iOS)
                number = iOS.Value;

            return (float)(number * (App.screenHeight / 568.0));
        }

        public static float ScaleHeight(this double number, int? iOS = null)
        {
            if (iOS.HasValue && Device.RuntimePlatform == Device.iOS)
                number = iOS.Value;

            return (float)(number * (App.screenHeight / 568.0));
        }

        public static float ScaleWidth(this int number, int? iOS = null)
        {
            if (iOS.HasValue && Device.RuntimePlatform == Device.iOS)
                number = iOS.Value;

            return (float)(number * (App.screenHeight / 568.0));
        }

        public static float ScaleWidth(this float number, int? iOS = null)
        {
            if (iOS.HasValue && Device.RuntimePlatform == Device.iOS)
                number = iOS.Value;

            return (float)(number * (App.screenHeight / 568.0));
        }

        public static float ScaleWidth(this double number, int? iOS = null)
        {
            if (iOS.HasValue && Device.RuntimePlatform == Device.iOS)
                number = iOS.Value;

            return (float)(number * (App.screenHeight / 568.0));
        }

        public static double ScaleFont(this int number, int? iOS = null)
        {
            if (iOS.HasValue && Device.RuntimePlatform == Device.iOS)
                number = iOS.Value;

            return (number * (App.screenHeight / 568.0) - (Device.RuntimePlatform == Device.iOS ? 0.5 : 0));
        }

        public static double ScaleFont(this double number, double? iOS = null)
        {
            if (iOS.HasValue && Device.RuntimePlatform == Device.iOS)
                number = iOS.Value;

            return (number * (App.screenHeight / 568.0) - (Device.RuntimePlatform == Device.iOS ? 0.5 : 0));
        }
    }
}
