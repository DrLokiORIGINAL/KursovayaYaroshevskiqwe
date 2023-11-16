using KursovayaYaroshevski.ClassFolder;
using KursovayaYaroshevski.DataFolder;
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
    /// Логика взаимодействия для EditHelperPPage.xaml
    /// </summary>
    /// Paveletskaya
    public partial class EditHelperPPage : Page
    {
        HelperPaveletskaya helperPaveletskaya = new HelperPaveletskaya();
        public EditHelperPPage(HelperPaveletskaya helperPaveletskaya)
        {
            InitializeComponent();

            DataContext = helperPaveletskaya;

            this.helperPaveletskaya.IdHelperPaveletskaya = helperPaveletskaya.IdHelperPaveletskaya;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                helperPaveletskaya = DBEntities.GetContext().HelperPaveletskaya
                        .FirstOrDefault(u => u.IdHelperPaveletskaya == helperPaveletskaya.IdHelperPaveletskaya);
                helperPaveletskaya.FLMHelperPaveletskaya = FLMTb.Text;
                helperPaveletskaya.NumberPhoneHelperPaveletskaya = NumberTb.Text;
                helperPaveletskaya.EmailHelperPaveletskaya = EmailTb.Text;
                helperPaveletskaya.PositionHelperPaveletskaya = PositionTb.Text;
                DBEntities.GetContext().SaveChanges();
                MBClass.InformationMB("Данные успешно отредактированы");
                NavigationService.Navigate(new ListHelperPPage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
