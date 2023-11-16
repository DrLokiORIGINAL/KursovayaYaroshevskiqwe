﻿using KursovayaYaroshevski.ClassFolder;
using KursovayaYaroshevski.PageFolder.AdmFolder;
using KursovayaYaroshevski.PageFolder.ManagerPageFolder.ManagerPageNFolder;
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
using System.Windows.Shapes;

namespace KursovayaYaroshevski.WindowFolder.ManagerFolder.ManagerNFolder
{
    /// <summary>
    /// Логика взаимодействия для ManagerNWindow.xaml
    /// </summary>
    public partial class ManagerNWindow : Window
    {
        public ManagerNWindow()
        {
            InitializeComponent();
            MaiFrame.Navigate(new PageFolder.ManagerPageFolder.ManagerPageNFolder.ListManagerNPage());
        }

        private void Close_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MBClass.QestionMB("Вы действительно хотите выйти из аккаунта?"))
            {
                new AuthorizationWindow().Show();
                Close();
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void ListStaffBtn_Click(object sender, RoutedEventArgs e)
        {
            MaiFrame.Navigate(new ListManagerNPage());
        }

        private void AddStaffBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MaiFrame.Navigate(new AddManagerNPage());
        }

        private void ListHelperBtn_Click(object sender, RoutedEventArgs e)
        {
            MaiFrame.Navigate(new ListHelperNPage());
        }

        private void AddHelperBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MaiFrame.Navigate(new AddHelperNPage());
        }
    }
}
