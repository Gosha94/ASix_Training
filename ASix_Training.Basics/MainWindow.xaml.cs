using System.Windows;
using System.Windows.Controls;

namespace ASix_Training.Basics
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void btn_Apply_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"TextBox say: {this.txtBx_Description.Text}");
        }

        private void btn_Reset_Click(object sender, RoutedEventArgs e)
        {
            this.chkBx_Weld.IsChecked = this.chkBx_Assembly.IsChecked = this.chkBx_Plasma.IsChecked = this.chkBx_Laser.IsChecked = this.chkBx_Purchase.IsChecked =
                this.chkBx_Lathe.IsChecked = this.chkBx_Drill.IsChecked = this.chkBx_Fold.IsChecked = this.chkBx_Roll.IsChecked = this.chkBx_Saw.IsChecked = false;
        }

        private void Checkbox_Checked(object sender, RoutedEventArgs e)
        {
            this.txtBx_Length.Text += (string)((CheckBox)sender).Content;
        }

        private void FinishCmbBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.txtBx_Note == null)
            {
                return;
            }

            var comboBox = (ComboBox)sender;
            var cmbBxValue = (ComboBoxItem)comboBox.SelectedValue;
            this.txtBx_Note.Text = (string)cmbBxValue.Content;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FinishCmbBx_SelectionChanged(this.cmbBx_Finish, null);
        }

        private void txtBx_Supplier_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.txtBx_Mass.Text = this.txtBx_Supplier.Text;
        }
    }
}
