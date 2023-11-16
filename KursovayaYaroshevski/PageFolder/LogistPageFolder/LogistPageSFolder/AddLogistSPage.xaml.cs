using KursovayaYaroshevski.ClassFolder;
using KursovayaYaroshevski.DataFolder;
using KursovayaYaroshevski.PageFolder.LogistPageFolder.LogistPagePFolder;
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

namespace KursovayaYaroshevski.PageFolder.LogistPageFolder.LogistPageSFolder
{
    /// <summary>
    /// Логика взаимодействия для AddLogistSPage.xaml
    /// </summary>
    public partial class AddLogistSPage : Page
    {

        SessionSmolenskaya sessionSmolenskaya = new SessionSmolenskaya();

        public AddLogistSPage()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SessionSmolenskayaAdd();

                MBClass.InformationMB("Сессия добавлена");
                NavigationService.Navigate(new ListLogistSPage());
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
                    sessionSmolenskaya.ImageSessionSmolenskaya = ImageClass.ConvertImageToByteArray(selectedFileName);
                    PhotoIm.Source = ImageClass.ConvertByteArrayToImage(sessionSmolenskaya.ImageSessionSmolenskaya);
                }
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void SessionSmolenskayaAdd()
        {
            try
            {
                var sessionSmolenskayaAdd = new SessionSmolenskaya()
                {
                    NameSessionSmolenskaya = NameTb.Text,
                    ARSeissionSmolenskaya = ARTb.Text,
                    TimeSessionSmolenskaya = TimeTb.Text,
                    ImageSessionSmolenskaya = ImageClass.ConvertImageToByteArray(selectedFileName),
                    DateSessionSmolenskaya = Convert.ToDateTime(DateDP.Text),
                };
                DBEntities.GetContext().SessionSmolenskaya.Add(sessionSmolenskayaAdd);
                DBEntities.GetContext().SaveChanges();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }

        }

    }
}
