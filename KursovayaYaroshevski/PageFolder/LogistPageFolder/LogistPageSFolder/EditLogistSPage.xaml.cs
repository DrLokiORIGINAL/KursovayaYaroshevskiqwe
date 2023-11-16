using KursovayaYaroshevski.ClassFolder;
using KursovayaYaroshevski.DataFolder;
using KursovayaYaroshevski.PageFolder.LogistPageFolder.LogistPagePFolder;
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

namespace KursovayaYaroshevski.PageFolder.LogistPageFolder.LogistPageSFolder
{
    /// <summary>
    /// Логика взаимодействия для EditLogistSPage.xaml
    /// </summary>
    /// Smolenskaya
    public partial class EditLogistSPage : Page
    {

        SessionSmolenskaya sessionSmolenskaya = new SessionSmolenskaya();

        public EditLogistSPage(SessionSmolenskaya sessionSmolenskaya)
        {
            InitializeComponent();

            DataContext = sessionSmolenskaya;

            this.sessionSmolenskaya.IdSessionSmolenskaya = sessionSmolenskaya.IdSessionSmolenskaya;
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
                sessionSmolenskaya.ImageSessionSmolenskaya = ImageClass.ConvertImageToByteArray(selectedFileName);
                PhotoIm.Source = ImageClass.ConvertByteArrayToImage(sessionSmolenskaya.ImageSessionSmolenskaya);
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sessionSmolenskaya = DBEntities.GetContext().SessionSmolenskaya
                   .FirstOrDefault(u => u.IdSessionSmolenskaya == sessionSmolenskaya.IdSessionSmolenskaya);
                sessionSmolenskaya.NameSessionSmolenskaya = NameTb.Text;
                sessionSmolenskaya.ARSeissionSmolenskaya = ARTb.Text;
                sessionSmolenskaya.TimeSessionSmolenskaya = TimeTb.Text;
                sessionSmolenskaya.ImageSessionSmolenskaya = ImageClass.ConvertImageToByteArray(selectedFileName);
                sessionSmolenskaya.DateSessionSmolenskaya = Convert.ToDateTime(DateDP.Text);
                if (selectedFileName != "фото есть")

                    DBEntities.GetContext().SaveChanges();
                MBClass.InformationMB("Данные успешно отредактированы");
                NavigationService.Navigate(new ListLogistSPage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
