using KursovayaYaroshevski.ClassFolder;
using KursovayaYaroshevski.DataFolder;
using KursovayaYaroshevski.PageFolder.ManagerPageFolder.ManagerPagePFolder;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KursovayaYaroshevski.PageFolder.ManagerPageFolder.ManagerPageSFolder
{
    /// <summary>
    /// Логика взаимодействия для AddHelperSPage.xaml
    /// </summary>
    /// Smolenskaya
    public partial class AddHelperSPage : Page
    {
        public AddHelperSPage()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            DBEntities.GetContext().HelperSmolenskaya.Add(new HelperSmolenskaya()
            {
                FLMHelperSmolenskaya = FLMTb.Text,
                NumberPhoneHelperSmolenskaya = NumberTb.Text,
                EmailHelperSmolenskaya = EmailTb.Text,
                PositionHelperSmolenskaya = PositionTb.Text,
            });
            DBEntities.GetContext().SaveChanges();
            MBClass.InformationMB("Успешно");
            NavigationService.Navigate(new ListHelperSPage());
        }
    }
}
