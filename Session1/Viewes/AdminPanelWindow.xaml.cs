using Session1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Session1.Viewes
{
    /// <summary>
    /// Логика взаимодействия для AdminPanelWindow.xaml
    /// </summary>
    public partial class AdminPanelWindow : Window
    {
        Users user;
        List<Users> users = new List<Users>();
        List<Roles> roleses = new List<Roles>();
        List<Offices> officeses = new List<Offices>();
        public AdminPanelWindow(Users sended)
        {
            InitializeComponent();
            sended = user;
            Fill();
        }
        public void Fill(bool Reupload_List = true)
        {
            if (Reupload_List != false)
            {
                users.Clear();
                users = new DataConnect().GetUsers();
            }
            Data_User.ItemsSource = users;
            roleses = new DataConnect().GetRoles();
            officeses = new DataConnect().GetOffices();
        }

        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Add_User a1 = new Add_User(user);
            a1.Top = this.Top;
            a1.Left = this.Left;
            this.Hide();
            a1.Show();
        }
        List<Users> usr = new List<Users>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Users user = new Users();
            user.ID = users[Data_User.SelectedIndex].ID;
            user.RoleID = users[Data_User.SelectedIndex].RoleID;
            user.Email = users[Data_User.SelectedIndex].Email;
            user.Password = users[Data_User.SelectedIndex].Password;
            user.FirstName = users[Data_User.SelectedIndex].FirstName;
            user.LastName = users[Data_User.SelectedIndex].LastName;
            user.OfficeID = users[Data_User.SelectedIndex].OfficeID;
            user.Birthdate = users[Data_User.SelectedIndex].Birthdate;
            user.Active = users[Data_User.SelectedIndex].Active;
            if (user.Active == false)
            {
                user.Active = true;
            } else if (user.Active == true)
            {
                user.Active = false;
            }
            new DataConnect().Edit_User(user);
            Fill();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Users userek = new Users();
            userek.ID = users[Data_User.SelectedIndex].ID;
            userek.RoleID = users[Data_User.SelectedIndex].RoleID;
            userek.Email = users[Data_User.SelectedIndex].Email;
            userek.Password = users[Data_User.SelectedIndex].Password;
            userek.FirstName = users[Data_User.SelectedIndex].FirstName;
            userek.LastName = users[Data_User.SelectedIndex].LastName;
            userek.OfficeID = users[Data_User.SelectedIndex].OfficeID;
            userek.Birthdate = users[Data_User.SelectedIndex].Birthdate;
            userek.Active = users[Data_User.SelectedIndex].Active;

            Edit_Role a1 = new Edit_Role(user, userek);
            a1.Top = this.Top;
            a1.Left = this.Left;
            this.Hide();
            a1.Show();

        }
    }
}
