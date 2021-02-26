using ASix_Training.Wpf.TreeView.Directory.Data;
using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace ASix_Training.Wpf.TreeView.Converters
{
    /// <summary>
    /// Конвертирует полный путь к ресурсу в картинку диска, папки или файла, в зависимости от входного типа
    /// </summary>
    [ValueConversion(typeof(DirectoryItemType), typeof(BitmapImage))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Картинка по умолчанию
            var image = "Images/file.png";

            switch ((DirectoryItemType)value)
            {
                case DirectoryItemType.Drive:
                    image = "Images/drive.png";
                    break;

                case DirectoryItemType.Folder:
                    image = "Images/folder-closed.png";
                    break;

                //default:
                //    image = string.Empty;
                //    break;
            }

            // Возвращаем финальную картинку для элемента, который конвертируется в xaml
            return new BitmapImage(new Uri($"pack://application:,,,/{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
