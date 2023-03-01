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
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Add_User a1 = new Add_User(user);
            a1.Top = this.Top;
            a1.Left = this.Left;
            this.Hide();
            a1.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
