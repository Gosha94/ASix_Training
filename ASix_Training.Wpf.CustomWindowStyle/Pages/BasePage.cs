using ASix_Training.Wpf.CustomWindowStyle.Animation;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace ASix_Training.Wpf.CustomWindowStyle.Pages
{
    /// <summary>
    /// Базовая страница для всех страниц проекта, для расширения базовой функциональности
    /// </summary>
    public class BasePage : Page
    {
        #region Public Properties
        /// <summary>
        /// Анимация при первой загрузке страницы
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

        private async Task AnimateIn()
        {
            // Убедимся, что анимация должна выполняться
            if (this.PageLoadAnimation == PageAnimation.None)
            {
                return;
            }

            switch (this.PageLoadAnimation)
            {
                case PageAnimation.None:
                    break;
                case PageAnimation.SlideAndFadeInFromRight:
                    var storyBoard = new Storyboard();
                    var slideAnimation = new ThicknessAnimation
                    {
                        Duration = new Duration(TimeSpan.FromSeconds(this.SlideSeconds)),
                        From = new Thickness(this.WindowWidth, 0, -this.WindowWidth, 0),
                        To = new Thickness(0),
                        DecelerationRatio = 0.9f
                    };
                    Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Margin"));
                    storyBoard.Children.Add(slideAnimation);
                    
                    storyBoard.Begin(this);

                    this.Visibility = Visibility.Visible;

                    await Task.Delay((int)(this.SlideSeconds * 1000));

                    break;

                case PageAnimation.SlideAndFadeOutToLeft:
                    break;
                default:
                    break;
            }
        }

        #endregion
    }
}
