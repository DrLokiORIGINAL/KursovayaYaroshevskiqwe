using KursovayaYaroshevski.ClassFolder;
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

namespace KursovayaYaroshevski.WindowFolder.ManagerFolder.ManagerPFolder
{
    /// <summary>
    /// Логика взаимодействия для ManagerPWindow.xaml
    /// </summary>
    public partial class ManagerPWindow : Window
    {
        public ManagerPWindow()
        {
            InitializeComponent();
        }

        private void Close_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MBClass.QestionMB("Вы действительно хотите выйти из аккаунта?"))
            {
                new AuthorizationWindow().Show();
                Close();
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ListStaffBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddStaffBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ListHelperBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddHelperBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
