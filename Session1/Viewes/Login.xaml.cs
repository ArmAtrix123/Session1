using Session1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
        Users user;
        public Login()
        {
            InitializeComponent();
            TimerSec.Interval = TimeSpan.FromSeconds(1);
            TimerSec.Tick += Reklama_Tick;
        }
        DispatcherTimer TimerSec = new DispatcherTimer();
        int attempt = 0;
        int seconds = 10;
        private void Reklama_Tick(object sender, EventArgs e)
        {

            if (seconds == 0)
            {
                seconds = 10;
                login_btn.IsEnabled = true;
                lblTime.Visibility = Visibility.Hidden;
                TimerSec.Stop();
            }
            lblTime.Content = seconds;
            seconds--;

        }
        public void Login_Button(object sender, RoutedEventArgs e)
        {
            attempt += 1;
            List<Users> users = new DataConnect().GetUsers();
            foreach (Users user in users)
            {
                if (UserName.Text == user.Email && Password.Password == user.Password)
                {
                    if (user.Active == false)
                    {
                        MessageBox.Show("Вы заблокированы");
                    }
                    else
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
                                //Делопроизводство
                                UserWindow a1 = new UserWindow(user);
                                a1.Top = this.Top;
                                a1.Left = this.Left;
                                this.Hide();
                                a1.Show();
                                break;
                        }
                    }
                } 
            }
            if (attempt >= 3)
            {
                MessageBox.Show("Подождите 10 секунд до следующей попытки");
                lblTime.Visibility = Visibility.Visible;
                login_btn.IsEnabled = false;
                TimerSec.Start();
            }
        }
        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
