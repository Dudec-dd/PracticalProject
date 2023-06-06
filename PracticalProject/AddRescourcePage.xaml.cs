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
    /// Логика взаимодействия для AddRescourcePage.xaml
    /// </summary>
    public partial class AddRescourcePage : Page
    {
        public AddRescourcePage()
        {
            InitializeComponent();
        }

        private void NotationTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (NotationTBox.Text == "Введите меру измерения") NotationTBox.Text="";
        }

        private void NotationTBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (NotationTBox.Text == "") NotationTBox.Text = "Введите меру измерения";
        }

        private void QuantityTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (QuantityTBox.Text == "Введите количество") QuantityTBox.Text = "";
        }

        private void QuantityTBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (QuantityTBox.Text == "") QuantityTBox.Text = "Введите количество";
        }

        private void NameTBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (NameTBox.Text == "") NameTBox.Text = "Введите название";
        }

        private void NameTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (NameTBox.Text == "Введите название") NameTBox.Text = "";
        }

        private void PriceTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PriceTBox.Text == "Введите цену") PriceTBox.Text = "";
        }

        private void PriceTBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PriceTBox.Text == "") PriceTBox.Text = "Введите цену";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(QuantityTBox.Text,out int a) && NameTBox.Text != "" && NotationTBox.Text != "" && QuantityTBox.Text != "" && PriceTBox.Text !="" && GetDatePicker.Text !="" && GetExpirationDatePicker.Text != "" && float.TryParse(PriceTBox.Text,out float x))
            {
                Resource resource = new Resource(NotationTBox.Text, Int32.Parse(QuantityTBox.Text), NotationTBox.Text, DateTime.Parse(GetDatePicker.Text), DateTime.Parse(GetExpirationDatePicker.Text), float.Parse(PriceTBox.Text));
                resource.AddRescorceInDataBase();
                NavigationService.Navigate(new UserPage());
            }
            else
            {
                MessageBox.Show("Ошибка ввода данных!");
            }
        }
    }
}
