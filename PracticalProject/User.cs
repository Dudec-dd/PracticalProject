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
        public DateTime birthdayDate { get; set; }
        public string log { get; set; }
        public string password {get; set; }
        public string role { get; set; }

        public User(string n,string sN, DateTime birthD,string l,string psw,string r)
        {
            name = n;
            surename = sN;
            birthdayDate = birthD;
            log = l;
            password = psw;
            role = r;
        }
        public void addUserInDataBase()
        {
            DataBase dataBase = new DataBase();
            string sqlFormattedDate = birthdayDate.Date.ToString("yyyy-MM-dd");
            string regstring = $"insert into Users(UserID, Name, Surname, BirthdayDate, Login, Password, Role) values ({LengthOfUsersTable()+1},'{name}', '{surename}', '{sqlFormattedDate}', '{log}', '{password}', '{role}')";
            SqlCommand cmd = new SqlCommand(regstring, dataBase.getConnection());
            dataBase.openConnection();
            if (cmd.ExecuteNonQuery() == 1) { MessageBox.Show("Done"); }
            else { MessageBox.Show("error"); }
            dataBase.closeConnection();
        }
        public Boolean IsUserInDataBase(string login, string pass)
        {
            DataBase dataBase = new DataBase();
            string reqstring = $"select * from Users where login = '{login}' AND password = '{pass}'";
            SqlCommand cmd = new SqlCommand(reqstring,dataBase.getConnection());
            dataBase.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();
            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);
            dataBase.closeConnection();
            if(dataTable.Rows.Count > 0)
            {
                return true;
            }
            else
            return false;
        }
        public List<User> GetListOfAllUsers()
        {

            List<User> users = new List<User>();
            return users;
        }
        public int LengthOfUsersTable()
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
