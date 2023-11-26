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
    /// Логика взаимодействия для AddUserToEvent.xaml
    /// </summary>
    public partial class AddUserToEvent : Page
    {
        
        public AddUserToEvent()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserToShow u = DataG.SelectedItem as UserToShow;
            User.EventToAdd.AddUserToEvent(User.GetUser(u.login));
           
            NavigationService.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            List<UserToShow> usersToShow = new List<UserToShow>();
            foreach(var item in User.users)
            {
                usersToShow.Add(new UserToShow(item.name,item.surename,item.birthdayDate,item.login));
            }
            DataG.ItemsSource = usersToShow;
        }
    }
}
