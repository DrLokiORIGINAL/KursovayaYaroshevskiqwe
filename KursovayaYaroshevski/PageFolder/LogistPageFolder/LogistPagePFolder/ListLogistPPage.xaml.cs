using KursovayaYaroshevski.ClassFolder;
using KursovayaYaroshevski.DataFolder;
using KursovayaYaroshevski.PageFolder.LogistPageFolder.LogistPageNFolder;
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

namespace KursovayaYaroshevski.PageFolder.LogistPageFolder.LogistPagePFolder
{
    /// <summary>
    /// Логика взаимодействия для ListLogistPPage.xaml
    /// </summary>
    public partial class ListLogistPPage : Page
    {
        public ListLogistPPage()
        {
            InitializeComponent();
            ListLogistNLB.ItemsSource = DBEntities.GetContext()
                .SessionPaveletskaya.ToList();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            SessionPaveletskaya sessionPaveletskaya = ListLogistNLB.SelectedItem as SessionPaveletskaya;

            if (ListLogistNLB.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите сессию" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QestionMB("Удалить " +
                    $"сессию под названием " +
                    $"{sessionPaveletskaya.NameSessionPaveletskaya}?"))
                {
                    DBEntities.GetContext().SessionPaveletskaya
                        .Remove(ListLogistNLB.SelectedItem as SessionPaveletskaya);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InformationMB("Сессия удалена");
                    ListLogistNLB.ItemsSource = DBEntities.GetContext()
                        .SessionPaveletskaya.ToList().OrderBy(u => u.NameSessionPaveletskaya);
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
                    new EditLogistPPage(ListLogistNLB.SelectedItem as SessionPaveletskaya));
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListLogistNLB.ItemsSource = DBEntities.GetContext()
                .SessionPaveletskaya.Where(u => u.NameSessionPaveletskaya.StartsWith(SearchTb.Text))
                .ToList().OrderBy(u => u.NameSessionPaveletskaya);
        }
    }
}
