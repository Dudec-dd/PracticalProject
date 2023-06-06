using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PracticalProject
{
    internal class Resource
    {
        public static Resource selectedRescource { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public string notation { get; set; }
        public string getDate { get; set; }
        public string expirationDate { get; set; }
        public float price { get; set; }
        public Resource() { }
        public void SetSelectedRescource(Resource res)
        {
            selectedRescource = res;
        }
        public Resource GetSelectedRescource()
        {
            return selectedRescource;
        }
        public Resource(string name, int quantity, string notation, DateTime getDate, DateTime expirationDate, float price)
        {
            this.name = name;
            this.quantity = quantity;
            this.notation = notation;
            this.getDate = getDate.Date.ToString("yyyy-MM-dd");
            this.expirationDate = expirationDate.Date.ToString("yyyy-MM-dd");
            this.price = price;
        }
        public void removeResourceFromDataBase(string name, int count)
        {
            if (selectedRescource.quantity == count)
            {
                DataBase dataBase = new DataBase();
                string reqstring = $"DELETE FROM Resources WHERE name = '{name}' AND quantity ='{count}' LIMIT 1;";
                SqlCommand cmd = new SqlCommand(reqstring, dataBase.getConnection());
            }
            else if (selectedRescource.quantity > count)
            {
                DataBase dataBase = new DataBase();
                string reqstring = $"UPDATE Resources SET quantity = {selectedRescource.quantity - count} WHERE name = '{name}' AND quantity ='{count}' LIMIT 1;";
                SqlCommand cmd = new SqlCommand(reqstring, dataBase.getConnection());
            }
            else
            {
                MessageBox.Show("Нельзя уменьшить значение меньше 0!");
            }
        }

        public void AddRescorceInDataBase()
        {
            DataBase dataBase = new DataBase();
            string regstring = $"insert into Resources(ResourceID, Name, quantity, notation, getDate, expirationDate, price) values ({GetResourcesCount() + 1},'{name}', {quantity}, '{notation}', '{getDate}', '{expirationDate}', {price})";
            SqlCommand cmd = new SqlCommand(regstring, dataBase.getConnection());
            dataBase.openConnection();
            if (cmd.ExecuteNonQuery() == 1) { MessageBox.Show("Done"); }
            else { MessageBox.Show("error"); }
            dataBase.closeConnection();
        }
        public int GetResourcesCount()
        {
            DataBase dataBase = new DataBase();
            string reqstring = $"select * from Resources";
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
