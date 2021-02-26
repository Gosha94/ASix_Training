using PropertyChanged;
using System.ComponentModel;

namespace ASix_Training.Wpf.TreeView.Directory.ViewModels
{
    /// <summary>
    /// Базовая модель представления которая поддерживает события PropertyChanged, все дочерние классы будут пробрасывать свои свойства во вью без дублей кода
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Событие, поднимающееся, когда свойство дочернего клсса меняет значение
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}