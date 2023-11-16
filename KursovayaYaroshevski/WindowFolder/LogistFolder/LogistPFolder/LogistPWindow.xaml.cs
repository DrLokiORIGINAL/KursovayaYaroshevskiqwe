using KursovayaYaroshevski.ClassFolder;
using KursovayaYaroshevski.PageFolder.LogistPageFolder.LogistPageNFolder;
using KursovayaYaroshevski.PageFolder.LogistPageFolder.LogistPagePFolder;
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

namespace KursovayaYaroshevski.WindowFolder.LogistFolder.LogistPFolder
{
    /// <summary>
    /// Логика взаимодействия для LogistPWindow.xaml
    /// </summary>
    public partial class LogistPWindow : Window
    {
        public LogistPWindow()
        {
            InitializeComponent();
            MaiFrame.Navigate(new PageFolder.LogistPageFolder.LogistPagePFolder.ListLogistPPage());
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
            MaiFrame.Navigate(new ListLogistPPage());
        }

        private void AddBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MaiFrame.Navigate(new AddLogistPPage());
        }
    }
}
