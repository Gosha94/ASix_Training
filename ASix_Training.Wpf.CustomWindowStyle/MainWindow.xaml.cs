﻿using ASix_Training.Wpf.CustomWindowStyle.ViewModel;
using System.Windows;

namespace ASix_Training.Wpf.CustomWindowStyle
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new WindowViewModel(this);
        }
    }
}
