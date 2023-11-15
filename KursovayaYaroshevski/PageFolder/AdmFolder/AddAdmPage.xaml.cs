using KursovayaYaroshevski.ClassFolder;
using KursovayaYaroshevski.DataFolder;
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

namespace KursovayaYaroshevski.PageFolder.AdmFolder
{
    /// <summary>
    /// Логика взаимодействия для AddAdmPage.xaml
    /// </summary>
    public partial class AddAdmPage : Page
    {
        public AddAdmPage()
        {
            InitializeComponent();
            RoleCb.ItemsSource = DBEntities.GetContext()
                .Role.ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            DBEntities.GetContext().User.Add(new User()
            {
                IdRole = Int32.Parse(RoleCb.SelectedValue.ToString()),
                LoginUser = LoginTb.Text,
                PasswordUser = PasswordTb.Text,
            });
            DBEntities.GetContext().SaveChanges();
            MBClass.InformationMB("Успешно");
            NavigationService.Navigate(new ListAdmPage());
        }
    }
}
