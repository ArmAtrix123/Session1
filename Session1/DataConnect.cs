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
                    if (user.OfficeID == 1) user.Office = "Abu Dhabi";
                    if (user.OfficeID == 3) user.Office = "Cairo";
                    if (user.OfficeID == 4) user.Office = "Bahrain";
                    if (user.OfficeID == 5) user.Office = "Doha";
                    if (user.OfficeID == 6) user.Office = "Riyadh";
                    if (user.RoleID == 1) user.Role = "Administrator";
                    if (user.RoleID == 2) user.Role = "User";
                    users.Add(user);
                }
                reader.Close();
                conn.Close();
                return users;
            }
        }
        public void Add_User(Users user)
        {
            string command = "USE Session1 " +
                $"EXEC [dbo].[AddUser] '2','{user.Email}','{user.Password}','{user.FirstName}','{user.LastName}','{user.OfficeID}','{user.Birthdate}','1';";
            SqlCommand(command);
        }
        public void Edit_User(Users user)
        {
            string command = "USE Session1 " +
                $"EXEC [dbo].[Edit_User] '{user.RoleID}','{user.Email}','{user.Password}','{user.FirstName}','{user.LastName}','{user.OfficeID}','{user.Birthdate}','{user.Active}','{user.ID}';";
            SqlCommand(command);
        }
        public List<Countries> GetCountries()
        {
            string command = "USE Session1 " +
                "select * from [Countries]";
            List<Countries> counts = new List<Countries>();
            using (SqlConnection conn
                = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    Countries count = new Countries();
                    count.ID = reader.GetInt32(0);
                    count.Name = reader.GetString(1);
                    counts.Add(count);
                }
                reader.Close();
                conn.Close();
                return counts;
            }
        }
        public List<Offices> GetOffices()
        {
            string command = "USE Session1 " +
                "select * from [Offices]";
            List<Offices> offs = new List<Offices>();
            using (SqlConnection conn
                = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    Offices off = new Offices();
                    off.ID = reader.GetInt32(0);
                    off.CountryID = reader.GetInt32(1);
                    off.Title = reader.GetString(2);
                    off.Phone = reader.GetString(3);
                    off.Contact = reader.GetString(4);
                    offs.Add(off);
                }
                reader.Close();
                conn.Close();
                return offs;
            }
        }
        public List<Roles> GetRoles()
        {
            string command = "USE Session1 " +
                "select * from [Roles]";
            List<Roles> rols = new List<Roles>();
            using (SqlConnection conn
                = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    Roles role = new Roles();
                    role.ID = reader.GetInt32(0);
                    role.Title = reader.GetString(1);
                    rols.Add(role);
                }
                reader.Close();
                conn.Close();
                return rols;
            }
        }

    }
}
