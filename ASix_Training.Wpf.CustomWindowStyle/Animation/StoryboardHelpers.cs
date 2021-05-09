using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace ASix_Training.Wpf.CustomWindowStyle.Animation
{
    /// <summary>
    /// Статический вспомогательный анимационный класс для <see cref="Storyboard"/>
    /// </summary>
    public static class StoryboardHelpers
    {
        /// <summary>
        /// Метод добавляет слайд справа в раскадровку
        /// </summary>
        /// <param name="storyboard">Раскадровка, к которой добавляется анимация</param>
        /// <param name="seconds">Время, которое занимает анимация</param>
        /// <param name="offset">Отступ справа, откуда начинается анимация</param>
        /// <param name="decelerationRatio">Показатель замедления анимации</param>
        public static void AddSlideFromRight(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f)
        {
            // Создание Margin анимации справа
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(offset, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            // Устанавливаем целевое свойство
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Добавляем слайд в раскадровку
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Метод добавляет появление анимации в раскадровку
        /// </summary>
        /// <param name="storyboard">Раскадровка, к которой добавляется анимация</param>
        /// <param name="seconds">Время, которое занимает анимация</param>        
        public static void AddFadeIn(this Storyboard storyboard, float seconds)
        {
            // Создание плавной Opacity анимации
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 0,
                To = 1,
            };

            // Устанавливаем целевое свойство
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            // Добавляем слайд в раскадровку
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Метод добавляет скрытие анимации в раскадровку
        /// </summary>
        /// <param name="storyboard">Раскадровка, к которой добавляется анимация</param>
        /// <param name="seconds">Время, которое занимает анимация</param>        
        public static void AddFadeOut(this Storyboard storyboard, float seconds)
        {
            // Создание Opacity анимации
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 1,
                To = 0,
            };

            // Устанавливаем целевое свойство
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            // Добавляем слайд в раскадровку
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Метод добавляет слайд слева в раскадровку
        /// </summary>
        /// <param name="storyboard">Раскадровка, к которой добавляется анимация</param>
        /// <param name="seconds">Время, которое занимает анимация</param>
        /// <param name="offset">Отступ справа, откуда начинается анимация</param>
        /// <param name="decelerationRatio">Показатель замедления анимации</param>
        public static void AddSlideToLeft(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f)
        {
            // Создание Margin анимации слева
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, offset, 0),
                DecelerationRatio = decelerationRatio
            };

            // Устанавливаем целевое свойство
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Добавляем слайд в раскадровку
            storyboard.Children.Add(animation);
        }

    }
}
