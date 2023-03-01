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
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        Users user;
        List<Users> users = new List<Users>();
        public UserWindow(Users sended)
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
            roles = new Connect().GetRole();
            ChangeRole.ItemsSource = roles;
        }
    }
}
