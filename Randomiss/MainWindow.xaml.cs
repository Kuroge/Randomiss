namespace Randomiss
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using MahApps.Metro.Controls;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void Number_TextChanged(object sender, TextChangedEventArgs e)
        {
            length.IsEnabled = true;
        }

        private void Length_TextChanged(object sender, TextChangedEventArgs e)
        {
            randomiss.IsEnabled = true;
        }

        private void Randomiss_Click(object sender, RoutedEventArgs e)
        {
            Generator password = new Generator(Convert.ToInt32(number.Text), Convert.ToInt32(length.Text));
            output.Text = string.Join("\n", password.GetData());
        }
    }
}
