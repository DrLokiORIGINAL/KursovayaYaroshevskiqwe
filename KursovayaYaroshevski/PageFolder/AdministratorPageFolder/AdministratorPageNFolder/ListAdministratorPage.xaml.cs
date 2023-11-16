using KursovayaYaroshevski.ClassFolder;
using KursovayaYaroshevski.DataFolder;
using KursovayaYaroshevski.PageFolder.AdministratorPageFolder.AdministratorPageSFolder;
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

namespace KursovayaYaroshevski.PageFolder.AdministratorPageFolder.AdministratorPageNFolder
{
    /// <summary>
    /// Логика взаимодействия для ListAdministratorPage.xaml
    /// </summary>
    /// Novokuznetskaya
    public partial class ListAdministratorPage : Page
    {
        public ListAdministratorPage()
        {
            InitializeComponent();
            ListAdminDG.ItemsSource = DBEntities.GetContext().Novokuznetskaya.ToList()
                .OrderBy(c => c.IdNovokuznetskaya);
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {

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
                    new EditAdministratorNPage(ListAdminDG.SelectedItem as Novokuznetskaya));
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            Novokuznetskaya novokuznetskaya = ListAdminDG.SelectedItem as Novokuznetskaya;

            if (ListAdminDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите ячейку" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QestionMB("Удалить " +
                    $"ячейку под номером " +
                    $"{novokuznetskaya.IdNovokuznetskaya}?"))
                {
                    DBEntities.GetContext().Novokuznetskaya
                        .Remove(ListAdminDG.SelectedItem as Novokuznetskaya);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InformationMB("Ячейка удалена");
                    ListAdminDG.ItemsSource = DBEntities.GetContext()
                        .Novokuznetskaya.ToList().OrderBy(u => u.IdNovokuznetskaya);
                }

            }
        }
    }
}
