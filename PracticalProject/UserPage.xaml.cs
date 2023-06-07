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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        Resource resource = new Resource();
        public UserPage()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            
                NavigationService.Navigate(new AddRescourcePage());
            
        }
        private void DecreaseButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataG.SelectedItem != null)
            {
                resource.SetSelectedRescource(DataG.SelectedItem as Resource);
                NavigationService.Navigate(new DecreaseResourcePage());
            }
            else
            {
                MessageBox.Show("Выберите значение в таблице");
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Resource resource = new Resource();
            DataG.ItemsSource = resource.GetListOfAllResources();
        }
    }
}
