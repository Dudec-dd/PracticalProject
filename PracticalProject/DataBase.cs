using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace PracticalProject
{
    class DataBase
    {
        SqlConnection sqlConnection = new SqlConnection(@"Server=192.168.0.11,1433;Database=TestDb;User Id =sa; password= sa");


        public void openConnection()
        {
            if(sqlConnection.State == System.Data.ConnectionState.Closed) 
            { 
                sqlConnection.Open();
            }
        }

        public System.Data.ConnectionState showState() {
            return sqlConnection.State;
        }
        public void closeConnection()
        {
            if(sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        public SqlConnection getConnection()
        {
            return sqlConnection;   
        }

        public List<string> getListFromCommand(SqlCommand command)
        {
            this.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(dataTable);
            DataRow[] dataRows = dataTable.Select();
            List<string> list = new List<string>();
            foreach (var row in dataRows.ToArray()) { foreach (var i in row.ItemArray) list.Add(i.ToString()); }
            this.closeConnection();
            return list;
        }
    }
}
