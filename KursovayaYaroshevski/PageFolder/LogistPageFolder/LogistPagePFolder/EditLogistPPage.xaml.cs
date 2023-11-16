using KursovayaYaroshevski.ClassFolder;
using KursovayaYaroshevski.DataFolder;
using KursovayaYaroshevski.PageFolder.LogistPageFolder.LogistPageNFolder;
using Microsoft.Win32;
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
    /// Логика взаимодействия для EditLogistPPage.xaml
    /// </summary>
    public partial class EditLogistPPage : Page
    {
        SessionPaveletskaya sessionPaveletskaya = new SessionPaveletskaya();
        public EditLogistPPage(SessionPaveletskaya sessionPaveletskaya)
        {
            InitializeComponent();

            DataContext = sessionPaveletskaya;

            this.sessionPaveletskaya.IdSessionPaveletskaya = sessionPaveletskaya.IdSessionPaveletskaya;
        }

        string selectedFileName = "";
        private void LoadIm_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.InitialDirectory = "";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                "Portable Network Graphic (*.png)|*.png";

            if (op.ShowDialog() == true)
            {
                selectedFileName = op.FileName;
                sessionPaveletskaya.ImageSessionPaveletskaya = ImageClass.ConvertImageToByteArray(selectedFileName);
                PhotoIm.Source = ImageClass.ConvertByteArrayToImage(sessionPaveletskaya.ImageSessionPaveletskaya);
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sessionPaveletskaya = DBEntities.GetContext().SessionPaveletskaya
                   .FirstOrDefault(u => u.IdSessionPaveletskaya == sessionPaveletskaya.IdSessionPaveletskaya);
                sessionPaveletskaya.NameSessionPaveletskaya = NameTb.Text;
                sessionPaveletskaya.ARSeissionPaveletskaya = ARTb.Text;
                sessionPaveletskaya.TimeSessionPaveletskaya = TimeTb.Text;
                sessionPaveletskaya.ImageSessionPaveletskaya = ImageClass.ConvertImageToByteArray(selectedFileName);
                sessionPaveletskaya.DateSession = Convert.ToDateTime(DateDP.Text);
                if (selectedFileName != "фото есть")

                    DBEntities.GetContext().SaveChanges();
                MBClass.InformationMB("Данные успешно отредактированы");
                NavigationService.Navigate(new ListLogistPPage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
