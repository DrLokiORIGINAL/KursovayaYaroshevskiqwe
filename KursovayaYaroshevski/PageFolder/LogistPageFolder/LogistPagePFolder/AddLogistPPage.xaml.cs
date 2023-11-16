using KursovayaYaroshevski.ClassFolder;
using KursovayaYaroshevski.DataFolder;
using KursovayaYaroshevski.PageFolder.LogistPageFolder.LogistPageNFolder;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    /// Логика взаимодействия для AddLogistPPage.xaml
    /// </summary>
    public partial class AddLogistPPage : Page
    {
        SessionPaveletskaya sessionPaveletskaya = new SessionPaveletskaya();
        public AddLogistPPage()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SessionPaveletskayaAdd();

                MBClass.InformationMB("Сессия добавлена");
                NavigationService.Navigate(new ListLogistPPage());
            }
            catch (DbEntityValidationException ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        string selectedFileName = "";

        private void LoadIm_Click(object sender, RoutedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void SessionPaveletskayaAdd()
        {
            try
            {
                var sessionPaveletskayaAdd = new SessionPaveletskaya()
                {
                    NameSessionPaveletskaya = NameTb.Text,
                    ARSeissionPaveletskaya = ARTb.Text,
                    TimeSessionPaveletskaya = TimeTb.Text,
                    ImageSessionPaveletskaya = ImageClass.ConvertImageToByteArray(selectedFileName),
                    DateSession = Convert.ToDateTime(DateDP.Text),
                };
                DBEntities.GetContext().SessionPaveletskaya.Add(sessionPaveletskayaAdd);
                DBEntities.GetContext().SaveChanges();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }

        }

    }
}
