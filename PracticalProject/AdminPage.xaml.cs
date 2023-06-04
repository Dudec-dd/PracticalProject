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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {

        public static Item gridSelectedItem { get; set; }
        public Item GetSelecktedItem()
        {
            return gridSelectedItem;
        }
        public AdminPage()
        {

            InitializeComponent();
           
        }
        

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            List<Item> list = new List<Item>();
            Item item = new Item(1, "Some Content");
            for (int i = 0; i < 25; i++)
            {
                list.Add(new Item(i, $"{i + 10}"));
            }
            list.Add(item);
            
            list.Add(new Item(5, "ewkgfd"));
            DataG.ItemsSource = list;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditPage());
            gridSelectedItem = DataG.SelectedItem as Item;
        }
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            DataG.ItemsSource = new int[1];
        }

        private void DataG_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        
    }
    public class Item
    {
        public int num { get; set; }
        public string val { get; set; }
        public Item(int n,string Val)
        {
            num = n;
            val = Val;
        }
        public Item()
        {

        }
    }

}
