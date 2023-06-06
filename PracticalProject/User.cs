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

        public void addUserInDataBase()
        {
            DataBase dataBase = new DataBase();
            if (this.IsUserInDataBase(login, password))
            {
                MessageBox.Show("Такой пользователь уже имеется!");
                return;
            }
            else
            {
                string regstring = $"insert into Users(UserID, Name, Surname, BirthdayDate, Login, Password, Role) values ({GetUserCount() + 1},'{name}', '{surename}', '{birthdayDate}', '{login}', '{password}', '{role}')";
                SqlCommand cmd = new SqlCommand(regstring, dataBase.getConnection());
                dataBase.openConnection();
                if (cmd.ExecuteNonQuery() == 1) { MessageBox.Show("Done"); }
                else { MessageBox.Show("error"); }
                dataBase.closeConnection();
            }
        }
        public void removeUserFromDataBase(string login, string password)
        {
            DataBase dataBase = new DataBase();
            string reqstring = $"DELETE FROM users WHERE login = '{login}' AND password ='{password}' LIMIT 1;";
            SqlCommand cmd = new SqlCommand(reqstring,dataBase.getConnection());
        }
        public Boolean IsUserInDataBase(string login, string pass)
        {
            DataBase dataBase = new DataBase();
            string reqstring = $"select * from Users where login = '{login}' AND password = '{pass}'";
            SqlCommand cmd = new SqlCommand(reqstring, dataBase.getConnection());
            dataBase.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();
            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);
            dataBase.closeConnection();
            if (dataTable.Rows.Count > 0)
            {
                return true;
            }
            else
                return false;
        }
        public string GetUserRole(string login,string password)
        {
            if (this.IsUserInDataBase(login, password))
            {
                DataBase dataBase = new DataBase();
                string reqstring = $"select * from Users where login = '{login}' AND password = '{password}'";
                SqlCommand cmd = new SqlCommand(reqstring, dataBase.getConnection());
                dataBase.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable dataTable = new DataTable();
                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
                dataBase.closeConnection();
                int[,] ints = new int[3,3];
                return dataTable.Rows[0][6].ToString();
            }
            else
            {
                MessageBox.Show("Введён не верный логин или пароль!");
                return "";
            }
        }
        public List<User> GetListOfAllUsers()
        {
            DataBase dataBase = new DataBase();
            List<User> users = new List<User>();
            string reqstring = $"select * from Users";
            SqlCommand cmd = new SqlCommand(reqstring, dataBase.getConnection());
            dataBase.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();
            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);
            dataBase.closeConnection();
            for (int j = 0; j < dataTable.Rows.Count; j++)
            {
                DataRow row = dataTable.Rows[j];
                List<string> list = new List<string>();
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    list[i] = row.ItemArray[i].ToString();
                }

                users[j] = new User(list[0], list[1], DateTime.Parse(list[2]), list[3], list[4], list[5]);
            }
            return users;
        }
        public int GetUserCount()
        {
            DataBase dataBase = new DataBase();
            string reqstring = $"select * from Users";
            SqlCommand cmd = new SqlCommand(reqstring, dataBase.getConnection());
            dataBase.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();
            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);
            dataBase.closeConnection();
            return dataTable.Rows.Count;
        }
    }
}
