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

namespace KursovayaYaroshevski.PageFolder.AdministratorPageFolder.AdministratorPageNFolder
{
    /// <summary>
    /// Логика взаимодействия для EditAdministratorNPage.xaml
    /// </summary>
    public partial class EditAdministratorNPage : Page
    {
        Novokuznetskaya novokuznetskaya = new Novokuznetskaya();
        public EditAdministratorNPage(Novokuznetskaya novokuznetskaya)
        {
            InitializeComponent();
            DataContext = novokuznetskaya;

            this.novokuznetskaya.IdNovokuznetskaya = novokuznetskaya.IdNovokuznetskaya;

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
            try
            {
                novokuznetskaya = DBEntities.GetContext().Novokuznetskaya
                        .FirstOrDefault(u => u.IdNovokuznetskaya == novokuznetskaya.IdNovokuznetskaya);
                novokuznetskaya.IdStaffNovokuznetskaya = Int32.Parse(
                    StaffCb.SelectedValue.ToString());
                novokuznetskaya.IdHelperNovokuznetskaya = Int32.Parse(
                    HelperCb.SelectedValue.ToString());
                novokuznetskaya.IdSessionNovokuznetskaya = Int32.Parse(
                    SessionCb.SelectedValue.ToString());
                novokuznetskaya.NumberOfNachosNovokuznetskaya = Int32.Parse(NachosTb.Text);
                novokuznetskaya.NumberOfCrispsNovokuznetskaya = Int32.Parse(CrispsTb.Text);
                novokuznetskaya.AmountOfColaNovokuznetskaya = Int32.Parse(ColaTb.Text);
                novokuznetskaya.AmountOfFantaNovokuznetskaya = Int32.Parse(FantaTb.Text);
                novokuznetskaya.AmountOfSweetPopcornNovokuznetskaya = Int32.Parse(SweetTb.Text);
                novokuznetskaya.AmountOfSaltedPopcornNovokuznetskaya = Int32.Parse(SaltTb.Text);
                novokuznetskaya.AmountOfCaramelPopcornNovokuznetskaya = Int32.Parse(CaramelTb.Text);
                novokuznetskaya.IdCleaning = Int32.Parse(CleaningCb.SelectedValue.ToString());
                DBEntities.GetContext().SaveChanges();
                MBClass.InformationMB("Данные успешно отредактированы");
                NavigationService.Navigate(new ListAdministratorPage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
