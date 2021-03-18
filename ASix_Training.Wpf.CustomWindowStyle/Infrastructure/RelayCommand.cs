using System;
using System.Windows.Input;

namespace ASix_Training.Wpf.CustomWindowStyle.Infrastructure
{
    /// <summary>
    /// Базовая команда, которая запускает Action
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Private Members

        private Action _action;

        #endregion

        #region Public Events

        /// <summary>
        /// Событие запускается, когда значение <see cref="CanExecute(object)"/> меняется
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="action"></param>
        public RelayCommand ( Action action )
        {
            this._action = action;
        }
        #endregion

        /// <summary>
        /// Команда, которая всегда выполняется
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        // Выполняет метод действия из команды
        public void Execute(object parameter)
        {
            this._action();
        }
    }
}
