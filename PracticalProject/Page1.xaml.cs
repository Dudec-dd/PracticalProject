using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

using System.Data.SqlClient;
using System.Data;

namespace PracticalProject
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        User user = new User();
        public Page1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserPage());
            MessageBox.Show("123");
            /*switch (user.GetUserRole(LoginTBox.Text, PasswordTBox.Text))
            {
                case "Admin":
                    NavigationService.Navigate(new AdminPage());
                    break;
                case "Manager":
                    NavigationService.Navigate(new ManagerPage());
                    break;
                case "User":
                    NavigationService.Navigate(new UserPage());
                    break;
            }*/
        }
        
    }
}
