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
    /// Логика взаимодействия для AddEventAndActivity.xaml
    /// </summary>
    public partial class AddEventAndActivity : Page
    {
        List<User> users = User.GetListOfJury();

        public AddEventAndActivity()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(NameTBox.Text !="" &&  ThemeTBox.Text != "")
            {
                Event ev = new Event(NameTBox.Text, ThemeTBox.Text,User.GetUser(JuryCBox.SelectedItem.ToString()),User.CurrentUser);
                if (ActivList.Text != "") { 
                List<string> activities = ActivList.Text.Split(',').ToList<string>();
                foreach(var item in activities)
                    {
                        ev.EventActivities.Add(new Activity(item, item));
                    }
                }
                MessageBox.Show("Готово!");
                NavigationService.GoBack();
                return;
            }
            MessageBox.Show("Ошибка!");
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> strings = new List<string>();
            foreach (var item in users)
            {
                strings.Add(item.login);
            }
            JuryCBox.ItemsSource = strings;
            JuryCBox.SelectedIndex = 0;
        }

        private void NameTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (NameTBox.Text == "Название") NameTBox.Text = "";
        }

        private void ThemeTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (ThemeTBox.Text == "Тема") ThemeTBox.Text = "";
        }
    }
}
