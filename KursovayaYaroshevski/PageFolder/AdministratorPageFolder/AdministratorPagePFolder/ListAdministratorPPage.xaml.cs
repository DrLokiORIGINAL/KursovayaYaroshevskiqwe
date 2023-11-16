using KursovayaYaroshevski.ClassFolder;
using KursovayaYaroshevski.DataFolder;
using KursovayaYaroshevski.PageFolder.AdmFolder;
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
    /// Логика взаимодействия для ListAdministratorPPage.xaml
    /// </summary>
    public partial class ListAdministratorPPage : Page
    {
        public ListAdministratorPPage()
        {
            InitializeComponent();
            ListAdminDG.ItemsSource = DBEntities.GetContext().Paveletskaya.ToList()
                .OrderBy(c => c.IdPaveletskaya);
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            Paveletskaya paveletskaya = ListAdminDG.SelectedItem as Paveletskaya;

            if (ListAdminDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите ячейку" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QestionMB("Удалить " +
                    $"ячейку под номером " +
                    $"{paveletskaya.IdPaveletskaya}?"))
                {
                    DBEntities.GetContext().Paveletskaya
                        .Remove(ListAdminDG.SelectedItem as Paveletskaya);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InformationMB("Ячейка удалена");
                    ListAdminDG.ItemsSource = DBEntities.GetContext()
                        .Paveletskaya.ToList().OrderBy(u => u.IdPaveletskaya);
                }

            }
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            if (ListAdminDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    "ячейку для редактирования");
            }
            else
            {
                NavigationService.Navigate(
                    new EditAdministratorPPage(ListAdminDG.SelectedItem as Paveletskaya));
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
