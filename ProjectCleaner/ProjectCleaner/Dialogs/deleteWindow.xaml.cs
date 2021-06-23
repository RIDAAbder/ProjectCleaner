using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ProjectCleaner.Model;

namespace ProjectCleaner
{

    public partial class deleteWindow : Window
    {
        public ObservableCollection<parameter> parameters = new ObservableCollection<parameter>();
        public deleteWindow(List<string> list)
        {
            InitializeComponent();
            for (int i = 0; i < list.Count; i++)
            {
                parameters.Add(new parameter(i + 1, list[i]));
            }
            dgv.ItemsSource = parameters;
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.paramTxtBox.Text))
            {
                parameters.Add(new parameter(dgv.Items.Count + 1, this.paramTxtBox.Text));
                dgv.ItemsSource = parameters;
            }

        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new passwordWindow();
            var result = dlg.ShowDialog();
            if (result == true)
            {
                var list = new List<string>();
                var entity = new StorageForParameter();
                foreach (var item in parameters)
                {
                    list.Add(item.Name);
                }
                entity.Names = list;
                //parameters.Clear();
                DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("The password is incorrect.", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
    }
}
