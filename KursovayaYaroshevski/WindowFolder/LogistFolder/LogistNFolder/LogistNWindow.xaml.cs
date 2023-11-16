using KursovayaYaroshevski.ClassFolder;
using KursovayaYaroshevski.PageFolder.AdmFolder;
using KursovayaYaroshevski.PageFolder.LogistPageFolder.LogistPageNFolder;
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

namespace KursovayaYaroshevski.WindowFolder.LogistFolder.LogistNFolder
{
    /// <summary>
    /// Логика взаимодействия для LogistNWindow.xaml
    /// </summary>
    public partial class LogistNWindow : Window
    {
        public LogistNWindow()
        {
            InitializeComponent();
            MaiFrame.Navigate(new PageFolder.LogistPageFolder.LogistPageNFolder.ListLogistNPage());
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

        private void ListLogistBtn_Click(object sender, RoutedEventArgs e)
        {
            MaiFrame.Navigate(new ListLogistNPage());
        }

        private void AddBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MaiFrame.Navigate(new AddLogistNPage());
        }
    }
}
