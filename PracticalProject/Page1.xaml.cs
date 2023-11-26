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
        //NavigationService.Navigate(new UserPage());
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(user.IsUserInDB(LoginTBox.Text, PasswordTBox.Text))
                User.CurrentUser = user.FindUser(LoginTBox.Text, PasswordTBox.Text);
            switch (user.GetUserRole(LoginTBox.Text, PasswordTBox.Text))
            {
                case "Org":
                    NavigationService.Navigate(new AdminPage());
                    break;
                case "Moderator":
                    NavigationService.Navigate(new ManagerPage());
                    break;
                case "User":
                    NavigationService.Navigate(new UserPage());
                    break;
                case "Jury":
                    NavigationService.Navigate(new UserPage());
                    break;
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
