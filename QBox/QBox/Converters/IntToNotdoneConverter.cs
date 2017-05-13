using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace QBox.Converters
{
    class IntToNotdoneConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string x = "";
            int val = (int)value;
            if (val == 0)
            {
                x = "All wrong.";
            }
            else if (val == 1)
            {
                x = val + " item wrong.";

            }
            else
            {
                x = val + " items wrong.";

            }
            return x;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
