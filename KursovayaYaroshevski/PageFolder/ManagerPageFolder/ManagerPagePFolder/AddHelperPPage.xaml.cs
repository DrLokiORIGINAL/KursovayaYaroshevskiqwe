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
    /// Логика взаимодействия для AddHelperPPage.xaml
    /// </summary>
    public partial class AddHelperPPage : Page
    {
        public AddHelperPPage()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            DBEntities.GetContext().HelperPaveletskaya.Add(new HelperPaveletskaya()
            {
                FLMHelperPaveletskaya = FLMTb.Text,
                NumberPhoneHelperPaveletskaya = NumberTb.Text,
                EmailHelperPaveletskaya = EmailTb.Text,
                PositionHelperPaveletskaya = PositionTb.Text,
            });
            DBEntities.GetContext().SaveChanges();
            MBClass.InformationMB("Успешно");
            NavigationService.Navigate(new ListHelperPPage());
        }
    }
}
