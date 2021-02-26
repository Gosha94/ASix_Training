using ASix_Training.Wpf.TreeView.Directory.Data;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ASix_Training.Wpf.TreeView.Directory.ViewModels
{
    /// <summary>
    /// Модель представления для каждого элемента директории
    /// </summary>
    public class DirectoryItemViewModel : BaseViewModel
    {
        #region Public Properties        
        public DirectoryItemType Type { get; set; }
        public string FullPath { get; set; }

        /// <summary>
        /// Имя данного элемента директории
        /// </summary>
        public string Name 
        { 
            get => (this.Type == DirectoryItemType.Drive) ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath);
        }
        /// <summary>
        /// Список всех потомков, содержащиеся внутри текущего элемента
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        // Показывает, может ли текущий элемент быть раскрыт ( не может, если тип элемента - Файл )
        public bool CanExpand
        {
            get => this.Type != DirectoryItemType.File;
        }

        // Свойство сообщает, раскрыт или нет текущий элемент дерева 
        public bool IsExpanded
        {
            get => this.Children?.Count(f => f != null) > 0;
            set
            {
                // Если UI сообщает нам, что элемент хотят раскрыть...
                if (value == true)
                {
                    // Ищем всех потомков
                    this.Expand();
                }
                // В другом случае, если UI сообщает о закрытии элемента
                else
                {
                    this.ClearChildren();
                }
            }
        }
        #endregion

        #region Public Commands

        /// <summary>
        /// Команда раскрытия текущего элемента
        /// </summary>        
        public ICommand ExpandCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="fullPath">Полный путь текущего элемента</param>
        /// <param name="type">Тип элемента</param>
        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            // Привязка команды к обработчику действия для раскрытия дерева элементов
            this.ExpandCommand = new RelayCommand(Expand);

            // Установка пути и типа элемента
            this.FullPath = fullPath;
            this.Type = type;
            // Очистка и настройка дочерних элементов
            this.ClearChildren();
        }

        #endregion

        #region Hepler Methods        

        /// <summary>
        /// Удаляет всех потомков из списка, добавляя пустую заглушку, чтобы можно было развернуть список повторно
        /// </summary>
        private void ClearChildren()
        {
            // Clear children
            this.Children = new ObservableCollection<DirectoryItemViewModel>();
            // Show the expand arrow if this exemplar not a file
            if (this.Type != DirectoryItemType.File)
            {
                this.Children.Add(null);
            }
        }

        #endregion

        /// <summary>
        /// Раскрывает директорию и ищет всех потомков
        /// </summary>
        private void Expand()
        {
            // Мы не можем развернуть файл как список
            if (this.Type == DirectoryItemType.File)
            {
                return;
            }
            // Находим все дочерние элементы
            this.Children = new ObservableCollection<DirectoryItemViewModel>(
                DirectoryStructure.GetDirectoryContents(this.FullPath)
                    .Select(
                        content => new DirectoryItemViewModel(content.FullPath,content.Type)
                    )
                );
        }

    }
}
