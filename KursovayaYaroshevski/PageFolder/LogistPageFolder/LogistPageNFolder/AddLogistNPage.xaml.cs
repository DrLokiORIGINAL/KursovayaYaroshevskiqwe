using KursovayaYaroshevski.ClassFolder;
using KursovayaYaroshevski.DataFolder;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
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
    /// Логика взаимодействия для AddLogistNPage.xaml
    /// </summary>
    public partial class AddLogistNPage : Page
    {
        SessionNovokuznetskaya sessionNovokuznetskaya = new SessionNovokuznetskaya();
        public AddLogistNPage()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SessionNovokuznetskayaAdd();

                MBClass.InformationMB("Сессия добавлена");
                NavigationService.Navigate(new ListLogistNPage());
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
                    sessionNovokuznetskaya.ImageSessionNovokuznetskaya = ImageClass.ConvertImageToByteArray(selectedFileName);
                    PhotoIm.Source = ImageClass.ConvertByteArrayToImage(sessionNovokuznetskaya.ImageSessionNovokuznetskaya);
                }
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void SessionNovokuznetskayaAdd()
        {
            try
            {
                var sessionNovokuznetskayaAdd = new SessionNovokuznetskaya()
                {
                    NameSessionNovokuznetskaya = NameTb.Text,
                    ARSeissionNovokuznetskaya = ARTb.Text,
                    TimeSessionNovokuznetskaya = TimeTb.Text,
                    ImageSessionNovokuznetskaya = ImageClass.ConvertImageToByteArray(selectedFileName),
                    DateSessionNovokuznetskaya = Convert.ToDateTime(DateDP.Text),
                };
                DBEntities.GetContext().SessionNovokuznetskaya.Add(sessionNovokuznetskayaAdd);
                DBEntities.GetContext().SaveChanges();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }

        }
    }
}
