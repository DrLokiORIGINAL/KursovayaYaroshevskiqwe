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
    /// Логика взаимодействия для ListManagerPPage.xaml
    /// </summary>
    /// Paveletskaya
    public partial class ListManagerPPage : Page
    {
        public ListManagerPPage()
        {
            InitializeComponent();
            ListAdminDG.ItemsSource = DBEntities.GetContext().StaffPaveletskaya.ToList()
                .OrderBy(c => c.IdStaffPaveletskaya);
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            StaffPaveletskaya staffPaveletskaya = ListAdminDG.SelectedItem as StaffPaveletskaya;

            if (ListAdminDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите сотрудника" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QestionMB("Удалить " +
                    $"сотрудника с ФИО " +
                    $"{staffPaveletskaya.FLMStaffPaveletskaya}?"))
                {
                    DBEntities.GetContext().StaffPaveletskaya
                        .Remove(ListAdminDG.SelectedItem as StaffPaveletskaya);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InformationMB("Сотрудник удален");
                    ListAdminDG.ItemsSource = DBEntities.GetContext()
                        .StaffPaveletskaya.ToList().OrderBy(u => u.FLMStaffPaveletskaya);
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
                    new EditManagerPPage(ListAdminDG.SelectedItem as StaffPaveletskaya));
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListAdminDG.ItemsSource = DBEntities.GetContext()
                .StaffPaveletskaya.Where(u => u.FLMStaffPaveletskaya.StartsWith(SearchTb.Text))
                .ToList().OrderBy(u => u.FLMStaffPaveletskaya);
        }
    }
}
