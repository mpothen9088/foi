using System;
using System.Windows;
using System.Windows.Controls;

namespace tiffin
{
    public partial class cuisine : Window
    {
        public cuisine()
        {
            InitializeComponent();
        }

        private void keralaButton_Click(object sender, RoutedEventArgs e)
        {
            kerala keralaWindow = new kerala();
            keralaWindow.Show();
        }

        private void punjabButton_Click(object sender, RoutedEventArgs e)
        {
            punjab punjabWindow = new punjab();
            punjabWindow.Show();
        }
    }
}
