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
        public string suplier { get; set; }
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
        public Resource(string name, int quantity, string notation,string suplier, DateTime getDate, DateTime expirationDate, float price)
        {
            this.name = name;
            this.quantity = quantity;
            this.notation = notation;
            this.suplier = suplier;
            this.getDate = getDate.Date.ToString("yyyy-MM-dd");
            this.expirationDate = expirationDate.Date.ToString("yyyy-MM-dd");
            this.price = price;
        }
        public void removeResourceFromDataBase(string name, int count)
        {
            if (selectedRescource.quantity == count)
            {
                DataBase dataBase = new DataBase();
                string reqstring = $"DELETE FROM Resources WHERE name = '{name}' AND quantity ='{count}'";
                SqlCommand cmd = new SqlCommand(reqstring, dataBase.getConnection());
                dataBase.openConnection();
                cmd.ExecuteNonQuery();
                dataBase.closeConnection();
            }
            else if (selectedRescource.quantity > count)
            {
                DataBase dataBase = new DataBase();
                string reqstring = $"UPDATE Resources SET quantity = '{selectedRescource.quantity - count}' WHERE name = '{name}' AND quantity ='{selectedRescource.quantity}'";
                SqlCommand cmd = new SqlCommand(reqstring, dataBase.getConnection());
                dataBase.openConnection();
                cmd.ExecuteNonQuery();
                dataBase.closeConnection();
            }
            else
            {
                MessageBox.Show("Нельзя уменьшить значение меньше 0!");
            }
        }

        public void AddRescorceInDataBase()
        {
            DataBase dataBase = new DataBase();
            string regstring = $"insert into Resources(ResourceID, Name, quantity, notation,suplier, getDate, expirationDate, price) values ({GetResourcesCount() + 1},'{name}', {quantity}, '{notation}','{suplier}', '{getDate}', '{expirationDate}', {price})";
            SqlCommand cmd = new SqlCommand(regstring, dataBase.getConnection());
            dataBase.openConnection();
            cmd.ExecuteNonQuery();
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
        public List<Resource> GetListOfAllResources()
        {
            DataBase dataBase = new DataBase();
            List<Resource> resources = new List<Resource>();
            string reqstring = $"select * from Resources";
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
                for (int i = 1; i < row.ItemArray.Length; i++)
                {
                    list.Add(row.ItemArray[i].ToString());
                }

                resources.Add(new Resource(list[0], Int32.Parse(list[1]), list[2], list[3], DateTime.Parse(list[4]), DateTime.Parse(list[5]), float.Parse(list[6])));
            }
            return resources;
        }
    }
}
