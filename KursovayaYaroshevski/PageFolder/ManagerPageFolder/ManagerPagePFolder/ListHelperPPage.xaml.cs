using KursovayaYaroshevski.ClassFolder;
using KursovayaYaroshevski.DataFolder;
using KursovayaYaroshevski.PageFolder.ManagerPageFolder.ManagerPageNFolder;
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

namespace KursovayaYaroshevski.PageFolder.ManagerPageFolder.ManagerPagePFolder
{
    /// <summary>
    /// Логика взаимодействия для ListHelperPPage.xaml
    /// </summary>
    /// Paveletskaya
    public partial class ListHelperPPage : Page
    {
        public ListHelperPPage()
        {
            InitializeComponent();
            ListAdminDG.ItemsSource = DBEntities.GetContext().HelperPaveletskaya.ToList()
                .OrderBy(c => c.IdHelperPaveletskaya);
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            HelperPaveletskaya helperPaveletskaya = ListAdminDG.SelectedItem as HelperPaveletskaya;

            if (ListAdminDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите помощника" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QestionMB("Удалить " +
                    $"помощника с ФИО " +
                    $"{helperPaveletskaya.FLMHelperPaveletskaya}?"))
                {
                    DBEntities.GetContext().HelperPaveletskaya
                        .Remove(ListAdminDG.SelectedItem as HelperPaveletskaya);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InformationMB("Помощник удален");
                    ListAdminDG.ItemsSource = DBEntities.GetContext()
                        .HelperPaveletskaya.ToList().OrderBy(u => u.FLMHelperPaveletskaya);
                }

            }
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            if (ListAdminDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    "помощника для редактирования");
            }
            else
            {
                NavigationService.Navigate(
                    new EditHelperPPage(ListAdminDG.SelectedItem as HelperPaveletskaya));
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListAdminDG.ItemsSource = DBEntities.GetContext()
                .HelperPaveletskaya.Where(u => u.FLMHelperPaveletskaya.StartsWith(SearchTb.Text))
                .ToList().OrderBy(u => u.FLMHelperPaveletskaya);
        }
    }
}
