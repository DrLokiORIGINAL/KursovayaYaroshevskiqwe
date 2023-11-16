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

namespace KursovayaYaroshevski.PageFolder.ManagerPageFolder.ManagerPageNFolder
{
    /// <summary>
    /// Логика взаимодействия для EditHelperNPage.xaml
    /// </summary>
    public partial class EditHelperNPage : Page
    {
        HelperNovokuznetskaya helperNovokuznetskaya = new HelperNovokuznetskaya();
        public EditHelperNPage(HelperNovokuznetskaya helperNovokuznetskaya)
        {
            InitializeComponent();

            DataContext = helperNovokuznetskaya;

            this.helperNovokuznetskaya.IdHelperNovokuznetskaya = helperNovokuznetskaya.IdHelperNovokuznetskaya;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                helperNovokuznetskaya = DBEntities.GetContext().HelperNovokuznetskaya
                        .FirstOrDefault(u => u.IdHelperNovokuznetskaya == helperNovokuznetskaya.IdHelperNovokuznetskaya);
                helperNovokuznetskaya.FLMHelperNovokuznetskaya = FLMTb.Text;
                helperNovokuznetskaya.NumberPhoneHelperNovokuznetskaya = NumberTb.Text;
                helperNovokuznetskaya.EmailHelperNovokuznetskaya = EmailTb.Text;
                helperNovokuznetskaya.PositionHelperNovokuznetskaya = PositionTb.Text;
                DBEntities.GetContext().SaveChanges();
                MBClass.InformationMB("Данные успешно отредактированы");
                NavigationService.Navigate(new ListHelperNPage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
