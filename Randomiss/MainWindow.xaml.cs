namespace Randomiss
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using MahApps.Metro.Controls;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private List<string> generatedPasswords = new List<string>();

        public ClipboardAction clipboardAction;

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
            generatedPasswords = password.GetData();
            output.Text = string.Join("\n", generatedPasswords);
            clipboardAction = new ClipboardAction(generatedPasswords);
            this.DataContext = clipboardAction;
            clipboard.Visibility = Visibility.Visible;
        }

        private void output_TextChanged(object sender, TextChangedEventArgs e)
        {
            clipboard.Visibility = Visibility.Visible;
        }

        private void github_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Kuroge/Randomiss");
        }

        private void clipboard_Click(object sender, RoutedEventArgs e)
        {
            clip_text.Content = clipboardAction.Copy();
        }
    }
}
