namespace ASix_Training.Wpf.CustomWindowStyle.AttachedProperties
{
    /// <summary>
    /// Общий класс для всех прикрепляемых свойств
    /// </summary>
    /// <typeparam name="Parent">Родительский класс который является прикрепляемым свойством</typeparam>
    /// <typeparam name="Property">Тип прикрепляемого свойства</typeparam>
    public abstract class BaseAttachedProperty<Parent, Property>
        where Parent : new()
    {

        #region Public Properties

        /// <summary>
        /// Синглтон нашего родительского класса
        /// </summary>
        public static Parent Instance { get; private set; } = new Parent();

        #endregion


        public string WhatsMyType()
        {
            return typeof(T).ToString();
        }
    }

    public class MyAttachedProperty : BaseAttachedProperty<bool>
    {

    }

    public class A
    {
        public A()
        {
            var m = new MyAttachedProperty();
            m.WhatsMyType();
        }
    }

}
