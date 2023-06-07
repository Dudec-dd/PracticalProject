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
    /// Логика взаимодействия для AddSuplier.xaml
    /// </summary>
    public partial class AddSuplier : Page
    {
        public AddSuplier()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameTBox.Text != "" && AdressTBox.Text != "" && PhoneTBox.Text != "" && float.TryParse(PriceTBox.Text, out float x) && PriceTBox.Text != "" && ProductTBox.Text != "")
            {
                Suplier suplier = new Suplier(NameTBox.Text, AdressTBox.Text, PhoneTBox.Text, ProductTBox.Text, float.Parse(PriceTBox.Text));
                suplier.addSuplierInDataBase();
                NavigationService.Navigate(new ManagerPage());
                
            }
            else
            {
                MessageBox.Show("Ошибка ввода данных!", "Error");
            }
        }
    }
}
