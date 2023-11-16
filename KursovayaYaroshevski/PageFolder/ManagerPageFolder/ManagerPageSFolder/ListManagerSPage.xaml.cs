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
    /// Логика взаимодействия для ListManagerSPage.xaml
    /// </summary>
    /// Smolenskaya
    public partial class ListManagerSPage : Page
    {
        public ListManagerSPage()
        {
            InitializeComponent();
            ListAdminDG.ItemsSource = DBEntities.GetContext().StaffSmolenskaya.ToList()
                .OrderBy(c => c.IdStaffSmolenskaya);
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            StaffSmolenskaya staffSmolenskaya = ListAdminDG.SelectedItem as StaffSmolenskaya;

            if (ListAdminDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите сотрудника" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QestionMB("Удалить " +
                    $"сотрудника с ФИО " +
                    $"{staffSmolenskaya.FLMStaffSmolenskaya}?"))
                {
                    DBEntities.GetContext().StaffSmolenskaya
                        .Remove(ListAdminDG.SelectedItem as StaffSmolenskaya);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InformationMB("Сотрудник удален");
                    ListAdminDG.ItemsSource = DBEntities.GetContext()
                        .StaffSmolenskaya.ToList().OrderBy(u => u.FLMStaffSmolenskaya);
                }

            }
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            if (ListAdminDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    "сотрудника для редактирования");
            }
            else
            {
                NavigationService.Navigate(
                    new EditManagerSPage(ListAdminDG.SelectedItem as StaffSmolenskaya));
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListAdminDG.ItemsSource = DBEntities.GetContext()
                .StaffSmolenskaya.Where(u => u.FLMStaffSmolenskaya.StartsWith(SearchTb.Text))
                .ToList().OrderBy(u => u.FLMStaffSmolenskaya);
        }
    }
}
