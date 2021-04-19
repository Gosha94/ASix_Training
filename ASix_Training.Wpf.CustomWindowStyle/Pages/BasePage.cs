using ASix_Training.Wpf.CustomWindowStyle.Animation;
using System.Windows.Controls;

namespace ASix_Training.Wpf.CustomWindowStyle.Pages
{
    /// <summary>
    /// Базовая страница для всех страниц проекта, для расширения базовой функциональности
    /// </summary>
    public class BasePage : Page
    {
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;
    }
}
