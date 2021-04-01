namespace ASix_Training.Wpf.CustomWindowStyle.AttachedProperties
{
    /// <summary>
    /// Общий класс для всех прикрепляемых свойств
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseAttachedProperty<T>
    {
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
