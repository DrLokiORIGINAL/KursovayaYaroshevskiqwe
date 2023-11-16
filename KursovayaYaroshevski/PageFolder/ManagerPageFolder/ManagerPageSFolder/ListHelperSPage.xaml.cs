using KursovayaYaroshevski.ClassFolder;
using KursovayaYaroshevski.DataFolder;
using KursovayaYaroshevski.PageFolder.ManagerPageFolder.ManagerPagePFolder;
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

namespace KursovayaYaroshevski.PageFolder.ManagerPageFolder.ManagerPageSFolder
{
    /// <summary>
    /// Логика взаимодействия для ListHelperSPage.xaml
    /// </summary>
    /// Smolenskaya
    public partial class ListHelperSPage : Page
    {
        public ListHelperSPage()
        {
            InitializeComponent();
            ListAdminDG.ItemsSource = DBEntities.GetContext().HelperSmolenskaya.ToList()
                .OrderBy(c => c.IdHelperSmolenskaya);
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            HelperSmolenskaya helperSmolenskaya = ListAdminDG.SelectedItem as HelperSmolenskaya;

            if (ListAdminDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите помощника" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QestionMB("Удалить " +
                    $"помощника с ФИО " +
                    $"{helperSmolenskaya.FLMHelperSmolenskaya}?"))
                {
                    DBEntities.GetContext().HelperSmolenskaya
                        .Remove(ListAdminDG.SelectedItem as HelperSmolenskaya);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InformationMB("Помощник удален");
                    ListAdminDG.ItemsSource = DBEntities.GetContext()
                        .HelperSmolenskaya.ToList().OrderBy(u => u.FLMHelperSmolenskaya);
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
                    new EditHelperSPage(ListAdminDG.SelectedItem as HelperSmolenskaya));
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListAdminDG.ItemsSource = DBEntities.GetContext()
                .HelperSmolenskaya.Where(u => u.FLMHelperSmolenskaya.StartsWith(SearchTb.Text))
                .ToList().OrderBy(u => u.FLMHelperSmolenskaya);
        }
    }
}
