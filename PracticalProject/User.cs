using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace PracticalProject
{
    internal class User
    {
        public string name { get; set; }
        public string surename { get; set; }
        public string birthdayDate { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public static List<User> users = new List<User>();
        public static User CurrentUser;
        public static Event EventToAdd;
        public static Event EventToEdit;
        public Dictionary<string, int> UserScore;
        public User(string n, string sN, DateTime birthD, string l, string psw, string r)
        {
            name = n;
            surename = sN;
            birthdayDate = birthD.Date.ToString("yyyy-MM-dd");
            login = l;
            password = psw;
            role = r;
        }

        public User()
        {
        }
        public User FindUser(string login, string password)
        {
            foreach (var user in User.users)
            {
                if (user.login == login && user.password == password)
                {
                    return user;
                }
            }
            return new User();
        }
        public bool IsUserInDB(string login,string password)
        {
            foreach (var user in users)
            {
                if(user.login == login && user.password == password)
                {
                    return true;
                }
            }
            return false;
        }
        public static User GetUser(string login)
        {
            foreach (var item in User.users)
            {
                if (item.login == login)
                {
                    return item;
                }
            }
            return null;
        }
        
        public static List<User> GetListOfOrgs()
        {
            List<User> users = new List<User>();
            foreach (var item in User.users)
            {
                if (item.role == "Org")
                {
                    users.Add(item);
                }
            }
            return users;
        }
        public static List<User> GetListOfJury()
        {
            List<User> users = new List<User>();
            foreach(var item in User.users)
            {
                if(item.role == "Jury")
                {
                    users.Add(item);
                }
            }
            return users;

        }
        public void addUserInDataBase()
        {
            if (IsUserInDB(login, password))
            {
                MessageBox.Show("Такой пользователь уже имеется!");
                return;
            }
            else
            {
                users.Add(this);
            }
        }
        public void removeUserFromDataBase(string login, string password)
        {   
            if(IsUserInDB(login,password)) users.Remove(FindUser(login, password));

        }
        public string GetUserRole(string login,string password)
        {
            if (IsUserInDB(login, password))
            {
                foreach(var user in users)
                {
                    if (user.login == login && user.password == password)
                    {
                        return user.role;
                    }
                }
                MessageBox.Show("Введён не верный логин или пароль!");
                return "";
            }
            else
            {
                MessageBox.Show("Введён не верный логин или пароль!");
                return "";
            }
        }

        public void AddUserScore(string ActivityName,int Score)
        {
            UserScore.Add(ActivityName,Score);
        }
        
        public int GetUserCount()
        {
            return users.Count();
        }
    }
}
