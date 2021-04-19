using System;
using System.Windows;

namespace ASix_Training.Wpf.CustomWindowStyle.AttachedProperties
{
    /// <summary>
    /// Общий класс для всех прикрепляемых свойств
    /// </summary>
    /// <typeparam name="Parent">Родительский класс который является прикрепляемым свойством</typeparam>
    /// <typeparam name="Property">Тип прикрепляемого свойства</typeparam>
    public abstract class BaseAttachedProperty<Parent, Property>
        where Parent : BaseAttachedProperty<Parent,Property>, new()
    {

        #region Public Events
        
        /// <summary>
        /// Запускается когда значение было изменено
        /// </summary>
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        #endregion

        #region Public Properties

        /// <summary>
        /// Синглтон нашего родительского класса
        /// </summary>
        public static Parent Instance { get; private set; } = new Parent();

        #endregion

        #region Attached Property Definitions

        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached("Value", typeof(Property), typeof(BaseAttachedProperty<Parent, Property>), new PropertyMetadata(new PropertyChangedCallback(OnValuePropertyChanged)));

        /// <summary>
        /// Cобытие обратного вызова, срабатыввает, когда меняется ValueProperty
        /// </summary>
        /// <param name="d">UI элемент, который имеет изменяемое свойство</param>
        /// <param name="e">Аргументы события</param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Вызываем родительскую функцию
            Instance.OnValueChanged(d, e);

            // Вызываем слушатели события
            Instance.ValueChanged(d, e);
        }

        /// <summary>
        /// Метод получает прикрепляемое свойство
        /// </summary>
        /// <param name="d">Элемент, который получает свойство</param>
        /// <returns></returns>
        public static Property GetValue(DependencyObject d) => (Property)d.GetValue(ValueProperty);

        /// <summary>
        /// Метод устанавливает присоединенное свойство
        /// </summary>
        /// <param name="d">Элемент для получения свойства</param>
        /// <param name="value">Значение для установки свойства</param>
        public static void SetValue(DependencyObject d, Property value) => d.SetValue(ValueProperty, value);

        #endregion

        #region EventMethods
        /// <summary>
        /// Метод который вызывается прикрепленным св-вом меняемого типа
        /// </summary>
        /// <param name="sender">UI элемент, который меняет свойство</param>
        /// <param name="e">Аргументы события</param>
        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { }
        
        #endregion
    }
}