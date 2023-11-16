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
    /// Логика взаимодействия для EditHelperSPage.xaml
    /// </summary>
    /// Smolenskaya
    public partial class EditHelperSPage : Page
    {
        HelperSmolenskaya helperSmolenskaya = new HelperSmolenskaya();
        public EditHelperSPage(HelperSmolenskaya helperSmolenskaya)
        {
            InitializeComponent();

            DataContext = helperSmolenskaya;

            this.helperSmolenskaya.IdHelperSmolenskaya = helperSmolenskaya.IdHelperSmolenskaya;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                helperSmolenskaya = DBEntities.GetContext().HelperSmolenskaya
                        .FirstOrDefault(u => u.IdHelperSmolenskaya == helperSmolenskaya.IdHelperSmolenskaya);
                helperSmolenskaya.FLMHelperSmolenskaya = FLMTb.Text;
                helperSmolenskaya.NumberPhoneHelperSmolenskaya = NumberTb.Text;
                helperSmolenskaya.EmailHelperSmolenskaya = EmailTb.Text;
                helperSmolenskaya.PositionHelperSmolenskaya = PositionTb.Text;
                DBEntities.GetContext().SaveChanges();
                MBClass.InformationMB("Данные успешно отредактированы");
                NavigationService.Navigate(new ListHelperSPage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
