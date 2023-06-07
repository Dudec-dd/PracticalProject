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

namespace PracticalProject
{
    /// <summary>
    /// Логика взаимодействия для ManagerPage.xaml
    /// </summary>
    public partial class ManagerPage : Page
    {
        public ManagerPage()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddSuplier());
        }

        private void RemButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataG.SelectedItem != null)
            {
                Suplier suplier = DataG.SelectedItem as Suplier;
                suplier.removeSuplierFromDataBase(suplier.organizationName, suplier.resource);
                DataG.ItemsSource = suplier.GetListOfAllSupliers();
            }
            else
            {
                MessageBox.Show("Выберите значение в таблице");
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Suplier suplier = new Suplier();
            DataG.ItemsSource = suplier.GetListOfAllSupliers();
        }
    }
}
