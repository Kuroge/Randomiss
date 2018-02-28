﻿using MahApps.Metro.Controls;
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

namespace Randomiss
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void number_TextChanged(object sender, TextChangedEventArgs e)
        {
            length.IsEnabled = true;
        }

        private void length_TextChanged(object sender, TextChangedEventArgs e)
        {
            randomiss.IsEnabled = true;
        }

        private void randomiss_Click(object sender, RoutedEventArgs e)
        {
            Generator password = new Generator(Convert.ToInt32(number.Text), Convert.ToInt32(length.Text));
            output.Text = password.GetData().ToString();
        }
    }
}
