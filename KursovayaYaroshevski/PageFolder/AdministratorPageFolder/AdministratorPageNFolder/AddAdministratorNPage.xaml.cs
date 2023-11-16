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
    /// Логика взаимодействия для AddAdministratorNPage.xaml
    /// </summary>
    public partial class AddAdministratorNPage : Page
    {
        public AddAdministratorNPage()
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
            DBEntities.GetContext().Novokuznetskaya.Add(new Novokuznetskaya()
            {
            IdStaffNovokuznetskaya = Int32.Parse(StaffCb.SelectedValue.ToString()),
            IdHelperNovokuznetskaya = Int32.Parse(HelperCb.SelectedValue.ToString()),
                IdSessionNovokuznetskaya = Int32.Parse(SessionCb.SelectedValue.ToString()),
            NumberOfNachosNovokuznetskaya = Int32.Parse(NachosTb.Text),
            NumberOfCrispsNovokuznetskaya = Int32.Parse(CrispsTb.Text),
            AmountOfColaNovokuznetskaya = Int32.Parse(ColaTb.Text),
            AmountOfFantaNovokuznetskaya = Int32.Parse(FantaTb.Text),
            AmountOfSweetPopcornNovokuznetskaya = Int32.Parse(SweetTb.Text),
            AmountOfSaltedPopcornNovokuznetskaya = Int32.Parse(SaltTb.Text),
            AmountOfCaramelPopcornNovokuznetskaya = Int32.Parse(CaramelTb.Text),
            IdCleaning = Int32.Parse(CleaningCb.SelectedValue.ToString()),
        });
            DBEntities.GetContext().SaveChanges();
            MBClass.InformationMB("Успешно");
            NavigationService.Navigate(new ListAdministratorPage());
        }
    }
}
