using KursovayaYaroshevski.ClassFolder;
using KursovayaYaroshevski.PageFolder.AdmFolder;
using KursovayaYaroshevski.PageFolder.AdministratorPageFolder.AdministratorPageNFolder;
using KursovayaYaroshevski.PageFolder.AdministratorPageFolder.AdministratorPagePFolder;
using KursovayaYaroshevski.PageFolder.AdministratorPageFolder.AdministratorPageSFolder;
using KursovayaYaroshevski.PageFolder.LogistPageFolder.LogistPageNFolder;
using KursovayaYaroshevski.PageFolder.LogistPageFolder.LogistPagePFolder;
using KursovayaYaroshevski.PageFolder.LogistPageFolder.LogistPageSFolder;
using KursovayaYaroshevski.PageFolder.ManagerPageFolder.ManagerPageNFolder;
using KursovayaYaroshevski.PageFolder.ManagerPageFolder.ManagerPagePFolder;
using KursovayaYaroshevski.PageFolder.ManagerPageFolder.ManagerPageSFolder;
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
            MaiFrame.Navigate(new PageFolder.AdministratorPageFolder.AdministratorPagePFolder.ListAdministratorPPage());
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
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void ListAdministratorNBtn_Click(object sender, RoutedEventArgs e)
        {
            MaiFrame.Navigate(new ListAdministratorPage());
        }

        private void AddAdministratorNBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MaiFrame.Navigate(new AddAdministratorNPage());
        }

        private void ListAdministratorPBtn_Click(object sender, RoutedEventArgs e)
        {
            MaiFrame.Navigate(new ListAdministratorPPage());
        }

        private void AddAdministratorPBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MaiFrame.Navigate(new AddAdministratorPPage());
        }

        private void ListAdministratorSBtn_Click(object sender, RoutedEventArgs e)
        {
            MaiFrame.Navigate(new ListAdministratorSPage());
        }

        private void AddAdministratorSBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MaiFrame.Navigate(new ListAdministratorSPage());
        }

        private void ListLogistNBtn_Click(object sender, RoutedEventArgs e)
        {
            MaiFrame.Navigate(new ListLogistNPage());
        }

        private void AddLogistNBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MaiFrame.Navigate(new AddLogistNPage());
        }
        private void ListLogistPBtn_Click(object sender, RoutedEventArgs e)
        {
            MaiFrame.Navigate(new ListLogistPPage());
        }
        private void AddLogistPBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MaiFrame.Navigate(new AddLogistPPage());
        }
        
        private void ListLogistSBtn_Click(object sender, RoutedEventArgs e)
        {
            MaiFrame.Navigate(new ListLogistSPage());
        }
        
        private void AddLogistSBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MaiFrame.Navigate(new AddLogistSPage());
        }

        private void ListManagerNBtn_Click(object sender, RoutedEventArgs e)
        {
            MaiFrame.Navigate(new ListManagerNPage());
        }

        private void AddManagerNBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MaiFrame.Navigate(new AddManagerNPage());
        }

        private void ListManagerPBtn_Click(object sender, RoutedEventArgs e)
        {
            MaiFrame.Navigate(new ListManagerPPage());
        }

        private void AddManagerPBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MaiFrame.Navigate(new AddManagerPPage());
        }

        private void ListManagerSBtn_Click(object sender, RoutedEventArgs e)
        {
            MaiFrame.Navigate(new ListManagerSPage());
        }

        private void AddManagerSBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MaiFrame.Navigate(new AddManagerSPage());
        }

        
    }
}
