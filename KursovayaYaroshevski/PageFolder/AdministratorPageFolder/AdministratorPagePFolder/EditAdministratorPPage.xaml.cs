using KursovayaYaroshevski.ClassFolder;
using KursovayaYaroshevski.DataFolder;
using KursovayaYaroshevski.PageFolder.AdministratorPageFolder.AdministratorPageNFolder;
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

namespace KursovayaYaroshevski.PageFolder.AdministratorPageFolder.AdministratorPagePFolder
{
    /// <summary>
    /// Логика взаимодействия для EditAdministratorPPage.xaml
    /// </summary>
    public partial class EditAdministratorPPage : Page
    {
        Paveletskaya paveletskaya = new Paveletskaya();
        public EditAdministratorPPage(Paveletskaya paveletskaya)
        {
            InitializeComponent();

            DataContext = paveletskaya;

            this.paveletskaya.IdPaveletskaya = paveletskaya.IdPaveletskaya;

            StaffCb.ItemsSource = DBEntities.GetContext()
               .StaffPaveletskaya.ToList();
            SessionCb.ItemsSource = DBEntities.GetContext()
               .SessionPaveletskaya.ToList();
            HelperCb.ItemsSource = DBEntities.GetContext()
               .HelperPaveletskaya.ToList();
            CleaningCb.ItemsSource = DBEntities.GetContext()
                .Cleaning.ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                paveletskaya = DBEntities.GetContext().Paveletskaya
                        .FirstOrDefault(u => u.IdPaveletskaya == paveletskaya.IdPaveletskaya);
                paveletskaya.IdStaffPaveletskaya = Int32.Parse(
                    StaffCb.SelectedValue.ToString());
                paveletskaya.IdHelperPaveletskaya = Int32.Parse(
                    HelperCb.SelectedValue.ToString());
                paveletskaya.IdSessionPaveletskaya = Int32.Parse(
                    SessionCb.SelectedValue.ToString());
                paveletskaya.NumberOfNachosPaveletskaya = Int32.Parse(NachosTb.Text);
                paveletskaya.NumberOfCrispsPaveletskaya = Int32.Parse(CrispsTb.Text);
                paveletskaya.AmountOfColaPaveletskaya = Int32.Parse(ColaTb.Text);
                paveletskaya.AmountOfFantaPaveletskaya = Int32.Parse(FantaTb.Text);
                paveletskaya.AmountOfSweetPopcornPaveletskaya = Int32.Parse(SweetTb.Text);
                paveletskaya.AmountOfSaltedPopcornPaveletskaya = Int32.Parse(SaltTb.Text);
                paveletskaya.AmountOfCaramelPopcornPaveletskaya = Int32.Parse(CaramelTb.Text);
                paveletskaya.IdCleaning = Int32.Parse(
                    CleaningCb.SelectedValue.ToString());
                DBEntities.GetContext().SaveChanges();
                MBClass.InformationMB("Данные успешно отредактированы");
                NavigationService.Navigate(new ListAdministratorPPage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
