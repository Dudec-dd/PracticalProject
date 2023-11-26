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
    /// Логика взаимодействия для ManagerPage.xaml
    /// </summary>
    public partial class ManagerPage : Page
    {
        public ManagerPage()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            EventToShow even = DataG.SelectedItem as EventToShow;
            if (even != null)
            {
                Event ev = Event.GetEventByName(even.Название);
                User.EventToAdd = ev;
            }
            NavigationService.Navigate(new AddUserToEvent());
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            DataG.ItemsSource = Event.ShowEvents();
        }

        private void RemButton_Click(object sender, RoutedEventArgs e)
        {

            EventToShow even = DataG.SelectedItem as EventToShow;       
            if (even != null)
            {
                Event ev = Event.GetEventByName(even.Название);
                ev.AddModeratorToEvent(User.CurrentUser);
            }
            DataG.ItemsSource = Event.ShowEvents();
        }
    }
}
