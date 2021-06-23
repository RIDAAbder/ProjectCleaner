using ProjectCleaner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectCleaner
{
    /// <summary>
    /// Interaction logic for passwordWindow.xaml
    /// </summary>
    public partial class passwordWindow : Window
    {
        public passwordWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (GlobalVariables.passwords.Contains(this.password.Password))
            {
                DialogResult = true;
            }
            else
            {
                DialogResult = false;
            }
        }
    }
}
