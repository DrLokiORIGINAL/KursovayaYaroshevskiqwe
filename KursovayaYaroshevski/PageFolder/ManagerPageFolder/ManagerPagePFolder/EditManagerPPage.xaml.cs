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
    /// Логика взаимодействия для EditManagerPPage.xaml
    /// </summary>
    /// Paveletskaya
    public partial class EditManagerPPage : Page
    {
        StaffPaveletskaya staffPaveletskaya = new StaffPaveletskaya();
        public EditManagerPPage(StaffPaveletskaya staffPaveletskaya)
        {
            InitializeComponent();

            DataContext = staffPaveletskaya;

            this.staffPaveletskaya.IdStaffPaveletskaya = staffPaveletskaya.IdStaffPaveletskaya;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                staffPaveletskaya = DBEntities.GetContext().StaffPaveletskaya
                        .FirstOrDefault(u => u.IdStaffPaveletskaya == staffPaveletskaya.IdStaffPaveletskaya);
                staffPaveletskaya.FLMStaffPaveletskaya = FLMTb.Text;
                staffPaveletskaya.NumberPhoneStaffPaveletskaya = NumberTb.Text;
                staffPaveletskaya.EmailStaffPaveletskaya = EmailTb.Text;
                staffPaveletskaya.PositionStaffPaveletskaya = PositionTb.Text;
                DBEntities.GetContext().SaveChanges();
                MBClass.InformationMB("Данные успешно отредактированы");
                NavigationService.Navigate(new ListManagerPPage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
