using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ChatApp.Helpers
{
    public class isViewerConverter : IValueConverter
    {
        DataClass dataClass = DataClass.GetInstance;

        public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool retval = false;

            string[] players = value as string[];
            if (!players[0].Equals(dataClass.loggedInUser.Id))
                retval = true;

            return retval;
        }
        public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
