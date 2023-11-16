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
    /// Логика взаимодействия для ListHelperNPage.xaml
    /// </summary>
    /// HelperNovokuznetskaya
    public partial class ListHelperNPage : Page
    {
        public ListHelperNPage()
        {
            InitializeComponent();
            ListAdminDG.ItemsSource = DBEntities.GetContext().HelperNovokuznetskaya.ToList()
                .OrderBy(c => c.IdHelperNovokuznetskaya);
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            HelperNovokuznetskaya helperNovokuznetskaya = ListAdminDG.SelectedItem as HelperNovokuznetskaya;

            if (ListAdminDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите помощника" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QestionMB("Удалить " +
                    $"помощника с ФИО " +
                    $"{helperNovokuznetskaya.FLMHelperNovokuznetskaya}?"))
                {
                    DBEntities.GetContext().HelperNovokuznetskaya
                        .Remove(ListAdminDG.SelectedItem as HelperNovokuznetskaya);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InformationMB("Помощник удален");
                    ListAdminDG.ItemsSource = DBEntities.GetContext()
                        .HelperNovokuznetskaya.ToList().OrderBy(u => u.FLMHelperNovokuznetskaya);
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
                    new EditHelperNPage(ListAdminDG.SelectedItem as HelperNovokuznetskaya));
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListAdminDG.ItemsSource = DBEntities.GetContext()
                .HelperNovokuznetskaya.Where(u => u.FLMHelperNovokuznetskaya.StartsWith(SearchTb.Text))
                .ToList().OrderBy(u => u.FLMHelperNovokuznetskaya);
        }
    }
}
