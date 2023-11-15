using KursovayaYaroshevski.ClassFolder;
using KursovayaYaroshevski.DataFolder;
using KursovayaYaroshevski.WindowFolder.AdmFolder;
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
using System.Windows.Shapes;
using KursovayaYaroshevski.DataFolder;
using KursovayaYaroshevski.WindowFolder.AdministratorFolder.AdministratorPFolder;
using KursovayaYaroshevski.WindowFolder.AdministratorFolder.AdministratorNFolder;
using KursovayaYaroshevski.WindowFolder.AdministratorFolder.AdministratorSFolder;
using KursovayaYaroshevski.WindowFolder.ManagerFolder.ManagerPFolder;
using KursovayaYaroshevski.WindowFolder.ManagerFolder.ManagerNFolder;
using KursovayaYaroshevski.WindowFolder.ManagerFolder.ManagerSFolder;
using KursovayaYaroshevski.WindowFolder.LogistFolder.LogistPFolder;
using KursovayaYaroshevski.WindowFolder.LogistFolder.LogistNFolder;
using KursovayaYaroshevski.WindowFolder.LogistFolder.LogistSFolder;
using KursovayaYaroshevski.WindowFolder.DirectorFolder;

namespace KursovayaYaroshevski.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Close_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
                Application.Current.Shutdown();
        }

        private void ComeInBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LoginTB.Text))
            {
                MBClass.ErrorMB("Введите логин");
                LoginTB.Focus();
            }
            if (string.IsNullOrEmpty(PasswordPsb.Password))
            {
                MBClass.ErrorMB("Введите пароль");
                PasswordPsb.Focus();
            }
            else
            {
                try
                {
                    var user = DBEntities.GetContext().User.FirstOrDefault
                        (u => u.LoginUser == LoginTB.Text);
                    if (user == null)
                    {
                        MBClass.ErrorMB("Пользователь не найден");
                        LoginTB.Focus();
                        return;
                    }
                    if (user.PasswordUser != PasswordPsb.Password)
                    {
                        MBClass.ErrorMB("Введен не правильный пароль");
                        PasswordPsb.Focus();
                        return;
                    }
                    else
                    {
                        switch (user.IdRole)
                        {
                            case 1:
                                new WindowFolder.AdministratorFolder.AdministratorPFolder.AdministratorPWindow().Show();
                                this.Close();
                                break;

                            case 2:
                                AdministratorNWindow AdministrationNWindow = new AdministratorNWindow();
                                AdministrationNWindow.Show();
                                this.Close();
                                break;

                            case 3:
                                AdministratorSWindow AdministrationSWindow = new AdministratorSWindow();
                                AdministrationSWindow.Show();
                                this.Close();
                                break;

                            case 4:
                                ManagerPWindow ManagerPWindow = new ManagerPWindow();
                                ManagerPWindow.Show();
                                this.Close();
                                break;

                            case 5:
                                ManagerNWindow ManagerNWindow = new ManagerNWindow();
                                ManagerNWindow.Show();
                                this.Close();
                                break;

                            case 6:
                                ManagerSWindow ManagerSWindow = new ManagerSWindow();
                                ManagerSWindow.Show();
                                this.Close();
                                break;

                            case 7:
                                LogistPWindow LogistPWindow = new LogistPWindow();
                                LogistPWindow.Show();
                                this.Close();
                                break;

                            case 8:
                                LogistNWindow LogistNWindow = new LogistNWindow();
                                LogistNWindow.Show();
                                this.Close();
                                break;

                            case 9:
                                LogistSWindow LogistSWindow = new LogistSWindow();
                                LogistSWindow.Show();
                                this.Close();
                                break;

                            case 10:
                                DirectorWindow DirectorWindow = new DirectorWindow();
                                DirectorWindow.Show();
                                this.Close();
                                break;

                            case 11:
                                MainAdmWindow MainAdmWindow = new MainAdmWindow();
                                MainAdmWindow.Show();
                                this.Close();
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }
    }
}
