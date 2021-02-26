using ASix_Training.Wpf.TreeView.Directory.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace ASix_Training.Wpf.TreeView
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Конструктор

        /// <summary>
        /// Конструктор формы по умолчанию
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new DirectoryStructureViewModel();            
        }

        #endregion
    }
}
