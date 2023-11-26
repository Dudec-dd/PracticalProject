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
using Microsoft.SqlServer.Server;

namespace PracticalProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new AddPage();
            DateTime dateTime = DateTime.Now;
            User.users.Add(new User("igor", "igorev", dateTime, "Login", "321", "Jury"));
            User.users.Add(new User("Egor", "igorev", dateTime, "Login", "312", "Moderator"));
            User.users.Add(new User("Vanya", "igorev", dateTime, "Login", "132", "User"));
            User.users.Add(new User("Lena", "igorev", dateTime, "Login", "123", "Org"));

            new Event("A", "Games", User.users[0], User.users[3]);
            Event.Events[0].AddModeratorToEvent(User.users[1]);
            Event.Events[0].AddUserToEvent(User.users[2]);
            Event.Events[0].AddUserToEvent(User.users[3]);


        }
    }
}
