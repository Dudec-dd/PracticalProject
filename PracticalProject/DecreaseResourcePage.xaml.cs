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
    /// Логика взаимодействия для DecreaseResourcePage.xaml
    /// </summary>
    public partial class DecreaseResourcePage : Page
    {
        public DecreaseResourcePage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(NameTBox.Text != "" && QuantityTBox.Text != "" && Int32.TryParse(QuantityTBox.Text,out int x))
            {
                Resource resource = new Resource();
                resource.removeResourceFromDataBase(NameTBox.Text, Int32.Parse(QuantityTBox.Text));
                MessageBox.Show("Выполненно!");
                NavigationService.Navigate(new UserPage());
            }
            else
            {
                MessageBox.Show("Ошибка ввода!");
            }
        }
    }
}
