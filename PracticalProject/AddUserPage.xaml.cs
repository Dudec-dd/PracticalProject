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
    /// Логика взаимодействия для AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        public AddUserPage()
        {
            InitializeComponent();
        }

        private void NameTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (NameTBox.Text == "Введите имя")
                NameTBox.Text = "";
        }

        private void SurNameTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SurNameTBox.Text == "Введите фамилию")
                SurNameTBox.Text = "";
        }

        private void LoginTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (LoginTBox.Text == "Введите логин" || LoginTBox.Text == "Такой логин уже имеется")
                LoginTBox.Text = "";
        }

        private void PasswordTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordTBox.Text == "Введите пароль")
                PasswordTBox.Text = "";
        }

        private void NameTBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (NameTBox.Text == "") NameTBox.Text = "Введите имя";
        }

        private void SurNameTBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (SurNameTBox.Text == "") SurNameTBox.Text = "Введите фамилию";
        }

        private void LoginTBox_LostFocus(object sender, RoutedEventArgs e)
        {
            foreach (var item in User.users)
            {
                if (item.login == LoginTBox.Text)
                {
                    LoginTBox.Text = "Такой логин уже имеется";
                }
            }
            if (LoginTBox.Text == "") LoginTBox.Text = "Введите логин";
        }

        private void PasswordTBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordTBox.Text == "") PasswordTBox.Text = "Введите пароль";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (NameTBox.Text != "" && SurNameTBox.Text != "" && DateTBox.Text != "" && LoginTBox.Text != ""&& LoginTBox.Text!= "Такой логин уже имеется" && PasswordTBox.Text != "" && roleCBox.SelectedItem.ToString() != "")
            {
                User user = new User(NameTBox.Text, SurNameTBox.Text, DateTime.Parse(DateTBox.Text), LoginTBox.Text, PasswordTBox.Text, roleCBox.SelectedItem.ToString());
                user.addUserInDataBase();
                MessageBox.Show("Готово!");
            }
            else
            {
                MessageBox.Show("Ошибка ввода данных!", "Error");

            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> strings = new List<string>();
            strings.Add("User");
            strings.Add("Moderator");
            strings.Add("Org");
            strings.Add("Jury");
            roleCBox.ItemsSource = strings;
            roleCBox.SelectedIndex = 0;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
