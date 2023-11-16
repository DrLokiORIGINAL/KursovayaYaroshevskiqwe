using KursovayaYaroshevski.ClassFolder;
using KursovayaYaroshevski.DataFolder;
using KursovayaYaroshevski.PageFolder.AdmFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
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
    /// Логика взаимодействия для EditManagerNPage.xaml
    /// </summary>
    public partial class EditManagerNPage : Page
    {
        StaffNovokuznetskaya staffNovokuznetskaya = new StaffNovokuznetskaya();
        public EditManagerNPage(StaffNovokuznetskaya staffNovokuznetskaya)
        {
            InitializeComponent();

            DataContext = staffNovokuznetskaya;

            this.staffNovokuznetskaya.IdStaffNovokuznetskaya = staffNovokuznetskaya.IdStaffNovokuznetskaya;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                staffNovokuznetskaya = DBEntities.GetContext().StaffNovokuznetskaya
                        .FirstOrDefault(u => u.IdStaffNovokuznetskaya == staffNovokuznetskaya.IdStaffNovokuznetskaya);
                staffNovokuznetskaya.FLMStaffNovokuznetskaya = FLMTb.Text;
                staffNovokuznetskaya.NumberPhoneStaffNovokuznetskaya = NumberTb.Text;
                staffNovokuznetskaya.EmailStaffNovokuznetskaya = EmailTb.Text;
                staffNovokuznetskaya.PositionStaffNovokuznetskaya = PositionTb.Text;
                DBEntities.GetContext().SaveChanges();
                MBClass.InformationMB("Данные успешно отредактированы");
                NavigationService.Navigate(new ListManagerNPage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
