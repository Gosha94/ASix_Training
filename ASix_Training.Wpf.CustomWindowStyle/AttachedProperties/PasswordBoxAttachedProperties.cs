using System.Windows;
using System.Windows.Controls;

namespace ASix_Training.Wpf.CustomWindowStyle.AttachedProperties
{

    /// <summary>
    /// Прикрепленное свойство - MonitorPassword для <see cref="PasswordBox"/>
    /// </summary>
    public class MonitorPasswordProperty : BaseAttachedProperty<MonitorPasswordProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // Получаем сендера метода
            var passwordBox = sender as PasswordBox;

            // Убедимся, что это PasswordBox
            if (passwordBox == null)
            {
                return;
            }

            // Отписываем предыдущие события
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            // Если звонящий устанавливает свойство MonitorPassword в true
            if ((bool)e.NewValue)
            {
                // Устанавливаем дефолтное значение
                HasTextProperty.SetValue(passwordBox);

                // Начинаем наблюдать за изменениями пароля
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }

        /// <summary>
        /// Отрабатывает когда значение в PasswordBox изменяется
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Устанавливает значение прикрепленного HasText
            HasTextProperty.SetValue((PasswordBox)sender);
        }
    }

    /// <summary>
    /// Прикрепленное свойство - HasText для <see cref="PasswordBox"/>
    /// </summary>
    public class HasTextProperty : BaseAttachedProperty <HasTextProperty, bool>
    {
        /// <summary>
        /// Устанавливает свойство HasText на основе сендера <see cref="PasswordBox"/>
        /// </summary>
        /// <param name="sender"></param>
        public static void SetValue(DependencyObject sender)
        {
            SetValue(sender, ((PasswordBox)sender).SecurePassword.Length > 0);
        }
    }

}
