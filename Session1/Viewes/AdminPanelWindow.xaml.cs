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
        public AdminPanelWindow(Users sended)
        {
            InitializeComponent();
            sended = user;
            // Fill();
        }

        public void Fill(bool Reupload_List = true)
        {
            //if (Reupload_List != false)
            //{
            //    dogovors.Clear();
            //    dogovors = new Connect().GetDogovor();
            //}
            //Data_Dogovor.ItemsSource = dogovors;
            //rezumes = new Connect().GetRezume();
            //ChangeRezume.ItemsSource = rezumes;
        }
    }
}
