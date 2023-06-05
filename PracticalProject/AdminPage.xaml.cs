using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Data.SqlTypes;

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
            
            var ndate = new DateTime(2004, 6, 19);
            User user = new User("Andrew", "Zvyagin", ndate, "Phoenix", "123", "admin");
            if (user.IsUserInDataBase("Phoenix","123")) MessageBox.Show("Такой пользователь уже есть в системе!");
            else user.addUserInDataBase();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditPage());
            gridSelectedItem = DataG.SelectedItem as Item;
        }
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            DataBase dataBase = new DataBase();
            
            string selstring = $"select Name, Surname from Login where Name = '4325' AND Surname = '34645'";
            SqlCommand sqlcmd = new SqlCommand(selstring, dataBase.getConnection());
            
            List<string> a = dataBase.getListFromCommand(sqlcmd); 
            somebox.Text = a[0];
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();
            adapter.SelectCommand = sqlcmd;
            adapter.Fill(dataTable);
            DataG.ItemsSource = dataTable.Select();
        }

        private void DataG_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        
    }
    public class Item
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        
    }

}
