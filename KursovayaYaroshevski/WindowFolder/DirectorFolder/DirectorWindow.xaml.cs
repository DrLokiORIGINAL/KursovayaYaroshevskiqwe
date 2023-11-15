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

namespace KursovayaYaroshevski.WindowFolder.DirectorFolder
{
    /// <summary>
    /// Логика взаимодействия для DirectorWindow.xaml
    /// </summary>
    public partial class DirectorWindow : Window
    {
        public DirectorWindow()
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

        private void ListAdministratorNBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddAdministratorNBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ListAdministratorPBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddAdministratorPBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ListAdministratorSBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddAdministratorSBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ListLogistNBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddLogistNBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void AddLogistPBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ListLogistSBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddLogistSBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ListManagerNBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddManagerNBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ListManagerPBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddManagerPBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ListManagerSBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddManagerSBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
