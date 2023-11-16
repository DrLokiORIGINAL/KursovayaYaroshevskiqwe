using KursovayaYaroshevski.ClassFolder;
using KursovayaYaroshevski.DataFolder;
using KursovayaYaroshevski.PageFolder.AdministratorPageFolder.AdministratorPagePFolder;
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
    /// Логика взаимодействия для EditAdministratorSPage.xaml
    /// </summary>
    public partial class EditAdministratorSPage : Page
    {
        Smolenskaya smolenskaya = new Smolenskaya();
        public EditAdministratorSPage(Smolenskaya smolenskaya)
        {
            InitializeComponent();

            DataContext = smolenskaya;

            this.smolenskaya.IdSmolenskaya = smolenskaya.IdSmolenskaya;

            StaffCb.ItemsSource = DBEntities.GetContext()
               .StaffSmolenskaya.ToList();
            SessionCb.ItemsSource = DBEntities.GetContext()
               .SessionSmolenskaya.ToList();
            HelperCb.ItemsSource = DBEntities.GetContext()
               .HelperSmolenskaya.ToList();
            CleaningCb.ItemsSource = DBEntities.GetContext()
                .Cleaning.ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                smolenskaya = DBEntities.GetContext().Smolenskaya
                        .FirstOrDefault(u => u.IdSmolenskaya == smolenskaya.IdSmolenskaya);
                smolenskaya.IdStaffSmolenskaya = Int32.Parse(
                    StaffCb.SelectedValue.ToString());
                smolenskaya.IdHelperSmolenskaya = Int32.Parse(
                    HelperCb.SelectedValue.ToString());
                smolenskaya.IdSessionSmolenskaya = Int32.Parse(
                    SessionCb.SelectedValue.ToString());
                smolenskaya.NumberOfNachosSmolenskaya = Int32.Parse(NachosTb.Text);
                smolenskaya.NumberOfCrispsSmolenskaya = Int32.Parse(CrispsTb.Text);
                smolenskaya.AmountOfColaSmolenskaya = Int32.Parse(ColaTb.Text);
                smolenskaya.AmountOfFantaSmolenskaya = Int32.Parse(FantaTb.Text);
                smolenskaya.AmountOfSweetPopcornSmolenskaya = Int32.Parse(SweetTb.Text);
                smolenskaya.AmountOfSaltedPopcornSmolenskaya = Int32.Parse(SaltTb.Text);
                smolenskaya.AmountOfCaramelPopcornSmolenskaya = Int32.Parse(CaramelTb.Text);
                smolenskaya.IdCleaning = Int32.Parse(
                    CleaningCb.SelectedValue.ToString());
                DBEntities.GetContext().SaveChanges();
                MBClass.InformationMB("Данные успешно отредактированы");
                NavigationService.Navigate(new ListAdministratorSPage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
