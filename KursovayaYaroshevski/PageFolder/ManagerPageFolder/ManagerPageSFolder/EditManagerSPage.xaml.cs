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
    /// Логика взаимодействия для EditManagerSPage.xaml
    /// </summary>
    /// Smolenskaya
    public partial class EditManagerSPage : Page
    {
        StaffSmolenskaya staffSmolenskaya = new StaffSmolenskaya();
        public EditManagerSPage(StaffSmolenskaya staffSmolenskaya)
        {
            InitializeComponent();
            DataContext = staffSmolenskaya;

            this.staffSmolenskaya.IdStaffSmolenskaya = staffSmolenskaya.IdStaffSmolenskaya;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                staffSmolenskaya = DBEntities.GetContext().StaffSmolenskaya
                        .FirstOrDefault(u => u.IdStaffSmolenskaya == staffSmolenskaya.IdStaffSmolenskaya);
                staffSmolenskaya.FLMStaffSmolenskaya = FLMTb.Text;
                staffSmolenskaya.NumberPhoneStaffSmolenskaya = NumberTb.Text;
                staffSmolenskaya.EmailStaffSmolenskaya = EmailTb.Text;
                staffSmolenskaya.PositionStaffSmolenskaya = PositionTb.Text;
                DBEntities.GetContext().SaveChanges();
                MBClass.InformationMB("Данные успешно отредактированы");
                NavigationService.Navigate(new ListManagerSPage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }

        }
    }
}
