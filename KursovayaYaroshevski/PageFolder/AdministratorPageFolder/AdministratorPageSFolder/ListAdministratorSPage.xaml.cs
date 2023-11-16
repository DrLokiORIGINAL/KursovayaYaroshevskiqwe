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
    /// Логика взаимодействия для ListAdministratorSPage.xaml
    /// </summary>
    public partial class ListAdministratorSPage : Page
    {
        public ListAdministratorSPage()
        {
            InitializeComponent();
            ListAdminDG.ItemsSource = DBEntities.GetContext().Smolenskaya.ToList()
                .OrderBy(c => c.IdSmolenskaya);
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            Smolenskaya smolenskaya = ListAdminDG.SelectedItem as Smolenskaya;

            if (ListAdminDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите ячейку" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QestionMB("Удалить " +
                    $"ячейку под номером " +
                    $"{smolenskaya.IdSmolenskaya}?"))
                {
                    DBEntities.GetContext().Smolenskaya
                        .Remove(ListAdminDG.SelectedItem as Smolenskaya);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InformationMB("Ячейка удалена");
                    ListAdminDG.ItemsSource = DBEntities.GetContext()
                        .Smolenskaya.ToList().OrderBy(u => u.IdSmolenskaya);
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
                    new EditAdministratorSPage(ListAdminDG.SelectedItem as Smolenskaya));
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
