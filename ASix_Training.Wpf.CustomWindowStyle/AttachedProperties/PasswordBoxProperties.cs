using System.Windows;

namespace ASix_Training.Wpf.CustomWindowStyle.AttachedProperties
{
    public class PasswordBoxProperties
    {
        public bool HasText { get; set; } = false;

        public static readonly DependencyProperty HasTextProperty = DependencyProperty.RegisterAttached("HasText", typeof(bool), typeof(PasswordBoxProperties), new PropertyMetadata(false));
    }
}
