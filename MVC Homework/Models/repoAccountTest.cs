using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVC_Homework.Models
{
    public class repoAccountTest
    {
        //連線字串
        string strConn = ConfigurationManager.ConnectionStrings["LoginDB"].ConnectionString;
        private string strConnection = @"Data Source=.\;Initial Catalog=G:\PROJECTS\WEBAPPLICATION1\WEBAPPLICATION1\APP_DATA\客戶資料.MDF;Persist Security Info=False;Integrated Security=SSPI;";

        //抓模型
        
        public IEnumerable<Accounts> GetAll()
        {
            List<Accounts> _list = new List<Accounts>();

            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                sqlConnection.Open();
                SqlCommand sqlCmd = new SqlCommand(@"SELECT [AccountName] ,[Password],[RegisteredDate] FROM [G:\PROJECTS\WEBAPPLICATION1\WEBAPPLICATION1\APP_DATA\客戶資料.MDF].[dbo].[Login]", sqlConnection);

                SqlDataReader reader = sqlCmd.ExecuteReader();
                //int _FieldCount = 0;
                //string[] _item = null;


                while (reader.Read())
                {
                    Accounts _Account = new Accounts();
                    _Account.Registered = (DateTime)reader["RegisteredDate"];
                    _Account.Name = reader["AccountName"].ToString();
                    _Account.password = reader["Password"].ToString();

                    _list.Add(_Account);
                }

                sqlConnection.Close();
            }
            return _list;
        }


       

    }
}