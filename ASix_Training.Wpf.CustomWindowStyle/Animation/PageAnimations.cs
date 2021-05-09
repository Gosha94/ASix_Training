using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace ASix_Training.Wpf.CustomWindowStyle.Animation
{
    /// <summary>
    /// Класс-помощник анимации страниц Pages
    /// </summary>
    public static class PageAnimations
    {
        /// <summary>
        /// Анимация постепенного появления страницы справа
        /// </summary>
        /// <param name="page">Страница, которую анимируем</param>
        /// <param name="seconds">Время, которое занимает анимация</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRight(this Page page, float seconds)
        {
            // Создаем раскадровку
            var storyBoard = new Storyboard();
            
            // Добавляем слайд справа
            storyBoard.AddSlideFromRight(seconds, page.WindowWidth);

            // Добавялем анимацию появления страницы
            storyBoard.AddFadeIn(seconds);

            // Стартуем анимацию
            storyBoard.Begin(page);

            // Делаем страницу видимой
            page.Visibility = Visibility.Visible;

            // Ожидаем окончания раскадровки
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Анимация удаления страницы влево с постепенным увеличением прозрачности
        /// </summary>
        /// <param name="page">Страница, которую анимируем</param>
        /// <param name="seconds">Время, которое занимает анимация</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeft(this Page page, float seconds)
        {
            // Создаем раскадровку
            var storyBoard = new Storyboard();

            // Добавляем слайд слева
            storyBoard.AddSlideToLeft(seconds, page.WindowWidth);

            // Добавялем анимацию прозрачности
            storyBoard.AddFadeOut(seconds);

            // Стартуем анимацию
            storyBoard.Begin(page);

            // Делаем страницу видимой
            page.Visibility = Visibility.Visible;

            // Ожидаем окончания раскадровки
            await Task.Delay((int)(seconds * 1000));
        }

    }
}
