using KursovayaYaroshevski.ClassFolder;
using KursovayaYaroshevski.DataFolder;
using KursovayaYaroshevski.PageFolder.AdmFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KursovayaYaroshevski.PageFolder.ManagerPageFolder.ManagerPageNFolder
{
    /// <summary>
    /// Логика взаимодействия для AddHelperNPage.xaml
    /// </summary>
    public partial class AddHelperNPage : Page
    {
        public AddHelperNPage()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            DBEntities.GetContext().HelperNovokuznetskaya.Add(new HelperNovokuznetskaya()
            {
                FLMHelperNovokuznetskaya = FLMTb.Text,
                NumberPhoneHelperNovokuznetskaya = NumberTb.Text,
                EmailHelperNovokuznetskaya = EmailTb.Text,
                PositionHelperNovokuznetskaya = PositionTb.Text,
            });
            DBEntities.GetContext().SaveChanges();
            MBClass.InformationMB("Успешно");
            NavigationService.Navigate(new ListHelperNPage());
        }
    }
}
