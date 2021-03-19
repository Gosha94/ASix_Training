using ASix_Training.Wpf.CustomWindowStyle.DataModels;
using ASix_Training.Wpf.CustomWindowStyle.Infrastructure;
using System.Windows;
using System.Windows.Input;
using ASix_Training.Wpf.CustomWindowStyle.Window;

namespace ASix_Training.Wpf.CustomWindowStyle.ViewModel
{
    /// <summary>
    /// Модель представления для кастомного окна со стилями
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {

        #region Private Members

        /// <summary>
        /// Window, которое контролирует данная модель представления
        /// </summary>
        private System.Windows.Window _window;

        /// <summary>
        /// Наружный отступ вокруг окна для установки теней
        /// </summary>
        private int _outerMarginSize = 10;

        /// <summary>
        /// Радиус закругления граней окна
        /// </summary>
        private int _windowRadius = 10;
        
        /// <summary>
        /// Последняя известная позиция закрепления окна
        /// </summary>
        private WindowDockPosition _dockPosition = WindowDockPosition.Undocked;

        #endregion

        #region Public Properties

        /// <summary>
        /// Минимальная ширина окна
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 400;

        /// <summary>
        /// Минимальная высота окна
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 400;

        /// <summary>
        /// Истина, если окну следует добавить границу, т.к. оно закреплено или развернуто
        /// </summary>
        public bool Borderless { get => _window.WindowState == WindowState.Maximized || _dockPosition != WindowDockPosition.Undocked; }

        /// <summary>
        /// Размер меняющей размер рамки вокруг окна
        /// </summary>
        public int ResizeBorder { get => Borderless ? 0 : 6; }
        /// <summary>
        /// Размер меняющей размер рамки вокруг окна, учитывая внешний отступ
        /// </summary>
        public Thickness ResizeBorderThickness { get => new Thickness(this.ResizeBorder + this.OuterMarginSize); }

        /// <summary>
        /// Отступ внутреннего содержимого от главного окна
        /// </summary>
        public Thickness InnerContentPadding { get; set; } = new Thickness(0);

        /// <summary>
        /// Отступ вокруг окна для создания тени
        /// </summary>
        public int OuterMarginSize
        {
            // Если окно развернуто на весь экран, то мы ставим ему отступ в 0, иначе отступ есть
            get => _window.WindowState == WindowState.Maximized ? 0 : _outerMarginSize;
            set
            {
                _outerMarginSize = value;
            }
        }
        /// <summary>
        /// Отступ вокруг окна для создания тени  в представлении
        /// </summary>
        public Thickness OuterMarginSizeThickness { get => new Thickness(this.OuterMarginSize); }

        /// <summary>
        /// Радиус скругления углов окна
        /// </summary>
        public int WindowsRadius
        {            
            get => _window.WindowState == WindowState.Maximized ? 0 : _windowRadius;
            set
            {
                _windowRadius = value;
            }
        }
        /// <summary>
        /// Радиус скругления углов окна для представления
        /// </summary>
        public CornerRadius WindowCornerRadius { get => new CornerRadius(this.WindowsRadius); }

        /// <summary>
        /// Высота заголовка шапки окна
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        /// <summary>
        /// 
        /// </summary>
        public GridLength TitleHeightGridLength { get => new GridLength(this.TitleHeight + this.ResizeBorder); }

        /// <summary>
        /// Текущая страница приложения
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;

        #endregion

        #region Commands
        /// <summary>
        /// Команда уменьшения окна
        /// </summary>
        public ICommand MinimizedCommand { get; set; }

        /// <summary>
        /// Команда увеличения окна
        /// </summary>
        public ICommand MaximizedCommand { get; set; }

        /// <summary>
        /// Команда закрытия окна
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// Команда открытия меню
        /// </summary>
        public ICommand MenuCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>

        public WindowViewModel(System.Windows.Window window)
        {
            this._window = window;

            // Наблюдаем за изменениями окна формы
            _window.StateChanged += (sender, e) => 
            {
                // Запускаем события изменения для всех свойств, на которые влияет изменение размера
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowsRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            // Создаем команды
            MinimizedCommand = new RelayCommand( () => _window.WindowState = WindowState.Minimized );
            MaximizedCommand = new RelayCommand( () => _window.WindowState ^= WindowState.Maximized );
            CloseCommand = new RelayCommand( () => _window.Close() );
            MenuCommand = new RelayCommand( () => SystemCommands.ShowSystemMenu(_window, GetMousePosition()) );

            // Фикс расширения окна
            //var resizer = new WindowResizer(_window);
        }

        #endregion

        #region Private Helpers
        
        /// <summary>
        /// Получаем текущую позицию курсора мыши на экране
        /// </summary>
        /// <returns></returns>
        private Point GetMousePosition()
        {
            // Позиция мыши относительно окна
            var position = Mouse.GetPosition(_window);
            // Устанавливаем начальные координаты внутри текущего окна
            // необходимо для того, чтобы если уменишьить размер окна, 
            // всплывающее меню было не в левом верхнем углу экрана, а внутри окна
            return new Point(position.X + _window.Left, position.Y + _window.Top);            
        }
        #endregion
    }
}
