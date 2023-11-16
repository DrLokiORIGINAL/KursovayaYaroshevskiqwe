using KursovayaYaroshevski.ClassFolder;
using KursovayaYaroshevski.DataFolder;
using KursovayaYaroshevski.PageFolder.LogistPageFolder.LogistPagePFolder;
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

namespace KursovayaYaroshevski.PageFolder.LogistPageFolder.LogistPageSFolder
{
    /// <summary>
    /// Логика взаимодействия для ListLogistSPage.xaml
    /// </summary>
    public partial class ListLogistSPage : Page
    {
        public ListLogistSPage()
        {
            InitializeComponent();
            ListLogistNLB.ItemsSource = DBEntities.GetContext()
                .SessionSmolenskaya.ToList();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            SessionSmolenskaya sessionSmolenskaya = ListLogistNLB.SelectedItem as SessionSmolenskaya;

            if (ListLogistNLB.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите сессию" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QestionMB("Удалить " +
                    $"сессию под названием " +
                    $"{sessionSmolenskaya.NameSessionSmolenskaya}?"))
                {
                    DBEntities.GetContext().SessionSmolenskaya
                        .Remove(ListLogistNLB.SelectedItem as SessionSmolenskaya);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InformationMB("Сессия удалена");
                    ListLogistNLB.ItemsSource = DBEntities.GetContext()
                        .SessionSmolenskaya.ToList().OrderBy(u => u.NameSessionSmolenskaya);
                }

            }
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            if (ListLogistNLB.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    "сессию для редактирования");
            }
            else
            {
                NavigationService.Navigate(
                    new EditLogistSPage(ListLogistNLB.SelectedItem as SessionSmolenskaya));
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListLogistNLB.ItemsSource = DBEntities.GetContext()
                .SessionSmolenskaya.Where(u => u.NameSessionSmolenskaya.StartsWith(SearchTb.Text))
                .ToList().OrderBy(u => u.NameSessionSmolenskaya);
        }
    }
}
