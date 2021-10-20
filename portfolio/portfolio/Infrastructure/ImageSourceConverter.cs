using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Globalization;
using System.IO;

namespace portfolio.Infrastructure
{
    public class ImageSourceConverter : IValueConverter
    {
        string root = Directory.GetCurrentDirectory();
        string ImageDirectory => Path.Combine(root, "Images");

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return Path.Combine(ImageDirectory, (string)value);
            }
            catch
            {
                return Path.Combine(ImageDirectory, "empty");
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
