﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Xml.Linq;

namespace PracticalProject
{
    internal class Suplier
    {
        public string organizationName { get; set; }
        public string adress { get; set; }
        public string phoneNumber { get; set; }
        public string rescource { get; set; }
        public float price { get; set; }

        public Suplier(string orgName, string a, string pNum, string resc, float p)
        {
            organizationName = orgName;
            adress = a;
            phoneNumber = pNum;
            rescource = resc;
            price = p;
        }
        public Suplier() { }
        public List<Suplier> GetListOfAllSupliers()
        {
            DataBase dataBase = new DataBase();
            List<Suplier> Supliers = new List<Suplier>();
            string reqstring = $"select * from Supliers";
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

                Supliers[j] = new Suplier(list[0], list[1], list[2], list[3], float.Parse(list[4]));
            }
            return Supliers;
        }
        public void addSuplierInDataBase()
        {
            DataBase dataBase = new DataBase();
            if (this.IsSuplierInDataBase(organizationName, adress))
            {
                MessageBox.Show("Такой пользователь уже имеется!");
                return;
            }
            else
            {
                string regstring = $"insert into Suplier(SuplierID, OrganizationName, Adress, PhoneNumber, Rescource, Price) values ({GetSuplierCount() + 1},'{organizationName}', '{adress}', '{phoneNumber}', '{rescource}', {price})";
                SqlCommand cmd = new SqlCommand(regstring, dataBase.getConnection());
                dataBase.openConnection();
                if (cmd.ExecuteNonQuery() == 1) { MessageBox.Show("Done"); }
                else { MessageBox.Show("error"); }
                dataBase.closeConnection();
            }
        }
        public Boolean IsSuplierInDataBase(string orgname, string adress)
        {
            DataBase dataBase = new DataBase();
            string reqstring = $"select * from Suplier where login = '{orgname}' AND password = '{adress}'";
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
        public int GetSuplierCount()
        {
            DataBase dataBase = new DataBase();
            string reqstring = $"select * from Supliers";
            SqlCommand cmd = new SqlCommand(reqstring, dataBase.getConnection());
            dataBase.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();
            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);
            dataBase.closeConnection();
            return dataTable.Rows.Count;
        }
        public void removeUserFromDataBase(string orgname, string resc)
        {
            DataBase dataBase = new DataBase();
            string reqstring = $"DELETE FROM Supliers WHERE login = '{orgname}' AND password ='{resc}' LIMIT 1;";
            SqlCommand cmd = new SqlCommand(reqstring, dataBase.getConnection());
        }
    }
}