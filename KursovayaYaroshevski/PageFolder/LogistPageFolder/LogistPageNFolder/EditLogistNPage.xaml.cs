using KursovayaYaroshevski.ClassFolder;
using KursovayaYaroshevski.DataFolder;
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

namespace KursovayaYaroshevski.PageFolder.LogistPageFolder.LogistPageNFolder
{
    /// <summary>
    /// Логика взаимодействия для EditLogistNPage.xaml
    /// </summary>
    public partial class EditLogistNPage : Page
    {
        SessionNovokuznetskaya sessionNovokuznetskaya = new SessionNovokuznetskaya();
        public EditLogistNPage(SessionNovokuznetskaya sessionNovokuznetskaya)
        {
            InitializeComponent();

            DataContext = sessionNovokuznetskaya;

            this.sessionNovokuznetskaya.IdSessionNovokuznetskaya = sessionNovokuznetskaya.IdSessionNovokuznetskaya;
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
                sessionNovokuznetskaya.ImageSessionNovokuznetskaya = ImageClass.ConvertImageToByteArray(selectedFileName);
                PhotoIm.Source = ImageClass.ConvertByteArrayToImage(sessionNovokuznetskaya.ImageSessionNovokuznetskaya);
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sessionNovokuznetskaya = DBEntities.GetContext().SessionNovokuznetskaya
                   .FirstOrDefault(u => u.IdSessionNovokuznetskaya == sessionNovokuznetskaya.IdSessionNovokuznetskaya);
                sessionNovokuznetskaya.NameSessionNovokuznetskaya = NameTb.Text;
                sessionNovokuznetskaya.ARSeissionNovokuznetskaya = ARTb.Text;
                sessionNovokuznetskaya.TimeSessionNovokuznetskaya = TimeTb.Text;
                sessionNovokuznetskaya.ImageSessionNovokuznetskaya = ImageClass.ConvertImageToByteArray(selectedFileName);
                sessionNovokuznetskaya.DateSessionNovokuznetskaya = Convert.ToDateTime(DateDP.Text);
                if (selectedFileName != "фото есть")
                    
                DBEntities.GetContext().SaveChanges();
                MBClass.InformationMB("Данные успешно отредактированы");
                NavigationService.Navigate(new ListLogistNPage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
