﻿using KursovayaYaroshevski.ClassFolder;
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

namespace KursovayaYaroshevski.PageFolder.AdmFolder
{
    /// <summary>
    /// Логика взаимодействия для ListAdmPage.xaml
    /// </summary>
    /// asd
    public partial class ListAdmPage : Page
    {
        public ListAdmPage()
        {
            InitializeComponent();
            ListAdminDG.ItemsSource = DBEntities.GetContext().User.ToList()
                .OrderBy(c => c.IdUser);
        }

        private void Ref()
        {
            ListAdminDG.ItemsSource = DBEntities.GetContext().Role.ToList()
                .OrderBy(c => c.IdRole);
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            if (ListAdminDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    "пользователя для редактирования");
            }
            else
            {
                NavigationService.Navigate(
                    new EditAdmPage(ListAdminDG.SelectedItem as User));
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            User user = ListAdminDG.SelectedItem as User;

            if (ListAdminDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите пользователя" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QestionMB("Удалить " +
                    $"пользователя с логином " +
                    $"{user.LoginUser}?"))
                {
                    DBEntities.GetContext().User
                        .Remove(ListAdminDG.SelectedItem as User);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InformationMB("Пользователь удален");
                    ListAdminDG.ItemsSource = DBEntities.GetContext()
                        .User.ToList().OrderBy(u => u.LoginUser);
                }

            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListAdminDG.ItemsSource = DBEntities.GetContext()
                .User.Where(u => u.LoginUser.StartsWith(SearchTb.Text))
                .ToList().OrderBy(u => u.LoginUser);
        }
    }
}
