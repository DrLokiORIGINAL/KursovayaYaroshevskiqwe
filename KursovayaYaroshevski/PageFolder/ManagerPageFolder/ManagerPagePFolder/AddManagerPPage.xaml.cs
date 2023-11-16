using KursovayaYaroshevski.ClassFolder;
using KursovayaYaroshevski.DataFolder;
using KursovayaYaroshevski.PageFolder.ManagerPageFolder.ManagerPageNFolder;
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

namespace KursovayaYaroshevski.PageFolder.ManagerPageFolder.ManagerPagePFolder
{
    /// <summary>
    /// Логика взаимодействия для AddManagerPPage.xaml
    /// </summary>
    public partial class AddManagerPPage : Page
    {
        public AddManagerPPage()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            DBEntities.GetContext().StaffPaveletskaya.Add(new StaffPaveletskaya()
            {
                FLMStaffPaveletskaya = FLMTb.Text,
                NumberPhoneStaffPaveletskaya = NumberTb.Text,
                EmailStaffPaveletskaya = EmailTb.Text,
                PositionStaffPaveletskaya = PositionTb.Text,
            });
            DBEntities.GetContext().SaveChanges();
            MBClass.InformationMB("Успешно");
            NavigationService.Navigate(new ListManagerPPage());
        }
    }
}
