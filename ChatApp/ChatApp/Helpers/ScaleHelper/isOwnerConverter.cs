using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ChatApp_Leano_Stewart.Helpers.ScaleHelper
{
    public class isOwnerConverter : IValueConverter
    {
        DataClass dataClass = DataClass.GetInstance;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool retval = false;
            if (value == null)
            {
                retval = false;
            }

            string[] persons = value as string[];

            /* if the person is the logged in user */
            if (persons[0].Equals(dataClass.loggedInUser.Id))
                retval = true;

            return retval;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
