using KursovayaYaroshevski.ClassFolder;
using KursovayaYaroshevski.DataFolder;
using KursovayaYaroshevski.PageFolder.AdmFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KursovayaYaroshevski.PageFolder.LogistPageFolder.LogistPageNFolder
{
    /// <summary>
    /// Логика взаимодействия для ListLogistNPage.xaml
    /// </summary>
    public partial class ListLogistNPage : Page
    {
        public ListLogistNPage()
        {
            InitializeComponent();
            ListLogistNLB.ItemsSource = DBEntities.GetContext()
                .SessionNovokuznetskaya.ToList();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListLogistNLB.ItemsSource = DBEntities.GetContext()
                .SessionNovokuznetskaya.Where(u => u.NameSessionNovokuznetskaya.StartsWith(SearchTb.Text))
                .ToList().OrderBy(u => u.NameSessionNovokuznetskaya);
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
                    new EditLogistNPage(ListLogistNLB.SelectedItem as SessionNovokuznetskaya));
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            SessionNovokuznetskaya sessionNovokuznetskaya = ListLogistNLB.SelectedItem as SessionNovokuznetskaya;

            if (ListLogistNLB.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите сессию" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QestionMB("Удалить " +
                    $"сессию под названием " +
                    $"{sessionNovokuznetskaya.NameSessionNovokuznetskaya}?"))
                {
                    DBEntities.GetContext().SessionNovokuznetskaya
                        .Remove(ListLogistNLB.SelectedItem as SessionNovokuznetskaya);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InformationMB("Сессия удалена");
                    ListLogistNLB.ItemsSource = DBEntities.GetContext()
                        .SessionNovokuznetskaya.ToList().OrderBy(u => u.NameSessionNovokuznetskaya);
                }

            }
        }
    }
}
