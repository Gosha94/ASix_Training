using System.Windows;
using System.Threading.Tasks;
using System.Windows.Controls;
using ASix_Training.Wpf.CustomWindowStyle.Animation;

namespace ASix_Training.Wpf.CustomWindowStyle.Pages
{
    /// <summary>
    /// Базовая страница для всех страниц проекта, для расширения базовой функциональности
    /// </summary>
    public class BasePage : Page
    {
        #region Public Properties
        /// <summary>
        /// Анимация при загрузке страницы
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        /// <summary>
        /// Анимация при закрытии страницы
        /// </summary>
        public PageAnimation PageUnLoadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        /// <summary>
        /// Время работы анимации в секундах
        /// </summary>
        public float SlideSeconds { get; set; } = 0.8f;
        #endregion

        #region Constructor
        /// <summary>
        /// Конструктор страницы по умолчанию
        /// </summary>
        public BasePage()
        {
            // Если статус анимации - не отключена, значит она работает, скрываем ее до полной загрузки страницы
            if (this.PageLoadAnimation != PageAnimation.None)
            {
                Visibility = Visibility.Collapsed;
            }

            // Прослушиваем событие конца загрузки страницы в память
            this.Loaded += BasePage_Loaded;
        }

        #endregion
        
        #region Animation Load / Unload
        /// <summary>
        /// Один раз при загрузке страницы выполняем требуемый тип анимации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            // Начальная анимация страницы
            await AnimateIn();
        }

        /// <summary>
        /// Начальная анимация страницы
        /// </summary>
        /// <returns></returns>
        public async Task AnimateIn()
        {
            // Убедимся, что анимация должна выполняться
            if (this.PageLoadAnimation == PageAnimation.None)
            {
                return;
            }

            switch (this.PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    
                    // Стартуем анимацию
                    await this.SlideAndFadeInFromRight(this.SlideSeconds);
                    
                    break;
            }
        }

        /// <summary>
        /// Конечная анимация страницы
        /// </summary>
        /// <returns></returns>
        public async Task AnimateOut()
        {
            // Убедимся, что анимация должна выполняться
            if (this.PageUnLoadAnimation == PageAnimation.None)
            {
                return;
            }

            switch (this.PageUnLoadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:

                    // Стартуем анимацию
                    await this.SlideAndFadeOutToLeft(this.SlideSeconds);

                    break;
            }
        }

        #endregion
    }
}
