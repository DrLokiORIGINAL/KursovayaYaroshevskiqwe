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

namespace KursovayaYaroshevski.PageFolder.ManagerPageFolder.ManagerPageNFolder
{
    /// <summary>
    /// Логика взаимодействия для ListManagerNPage.xaml
    /// </summary>
    /// StaffNovokuznetskaya
    public partial class ListManagerNPage : Page
    {
        public ListManagerNPage()
        {
            InitializeComponent();
            ListAdminDG.ItemsSource = DBEntities.GetContext().StaffNovokuznetskaya.ToList()
                .OrderBy(c => c.IdStaffNovokuznetskaya);
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
                    new EditManagerNPage(ListAdminDG.SelectedItem as StaffNovokuznetskaya));
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            StaffNovokuznetskaya staffNovokuznetskaya = ListAdminDG.SelectedItem as StaffNovokuznetskaya;

            if (ListAdminDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите сотрудника" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QestionMB("Удалить " +
                    $"сотрудника с ФИО " +
                    $"{staffNovokuznetskaya.FLMStaffNovokuznetskaya}?"))
                {
                    DBEntities.GetContext().StaffNovokuznetskaya
                        .Remove(ListAdminDG.SelectedItem as StaffNovokuznetskaya);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InformationMB("Сотрудник удален");
                    ListAdminDG.ItemsSource = DBEntities.GetContext()
                        .StaffNovokuznetskaya.ToList().OrderBy(u => u.FLMStaffNovokuznetskaya);
                }

            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListAdminDG.ItemsSource = DBEntities.GetContext()
                .StaffNovokuznetskaya.Where(u => u.FLMStaffNovokuznetskaya.StartsWith(SearchTb.Text))
                .ToList().OrderBy(u => u.FLMStaffNovokuznetskaya);
        }
    }
}
