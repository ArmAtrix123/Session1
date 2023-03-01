using Session1.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Session1
{
    class DataConnect
    {
        public string ConnectionString { get; set; } = @"Persist Security Info=False;Integrated Security=true; Initial Catalog=Session1;Server=ARMATRIX\SQLEXPRESS";

        public void SqlCommand(string request, bool AdminRequest = false, string Message = "")
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(request, conn);
                    cmd.ExecuteScalar();
                    conn.Close();
                }
                if (AdminRequest)
                    MessageBox.Show("Действие выполненно успешно");
                if (Message != "")
                    MessageBox.Show(Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка! {ex}");
            }
        }
        public List<Users> GetUsers()
        {
            string command = "USE Session1 " +
                "select * from [Users]";
            List<Users> users = new List<Users>();
            using (SqlConnection conn
                = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    Users user = new Users();
                    user.ID = reader.GetInt32(0);
                    user.RoleID = reader.GetInt32(1);
                    user.Email = reader.GetString(2);
                    user.Password = reader.GetString(3);
                    user.FirstName = reader.GetString(4);
                    user.LastName = reader.GetString(5);
                    user.OfficeID = reader.GetInt32(6);
                    user.Birthdate = reader.GetDateTime(7);
                    user.Active = reader.GetBoolean(8);
                    users.Add(user);
                }
                reader.Close();
                conn.Close();
                return users;
            }
        }
    }
}
