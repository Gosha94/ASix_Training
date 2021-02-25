using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASix_Training.Wpf.TreeView.Directory.Data
{
    /// <summary>
    /// Информация об элементе директории, например диске, папке, файле
    /// </summary>
    public class DirectoryItem
    {
        /// <summary>
        /// Тип элемента
        /// </summary>
        public DirectoryItemType Type { get; set; }
        // Абсолютный путь к текущему элементу директории
        public string FullPath { get; set; }
        // Имя текущего элемента директории
        public string Name 
        {
            get
            {
                // Если тип текущего элемента - диск, вернуть абсолютный путь
                return (this.Type == DirectoryItemType.Drive) ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath);
            }
        }
    }
}
