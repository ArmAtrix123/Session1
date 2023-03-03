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
    /// Логика взаимодействия для Add_User.xaml
    /// </summary>
    public partial class Add_User : Window
    {
        Users user;
        List<Users> users = new List<Users>();
        List<Roles> roleses = new List<Roles>();
        List<Offices> officeses = new List<Offices>();
        public Add_User(Users sended)
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string office = Change_Office.SelectedValue.ToString();
            int OfficeID = 0;
            if (office == "System.Windows.Controls.ComboBoxItem: Abu Dhabi")
                OfficeID = 1;
            else if (office == "System.Windows.Controls.ComboBoxItem: Cairo")
                OfficeID = 2;
            else if (office == "System.Windows.Controls.ComboBoxItem: Bahrain")
                OfficeID = 3;
            else if (office == "System.Windows.Controls.ComboBoxItem: Doha")
                OfficeID = 4;
            else if (office == "System.Windows.Controls.ComboBoxItem: Riyadh")
                OfficeID = 5;
            if (String.IsNullOrWhiteSpace(Email.Text) == true && String.IsNullOrWhiteSpace(FirstName.Text) == true && String.IsNullOrWhiteSpace(Last_Name.Text) == true && String.IsNullOrWhiteSpace(Change_Office.Text) == true && String.IsNullOrWhiteSpace(Birthdate.Text) == true && String.IsNullOrWhiteSpace(Password.Text) == true)
                MessageBox.Show("Вы не заполнили какие-то поля \n Пожайлуста заполните хотя-бы одно");
            else
            {
                new DataConnect().Add_User(new Users(0, 2, Email.Text, Password.Text, FirstName.Text, Last_Name.Text, users[Change_Office.SelectedIndex].ID, Convert.ToDateTime(Birthdate.Text), Convert.ToBoolean(1)));
                Fill();
                AdminPanelWindow a1 = new AdminPanelWindow(user);
                a1.Top = this.Top;
                a1.Left = this.Left;
                this.Hide();
                a1.Show();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AdminPanelWindow a1 = new AdminPanelWindow(user);
            a1.Top = this.Top;
            a1.Left = this.Left;
            this.Hide();
            a1.Show();
        }
    }
}
