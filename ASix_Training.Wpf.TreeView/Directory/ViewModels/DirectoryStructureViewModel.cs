using ASix_Training.Wpf.TreeView.Directory.Data;
using System.Collections.ObjectModel;
using System.Linq;

namespace ASix_Training.Wpf.TreeView.Directory.ViewModels
{
    public class DirectoryStructureViewModel : BaseViewModel
    {
        /// <summary>
        /// Список всех директорий на ПК
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }

        public DirectoryStructureViewModel()
        {
            // Получаем логические диски
            var children = DirectoryStructure.GetLogicalDrives();
            // Создаем модели представления из данных
            this.Items = new ObservableCollection<DirectoryItemViewModel>(
                    children.Select(drive => new DirectoryItemViewModel(drive.FullPath, DirectoryItemType.Drive))
            );
        }
    }
}
