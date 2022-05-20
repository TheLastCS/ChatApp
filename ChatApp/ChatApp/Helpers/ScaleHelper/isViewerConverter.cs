using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ChatApp.Helpers.ScaleHelper
{
    public class isViewerConverter : IValueConverter
    {
        DataClass dataclass = DataClass.GetInstance;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool retVal = false;
            if (value != null)
            {
                ConversationModel conversation = value as ConversationModel;

                if (conversation.converseeID.Equals(dataclass.loggedInUser.Id))
                    retVal = true;
            }
            else
            {
                retVal = true;
            }
            return retVal;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
