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

namespace KursovayaYaroshevski.PageFolder.AdministratorPageFolder.AdministratorPageSFolder
{
    /// <summary>
    /// Логика взаимодействия для AddAdministratorSPage.xaml
    /// </summary>
    public partial class AddAdministratorSPage : Page
    {
        public AddAdministratorSPage()
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
            DBEntities.GetContext().Smolenskaya.Add(new Smolenskaya()
            {
                IdStaffSmolenskaya = Int32.Parse(StaffCb.SelectedValue.ToString()),
                IdHelperSmolenskaya = Int32.Parse(HelperCb.SelectedValue.ToString()),
                IdSessionSmolenskaya = Int32.Parse(SessionCb.SelectedValue.ToString()),
                NumberOfNachosSmolenskaya = Int32.Parse(NachosTb.Text),
                NumberOfCrispsSmolenskaya = Int32.Parse(CrispsTb.Text),
                AmountOfColaSmolenskaya = Int32.Parse(ColaTb.Text),
                AmountOfFantaSmolenskaya = Int32.Parse(FantaTb.Text),
                AmountOfSweetPopcornSmolenskaya = Int32.Parse(SweetTb.Text),
                AmountOfSaltedPopcornSmolenskaya = Int32.Parse(SaltTb.Text),
                AmountOfCaramelPopcornSmolenskaya = Int32.Parse(CaramelTb.Text),
                IdCleaning = Int32.Parse(CleaningCb.SelectedValue.ToString()),
            });
            DBEntities.GetContext().SaveChanges();
            MBClass.InformationMB("Успешно");
            NavigationService.Navigate(new ListAdministratorSPage());
        }
    }
}
