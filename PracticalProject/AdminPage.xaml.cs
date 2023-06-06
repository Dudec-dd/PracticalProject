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

        
        public AdminPage()
        {

            InitializeComponent();
        }
        

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddUserPage());
        }
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if(DataG.SelectedItem != null) { 
            User selectedUser = DataG.SelectedItem as User;
            selectedUser.removeUserFromDataBase(selectedUser.login,selectedUser.password);
            MessageBox.Show("Пользователь удалён!");
            }
            else
            {
                MessageBox.Show("Выберите значение в таблице");
            }
        }

        

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            User user = new User();
            //DataG.ItemsSource = user.GetListOfAllUsers();
        }
    }

}
