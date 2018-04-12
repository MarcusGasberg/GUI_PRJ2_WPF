using GUI_PRJ2.Pages;
using System;
using System.Diagnostics;
using System.Globalization;

namespace GUI_PRJ2
{
    /// <summary>
    /// Converts the <see cref="ApplicationPage"/> to an actual page
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Find the appropriate page
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.MainMenu:
                    return new MainMenu();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
