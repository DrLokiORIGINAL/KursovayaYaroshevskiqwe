using KursovayaYaroshevski.ClassFolder;
using KursovayaYaroshevski.PageFolder.AdmFolder;
using KursovayaYaroshevski.PageFolder.AdministratorPageFolder.AdministratorPageNFolder;
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

namespace KursovayaYaroshevski.WindowFolder.AdministratorFolder.AdministratorNFolder
{
    /// <summary>
    /// Логика взаимодействия для AdministratorNWindow.xaml
    /// </summary>
    public partial class AdministratorNWindow : Window
    {
        public AdministratorNWindow()
        {
            InitializeComponent();
            MaiFrame.Navigate(new PageFolder.AdministratorPageFolder.AdministratorPageNFolder.ListAdministratorPage());
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Close_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MBClass.QestionMB("Вы действительно хотите выйти из аккаунта?"))
            {
                new AuthorizationWindow().Show();
                Close();
            }
        }

        private void ListAdministratorBtn_Click(object sender, RoutedEventArgs e)
        {
            MaiFrame.Navigate(new ListAdministratorPage());
        }

        private void AddBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MaiFrame.Navigate(new AddAdministratorNPage());
        }
    }
}
