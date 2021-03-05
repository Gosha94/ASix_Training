using System.Windows;

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
        private Window _window;

        /// <summary>
        /// Наружный отступ вокруг окна для установки теней
        /// </summary>
        private int _outerMarginSize = 10;

        /// <summary>
        /// Радиус закругления граней окна
        /// </summary>
        private int _windowRadius = 10;
        #endregion

        #region Public Properties        
        
        /// <summary>
        /// Размер толщины рамки вокруг окна
        /// </summary>
        public int ResizeBorder { get; set; } = 6;

        public Thickness ResizeBorderThickness { get => new Thickness(this.ResizeBorder); }

        public int OuterMarginSize
        {
            // Если окно развернуто на весь экран, то мы ставим ему отступ в 0, иначе отступ есть
            get => _window.WindowState == WindowState.Maximized ? 0 : _outerMarginSize;
            set
            {
                //_outerMarginSize = 
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>

        public WindowViewModel( Window window)
        {
            this._window = window;
        }

        #endregion
    }
}
