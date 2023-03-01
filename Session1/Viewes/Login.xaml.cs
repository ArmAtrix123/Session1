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
using System.Windows.Threading;

namespace Session1.Viewes
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        int attempt = 0;
        int seconds = 10;
        private void dtTicker(object sender, EventArgs e)
        {
            seconds--;
            lblTime.Content = seconds.ToString();
        }
        private void Login_Button(object sender, RoutedEventArgs e)
        {
            List<Users> users = new DataConnect().GetUsers();
            foreach (Users user in users)
            {
                if (UserName.Text == user.Email && Password.Password == user.Password && attempt <= 3)
                {
                    switch (user.RoleID)
                    {
                        case 1:
                            //Админ панель
                            AdminPanelWindow a = new AdminPanelWindow(user);
                            a.Top = this.Top;
                            a.Left = this.Left;
                            this.Hide();
                            a.Show();
                            break;
                        case 2:
                            //Пользователь
                            UserWindow a1 = new UserWindow(user);
                            a1.Top = this.Top;
                            a1.Left = this.Left;
                            this.Hide();
                            a1.Show();
                            break;
                    }
                }
                else
                {
                    attempt += 1;
                    if (attempt >= 4)
                    {
                        DispatcherTimer dt = new DispatcherTimer();
                        dt.Interval = TimeSpan.FromSeconds(1);
                        dt.Tick += dtTicker;
                        dt.Start();
                        login_btn.IsEnabled = false;
                        if (seconds == 1)
                        {
                            dt.Stop();
                        }
                    }
                    break;
                }
            }
        }
        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
