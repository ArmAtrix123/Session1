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
    /// Логика взаимодействия для Edit_Role.xaml
    /// </summary>
    public partial class Edit_Role : Window
    {
        Users user;
        Users userek;
       
        List<Offices> ofik = new List<Offices>();
        List<Users> users = new List<Users>();


        public Edit_Role(Users user123, Users userek321)
        {
            InitializeComponent();
            user = user123;
            userek = userek321;
            Fill();
        }
        public void Fill(bool Reupload_List = true)
        {
            if (Reupload_List != false)
            {
                users = new DataConnect().GetUsers();
            }
            Email.Text = userek.Email;
            FirstName.Text = userek.FirstName;
            Last_Name.Text = userek.LastName;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string office = Change_Office.SelectedValue.ToString();
            if (office == "System.Windows.Controls.ComboBoxItem: Abu Dhabi")
                userek.OfficeID = 1;
            else if (office == "System.Windows.Controls.ComboBoxItem: Cairo")
                userek.OfficeID = 2;
            else if (office == "System.Windows.Controls.ComboBoxItem: Bahrain")
                userek.OfficeID = 3;
            else if (office == "System.Windows.Controls.ComboBoxItem: Doha")
                userek.OfficeID = 4;
            else if (office == "System.Windows.Controls.ComboBoxItem: Riyadh")
                userek.OfficeID = 5;
            userek.ID = userek.ID;
            userek.RoleID = userek.RoleID;
            if (UserCheck.IsChecked == true && userek.RoleID == 1)
            {
                userek.RoleID = 2;
            }
            else if (UserCheck.IsChecked == true && userek.RoleID == 2)
            {
                MessageBox.Show("Этот пользователь уже User");
            }
            else if (AdminCheck.IsChecked == true && userek.RoleID == 2)
            {
                userek.RoleID = 1;
            }
            else if (AdminCheck.IsChecked == true && userek.RoleID == 1)
            {
                MessageBox.Show("Этот пользователь уже Admin");
            }
            userek.Email = Email.Text;
            userek.Password = userek.Password;
            userek.FirstName = FirstName.Text;
            userek.LastName = Last_Name.Text;
            userek.Birthdate = userek.Birthdate;
            userek.Active = userek.Active;
            new DataConnect().Edit_User(userek);
            Fill();

            AdminPanelWindow a1 = new AdminPanelWindow(user);
            a1.Top = this.Top;
            a1.Left = this.Left;
            this.Hide();
            a1.Show();
        }
    }
}
