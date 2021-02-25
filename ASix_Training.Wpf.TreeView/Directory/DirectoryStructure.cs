using ASix_Training.Wpf.TreeView.Directory.Data;
using System.Collections.Generic;
using System.Linq;
using directory = System.IO.Directory;

namespace ASix_Training.Wpf.TreeView.Directory
{
    /// <summary>
    /// Вспомогательный класс, запрашиват инфо о директориях
    /// </summary>
    public static class DirectoryStructure
    {
        /// <summary>
        /// Метод получает буквы всех системных дисков на ПК
        /// </summary>
        /// <returns>Возвращает список элементов</returns>
        public static List<DirectoryItem> GetLogicalDrives()
        {
            
            return directory.GetLogicalDrives()
                    .Select(drive => new DirectoryItem { FullPath = drive, Type = DirectoryItemType.Drive })
                        .ToList();
            
        }
        /// <summary>
        /// Получаем контент в директориях верхнего уровня
        /// </summary>
        /// <param name="fullPath"></param>
        /// <returns></returns>
        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            var items = new List<DirectoryItem>();

            #region Get Folders
            // Попытаемся получить директории из папки, игнорируя ошибки блоком try...catch
            try
            {
                var dirs = directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                {
                    items.AddRange(dirs.Select(dir => new DirectoryItem { FullPath = dir, Type = DirectoryItemType.Folder }));
                }
            }
            catch { }
            #endregion

            #region Get Files
            // Попытаемся получить файлы из папки, игнорируя ошибки блоком try...catch
            try
            {
                var fs = directory.GetFiles(fullPath);
                if (fs.Length > 0)
                {
                    items.AddRange(fs.Select(file => new DirectoryItem { FullPath = file, Type = DirectoryItemType.File }));
                }
            }
            catch { }

            #endregion
            return items;
        }

        #region Helpers        
        /// <summary>
        /// Метод возвращает имя файла или папки из полного пути каталога
        /// </summary>
        /// <param name="path">The full path</param>
        /// <returns></returns>
        public static string GetFileFolderName(string path)
        {
            // Если путей не найдено, возвращаем пустую строку
            if (string.IsNullOrEmpty(path))
            {
                return string.Empty;
            }

            // Меняем все слеши на обратные
            var normalizedPath = path.Replace('/', '\\');
            // Находим последнюю косую черту в директории, это будет крайняя папка, далее - файлы
            var lastIndex = normalizedPath.LastIndexOf('\\');
            // Если обратный слеш не найден, то возвращаем путь, который получили на вход
            if (lastIndex <= 0)
            {
                return path;
            }

            // Возвращаем имя папки после крайнего слеша
            return path.Substring(lastIndex + 1);
        }
        #endregion
    }
}
