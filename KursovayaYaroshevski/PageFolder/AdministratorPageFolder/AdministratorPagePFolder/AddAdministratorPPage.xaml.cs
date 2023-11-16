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
    /// Логика взаимодействия для AddAdministratorPPage.xaml
    /// </summary>
    public partial class AddAdministratorPPage : Page
    {
        public AddAdministratorPPage()
        {
            InitializeComponent();
            StaffCb.ItemsSource = DBEntities.GetContext()
               .StaffNovokuznetskaya.ToList();
            SessionCb.ItemsSource = DBEntities.GetContext()
               .SessionNovokuznetskaya.ToList();
            HelperCb.ItemsSource = DBEntities.GetContext()
               .HelperNovokuznetskaya.ToList();
            CleaningCb.ItemsSource = DBEntities.GetContext()
                .Cleaning.ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            DBEntities.GetContext().Paveletskaya.Add(new Paveletskaya()
            {
                IdStaffPaveletskaya = Int32.Parse(StaffCb.SelectedValue.ToString()),
                IdHelperPaveletskaya = Int32.Parse(HelperCb.SelectedValue.ToString()),
                IdSessionPaveletskaya = Int32.Parse(SessionCb.SelectedValue.ToString()),
                NumberOfNachosPaveletskaya = Int32.Parse(NachosTb.Text),
                NumberOfCrispsPaveletskaya = Int32.Parse(CrispsTb.Text),
                AmountOfColaPaveletskaya = Int32.Parse(ColaTb.Text),
                AmountOfFantaPaveletskaya = Int32.Parse(FantaTb.Text),
                AmountOfSweetPopcornPaveletskaya = Int32.Parse(SweetTb.Text),
                AmountOfSaltedPopcornPaveletskaya = Int32.Parse(SaltTb.Text),
                AmountOfCaramelPopcornPaveletskaya = Int32.Parse(CaramelTb.Text),
                IdCleaning = Int32.Parse(CleaningCb.SelectedValue.ToString()),
            });
            DBEntities.GetContext().SaveChanges();
            MBClass.InformationMB("Успешно");
            NavigationService.Navigate(new ListAdministratorPPage());
        }
    }
}
