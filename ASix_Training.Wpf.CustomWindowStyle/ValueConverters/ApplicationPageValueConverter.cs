using ASix_Training.Wpf.CustomWindowStyle.DataModels;
using ASix_Training.Wpf.CustomWindowStyle.Pages;
using System;
using System.Diagnostics;
using System.Globalization;

namespace ASix_Training.Wpf.CustomWindowStyle.ValueConverters
{
    /// <summary>
    /// Преобразует enum <see cref="ApplicationPage"/> в текущий view/page
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {       
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Поиск подходящего view страницы
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Login:
                    return new LoginPage();

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
