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
    [ValueConversion(typeof(string), typeof(BitmapImage))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Получаем полный путь
            var path = (string)value;

            // Если полный путь пуст, не конвертируем ничего
            if (path == null)
            {
                return null;
            }

            // Получаем имя папки/файла/диска
            var name = MainWindow.GetFileFolderName(path);

            // Картинка по умолчанию
            var image = "Images/file.png";

            // Если имя пустое, значит мы предполагаем, что в метод передан диск, т.к. имя файла или каталога не может быть пустым
            if (string.IsNullOrEmpty(name))
            {
                image = "Images/drive.png";
            }
            // Проверяемый путь представляет собой каталог
            else if (new FileInfo(path).Attributes.HasFlag(FileAttributes.Directory))
            {
                image = "Images/folder-closed.png";
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
