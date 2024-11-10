using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btlLTTQ.Classes
{
    internal class DataBaseProcess
    {
        string strConnect = "Data Source=HP\\SQLEXPRESS;" +
            "DataBase=QuanLySieuthi; User ID = sa;" +
            "Password=;Integrated Security=false";
        SqlConnection sqlConnect = null;

        void OpentConnect()
        {
            sqlConnect = new SqlConnection(strConnect);
            if (sqlConnect.State != System.Data.ConnectionState.Open)
            {
                sqlConnect.Open();
            }
        }
        void CloseConnect()
        {
            if (sqlConnect.State!= System.Data.ConnectionState.Closed)
            {
                sqlConnect.Close();
                sqlConnect.Dispose();
            }
        }
        public DataTable DataReader(string str)
        {
            DataTable dt = new DataTable();
            OpentConnect();
            SqlDataAdapter sqldata = new SqlDataAdapter(str,sqlConnect);
            sqldata.Fill(dt);
            CloseConnect();
            return dt;
        }
        public void DataChange(string str)
        {
            OpentConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnect;
            cmd.CommandText = str;
            cmd.ExecuteNonQuery();
        }
    }
}
