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
    /// Логика взаимодействия для AddManagerSPage.xaml
    /// </summary>
    /// Smolenskaya
    public partial class AddManagerSPage : Page
    {
        public AddManagerSPage()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            DBEntities.GetContext().StaffSmolenskaya.Add(new StaffSmolenskaya()
            {
                FLMStaffSmolenskaya = FLMTb.Text,
                NumberPhoneStaffSmolenskaya = NumberTb.Text,
                EmailStaffSmolenskaya = EmailTb.Text,
                PositionStaffSmolenskaya = PositionTb.Text,
            });
            DBEntities.GetContext().SaveChanges();
            MBClass.InformationMB("Успешно");
            NavigationService.Navigate(new ListManagerSPage());
        }
    }
}
